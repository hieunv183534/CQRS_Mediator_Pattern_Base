
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal._Base.Models;
using NOM.REPORT.Domain._Base.Extentions;
using NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries;
using NOM.REPORT.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QRCoder;
//using Microsoft.Office.Interop.Excel;
//using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NOM.REPORT.WebApi.Controllers.ReportBi
{
    public class ReportBiController : ApiController
    {

        //private readonly IQueueService _queueService;
        //private readonly IAdvancedBus _bus;
        private IConfiguration _configuration;

        public ReportBiController(IConfiguration configuration)
        {
            //_queueService = queueService;
            //_bus = bus;
            _configuration = configuration;
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> View([FromQuery] ExportQuery request)
        {
            var file = await Mediator.Send(request);
            return File(SaveAsPdf(file.FileData), "application/pdf");
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> Export([FromQuery] ExportQuery request)
        {
            var file = await Mediator.Send(request);
            if (!request.FileName.HasValue())
            {
                request.FileName = file.FileName;
            }
            if (request.Type == 1)
            {
                request.FileName += ".pdf";
                return File(SaveAsPdf(file.FileData), "application/octet-stream", request.FileName);
            }
            else if (request.Type == 2)
            {
                request.FileName += ".xlsx";
                return File(file.FileData, "application/octet-stream", request.FileName);
            }
            else if (request.Type == 3)
            {
                request.FileName += ".docx";
            }
            return File(file.FileData, "application/octet-stream", request.FileName);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<string> TestDataSet([FromBody] TestDataQuery request)
        {
            var result = await Mediator.Send(request);
            return result.JsonToString();
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<PagingResultModel<ComboboxModel<string>>> ListConnection(BasePagingModel request)
        {
            var result = new PagingResultModel<ComboboxModel<string>>();
            var combobox = new List<ComboboxModel<string>>();
            if (request == null || request.Page == 1)
            {
                combobox.Add(new ComboboxModel<string>
                {
                    Text = "KT1",
                    Value = "DefaultConnection"
                });
                combobox.Add(new ComboboxModel<string>
                {
                    Text = "DataWareHouse",
                    Value = "DataWareHouse"
                });
                result.Data = combobox;
            }

            return result;
        }

        [HttpGet]
        //[AllowAnonymous]
        public string Test()
        {
            return "Ok";
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<string> TestQueue()
        {
            //await _queueService.SendStringAsync("test", "exchange.log", "log.test");
            return "Ok";
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> Barcode()
        {
            var template = "reportListEmployeeCommendationTemplate.xlsx";
            var directoryBase = Directory.GetCurrentDirectory();
            var folder = Path.Combine(directoryBase, "wwwroot");

            //custom tag
            var ngsTempFunc = NGS.Templater.Configuration.Builder.Include((value, metadata) =>
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

            //using (var memoryStream = new MemoryStream())
            var memoryStream = new MemoryStream();
            {
                using (var document = ngsTemp.Open(new FileStream(Path.Combine(folder, template), FileMode.Open, FileAccess.Read, FileShare.Read), "xlsx", memoryStream))
                {
                    document.Process(new
                    {
                        ducnv = "100901100900BMS10001001010051",
                        file = "[{\"fileNumber\":\"385f069f-4b88-49a9-b635-5781319815f8\",\"fileName\":\"0820CA8F-0AFC-40BE-AA48-B991690A827C.jpeg\",\"fileSize\":76575,\"fileExtension\":\".jpeg\",\"fileUrl\":\"/api/file/dowload?id=5094166015000903\"}]"
                    });
                }
                var workbookXSSF = new NPOI.XSSF.UserModel.XSSFWorkbook();
                memoryStream.Position = 0;
                //var xssfwb = new NPOI.XSSF.UserModel.XSSFWorkbook(memoryStream);
                //workbookXSSF = xssfwb.CopySheet(0);
                //var memory = new MemoryStream();
                //workbookXSSF.Write(memory);
                //memory.Position = 0;
                return File(memoryStream, "application/octet-stream", "reportListEmployeeCommendation.xlsx");
            }
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

        private Stream SaveAsPdf(byte[] file)
        {
            try
            {
                using (Stream templateStream = new MemoryStream(file))
                {
                    Spire.License.LicenseProvider.SetLicenseKey(_configuration.GetValue<string>("ElicKey"));
                    var workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromStream(templateStream, Spire.Xls.ExcelVersion.Version2010);
                    var memory = new MemoryStream();
                    {
                        workbook.SaveToStream(memory, Spire.Xls.FileFormat.PDF);
                        return memory;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //private void convertITO(byte[] file)
        //{

        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        //    app.ScreenUpdating = false;
        //    app.DisplayStatusBar = false;
        //    app.DisplayAlerts = false;
        //    app.Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual;
        //    app.EnableEvents = false;
        //    app.Visible = false;
        //    Microsoft.Office.Interop.Excel.Workbook excelFile = app.Workbooks.Open("", ReadOnly: true);

        //    var paramExportFormat = Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF;
        //    var paramExportQuality = Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard;
        //    var paramOpenAfterPublish = false;
        //    var paramIncludeDocProps = true;
        //    var paramIgnorePrintAreas = true;
        //    var paramFromPage = Type.Missing;
        //    var paramToPage = Type.Missing;
        //    excelFile.ExportAsFixedFormat(paramExportFormat,
        //        @"c:\myWorksheet",
        //        paramExportQuality,
        //        paramIncludeDocProps,
        //        paramIgnorePrintAreas,
        //        paramFromPage,
        //        paramToPage);
        //    excelFile.Close(SaveChanges: false);
        //}
    }
}
