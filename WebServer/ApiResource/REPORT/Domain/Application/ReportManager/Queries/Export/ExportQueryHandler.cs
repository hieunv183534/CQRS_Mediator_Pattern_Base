using AutoMapper;
using NOM.Dao.DataWareHouse;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal.Models.FileCenter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NGS.Templater;
using NPOI.XSSF.UserModel;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class ExportQueryHandler : IRequestHandler<ExportQuery, ExportQueryResult>
    {
        private ApplicationDbContext _context;
        private DataWareHouseDbContext _dh;
        private IMapper _mapper;
        private IMediator _mediator;
        private IFileCenterService _file;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public ExportQueryHandler(ApplicationDbContext context,
            DataWareHouseDbContext dh,
            IMapper mapper,
            IMediator mediator,
            IFileCenterService file,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dh = dh;
            _mapper = mapper;
            _mediator = mediator;
            _file = file;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ExportQueryResult> Handle(ExportQuery request, CancellationToken cancellationToken)
        {
            var reportQuery = _context.ReportManager
                .Include(x => x.ReportManagerParam)
                .Include(x => x.ReportManagerDataSet)
                .Include(x => x.ReportManagerGroupBy).AsQueryable();

            if (request.ReportId.HasValue())
            {
                reportQuery = reportQuery.Where(x => x.Id == request.ReportId);
            }

            if (request.ReportCode.HasValue())
            {
                reportQuery = reportQuery.Where(x => x.Name == request.ReportCode);
            }

            var reportData = await reportQuery
                .FirstOrDefaultAsync();

            if (reportData == null)
            {
                throw new ValidationException("", "Không tìm thấy report");
            }

            if (reportData.FileTemplate == null)
            {
                throw new ValidationException("", "FileTemplate Chưa có file");
            }

            var templateJson = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(reportData.FileTemplate);
            if (templateJson.Count == 0)
            {
                throw new ValidationException("", "FileTemplate Chưa có file");
            }

            var templateNumber = templateJson[0].Value<JObject>().Value<string>("fileNumber");
            var fileDowload = await _file.Dowload(new DowloadModel
            {
                FileNumber = templateNumber
            });

            //custom tag
            var ngsTempFunc = Configuration.Builder.Include((value, metadata) =>
            {
                if (!metadata.StartsWith("barcode(") || value == null || value.GetType() != typeof(string)) return value;

                //var parts = metadata.Substring(8).Split(',');
                //parts[parts.Length - 1] = parts[parts.Length - 1].Replace(")", "");

                //var maxHeight = 0;
                //if (parts.Length == 1 && parts[parts.Length - 1].HasValue())
                //{
                //    maxHeight = int.Parse(parts[parts.Length - 1].Trim());
                //}

                //var maxWith = 0;
                //if (parts.Length > 1)
                //{
                //    maxWith = int.Parse(parts[0].Trim());
                //    maxHeight = int.Parse(parts[parts.Length - 1].Trim());
                //}

                var bmp = FormatBarCode(value as string);// as Bitmap;

                //var scaleW = 1f;
                //var scaleH = 1f;
                //if (bmp.Height > 0 && maxHeight > 0)
                //{
                //    scaleH = scaleH * bmp.Height / maxHeight;
                //}
                //if (bmp.Width > 0 && maxWith > 0)
                //{
                //    scaleW = scaleW * bmp.Width / maxWith;
                //}
                //else if (bmp.Height > 0 && maxHeight > 0)
                //{
                //    scaleW = scaleH;
                //}

                //if (maxHeight > 0 || maxHeight > 0)
                //{
                //    //Before passing image for processing it can be manipulated via Templater plugins
                //    bmp.SetResolution(bmp.HorizontalResolution * scaleW, bmp.VerticalResolution * scaleH);
                //}

                return bmp;
            });

            ngsTempFunc = ngsTempFunc.Include((value, metadata) =>
            {
                if (!metadata.StartsWith("qrcode(") || value == null || value.GetType() != typeof(string)) return value;
                //var parts = metadata.Substring(7).Split(',');
                //parts[parts.Length - 1] = parts[parts.Length - 1].Replace(")", "");

                //var maxHeight = 0;
                //if (parts.Length == 1 && parts[parts.Length - 1].HasValue())
                //{
                //    maxHeight = int.Parse(parts[parts.Length - 1].Trim());
                //}

                var bmp = BitmapByteQRCodeHelper.GetQRCode(value as string, QRCodeGenerator.ECCLevel.Q, 60);//FormatQrcode(value as string);

                //var scaleH = 1f;
                //if (bmp.Height > 0 && maxHeight > 0)
                //{
                //    scaleH = scaleH * bmp.Height / maxHeight;
                //}

                //if (maxHeight > 0 || maxHeight > 0)
                //{
                //    //Before passing image for processing it can be manipulated via Templater plugins
                //    bmp.SetResolution(bmp.HorizontalResolution * scaleH, bmp.VerticalResolution * scaleH);
                //}

                return bmp;
            });

            ngsTempFunc = ngsTempFunc.Include((value, metadata) =>
            {
                if (!metadata.StartsWith("img(") || value == null || value.GetType() != typeof(string)) return value;
                var valueJson = (value as string).JsonToObject<JArray>();
                if (valueJson.Count == 0)
                {
                    return null;
                }
                var url = valueJson[0].ToObject<JObject>().GetValue("fileUrl").Value<string>();

                //var parts = metadata.Substring(4).Split(',');
                //parts[parts.Length - 1] = parts[parts.Length - 1].Replace(")", "");

                //var maxHeight = 0;
                //if (parts.Length == 1 && parts[parts.Length - 1].HasValue())
                //{
                //    maxHeight = int.Parse(parts[parts.Length - 1].Trim());
                //}

                //var maxWith = 0;
                //if (parts.Length > 1)
                //{
                //    maxWith = int.Parse(parts[0].Trim());
                //    maxHeight = int.Parse(parts[parts.Length - 1].Trim());
                //}

                var bmp = DowloadImage(url);// as Bitmap;

                //var scaleW = 1f;
                //var scaleH = 1f;
                //if (bmp.Height > 0 && maxHeight > 0)
                //{
                //    scaleH = scaleH * bmp.Height / maxHeight;
                //}
                //if (bmp.Width > 0 && maxWith > 0)
                //{
                //    scaleW = scaleW * bmp.Width / maxWith;
                //}
                //else if (bmp.Height > 0 && maxHeight > 0)
                //{
                //    scaleW = scaleH;
                //}

                //if (maxHeight > 0 || maxHeight > 0)
                //{
                //    //Before passing image for processing it can be manipulated via Templater plugins
                //    bmp.SetResolution(bmp.HorizontalResolution * scaleW, bmp.VerticalResolution * scaleH);
                //}

                return bmp;
            });

            var ngsTemp = ngsTempFunc.Build("v6:info@absolute.com.vn", _configuration.GetValue<string>("TemplaterKey"));

            var memoryStream = new MemoryStream();
            using (Stream templateStream = new MemoryStream(fileDowload.FileData))
            {
                using (var document = ngsTemp.Open(templateStream, "xlsx", memoryStream))
                {
                    JObject dataBuild = new JObject();
                    foreach (var item in reportData.ReportManagerDataSet)
                    {
                        switch (item.SourceType)
                        {
                            case 1:
                                var sql = item.DataValue;
                                var sqlParam = new List<SqlParameter>();
                                foreach (var p in reportData.ReportManagerParam)
                                {
                                    sqlParam.Add(new SqlParameter
                                    {
                                        ParameterName = $"@{p.Name}",
                                        SqlDbType = p.DataType == 1 ? SqlDbType.NVarChar : p.DataType == 2 ? SqlDbType.BigInt : SqlDbType.DateTime,
                                        Value = null
                                    });
                                    sql = sql.Replace($":{p.Name}", $"@{p.Name}");
                                }
                                if (request.ReportParams != null)
                                {
                                    foreach (var key in request.ReportParams.JsonToObject().Properties())
                                    {
                                        var KeyData = sqlParam.Find(x => x.ParameterName == $"@{key.Name}");
                                        if (KeyData != null)
                                        {
                                            switch (KeyData.SqlDbType)
                                            {
                                                case SqlDbType.NVarChar:
                                                    KeyData.Value = key.Value.ToObject<string>();
                                                    break;
                                                case SqlDbType.BigInt:
                                                    KeyData.Value = key.Value.ToObject<long>();
                                                    break;
                                                case SqlDbType.DateTime:
                                                    var dateValue = key.Value.ToObject<DateTime?>();
                                                    if (dateValue != null)
                                                    {
                                                        KeyData.Value = (key.Value.ToObject<DateTime>().AddHours(7));
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                JArray sqlData = new JArray();
                                switch (item.ConnectString)
                                {
                                    case "DataWareHouse":
                                        sqlData = await _dh.ExcuteStoredProcedure(sql, sqlParam.ToArray());
                                        break;
                                    default:
                                        sqlData = await _context.ExcuteStoredProcedure(sql, sqlParam.ToArray());
                                        break;
                                }
                                if (item.DataType == 5) // Object
                                {
                                    if (sqlData.Count > 0)
                                    {
                                        dataBuild.Add(item.Name, sqlData[0]);
                                    }
                                    else
                                    {
                                        dataBuild.Add(item.Name, null);
                                    }
                                }
                                else if (item.DataType == 6) // Array
                                {
                                    JArray datArray = new JArray();
                                    var groupByData = reportData.ReportManagerGroupBy.FirstOrDefault(x => x.DataSetId == item.Id);
                                    if (groupByData != null)
                                    {
                                        var path = groupByData.Key?.Split(",");
                                        int i = 1;
                                        int j = 1;
                                        foreach (JObject Jitem in sqlData)
                                        {
                                            var checkGroupExist = -1;
                                            var checkGroupIndex = 0;
                                            foreach (JObject y in datArray)
                                            {
                                                var checkPass = path.Length;
                                                foreach (var keyName in path)
                                                {
                                                    if (Jitem.GetValue(keyName) == null && y.GetValue(keyName) == null)
                                                    {
                                                        checkPass--;
                                                    }
                                                    else if (Jitem.GetValue(keyName).ToObject(Jitem.GetType()).Equals(y.GetValue(keyName).ToObject(Jitem.GetType())))
                                                    {
                                                        checkPass--;
                                                    }
                                                }
                                                if (checkPass == 0)
                                                {
                                                    checkGroupExist = checkGroupIndex;
                                                }
                                                checkGroupIndex++;
                                            }
                                            if (checkGroupExist == -1)
                                            {
                                                j = 1;
                                                var newGroup = new JObject();
                                                var valueGroup = (JObject)Jitem.DeepClone();
                                                newGroup.Add("STT", i);
                                                valueGroup.Add("STT", j);
                                                i++;
                                                foreach (var keyName in path)
                                                {
                                                    newGroup.Add(keyName, Jitem.GetValue(keyName));
                                                    valueGroup.Remove(keyName);
                                                }
                                                newGroup.Add("ValueGroup", new JArray { valueGroup });
                                                datArray.Add(newGroup);
                                            }
                                            else
                                            {
                                                var valueGroup = (JObject)Jitem.DeepClone();
                                                valueGroup.Add("STT", j);
                                                foreach (var keyName in path)
                                                {
                                                    valueGroup.Remove(keyName);
                                                }
                                                (datArray[checkGroupExist]["ValueGroup"] as JArray).Add(valueGroup);
                                            }
                                            j++;
                                        }
                                        dataBuild.Add(item.Name, datArray);
                                    }
                                    else
                                    {
                                        int i = 1;
                                        foreach (JObject Jitem in sqlData)
                                        {
                                            Jitem.Add("STT", i);
                                            i++;
                                        }
                                        dataBuild.Add(item.Name, sqlData);
                                    }
                                }
                                else if (item.DataType == 7) // Array Array
                                {
                                    JArray datArray = new JArray();
                                    JArray xColumn = new JArray();
                                    JArray yColumn = new JArray();
                                    foreach (JObject Jitem in sqlData)
                                    {
                                        var checkXColumn = xColumn.FirstOrDefault(x => x.Value<object>().Equals(Jitem.Value<object>("XColumn")));
                                        if (checkXColumn == null)
                                        {
                                            xColumn.Add(Jitem.Value<object>("XColumn"));
                                        }
                                        var checkYColumn = yColumn.FirstOrDefault(x => x.Value<object>().Equals(Jitem.Value<object>("YColumn")));
                                        if (checkYColumn == null)
                                        {
                                            yColumn.Add(Jitem.Value<string>("YColumn"));
                                        }
                                    }

                                    //add header
                                    var HeaderItem = new JArray();
                                    foreach (object Xitem in xColumn)
                                    {
                                        HeaderItem.Add(Xitem);
                                    }

                                    foreach (object Yitem in yColumn)
                                    {
                                        var NItem = new JArray();
                                        NItem.Add(Yitem);
                                        foreach (object Xitem in xColumn)
                                        {
                                            var value = sqlData.Where(x => x.Value<object>("XColumn").Equals(Xitem) &&
                                                                                  x.Value<object>("YColumn").Equals(Yitem))
                                                               .Select(x => x.Value<object>("ZColumn"))
                                                               .FirstOrDefault();
                                            if (value != null)
                                            {
                                                NItem.Add(value);
                                            }
                                            else
                                            {
                                                NItem.Add(null);
                                            }
                                        }
                                        datArray.Add(NItem);
                                    }

                                    JObject dataConvert = new JObject();
                                    dataConvert.Add("H", new JArray() { HeaderItem });
                                    dataConvert.Add("B", datArray);

                                    dataBuild.Add(item.Name, dataConvert);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    document.Process(dataBuild.ToObject<ExpandoObject>());
                }
            }

            var workbookXSSF = new XSSFWorkbook();
            memoryStream.Position = 0;
            return new ExportQueryResult
            {
                FileName = reportData.Name,
                FileData = memoryStream.ToArray()
            };
        }

        //private Bitmap FormatQrcode(string value)
        //{
            
        //    byte[] imageData = BitmapByteQRCodeHelper.GetQRCode(value, QRCodeGenerator.ECCLevel.Q, 60);
        //    Bitmap qrCodeImage;
        //    using (var ms = new MemoryStream(imageData))
        //    {
        //        qrCodeImage = new Bitmap(ms);
        //    }
        //    return qrCodeImage;
        //}

        private Image FormatBarCode(string value)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image image = b.Encode(BarcodeLib.TYPE.CODE128, value, Color.Black, Color.White, 480, 60);
            return image;
        }

        private Image DowloadImage(string url)
        {
            var req = _httpContextAccessor.HttpContext;
            var token = req.Request.Query["access_token"].ToString();
            if (url.IndexOf("?") == -1)
            {
                url += "?access_token=" + token;
            }
            else
            {
                url += "&access_token=" + token;
            }
            using (var http = new HttpClient())
            {
                var domain = _configuration.GetValue<string>("FileServer");
                var uri = new Uri($"{domain}{url}");
                var response = http.GetAsync(uri).Result;
                MemoryStream ms = new MemoryStream();
                response.Content.CopyToAsync(ms).Wait();
                return Image.FromStream(ms);
            }
        }
    }
}


