using AutoMapper;
using NOM.Dao.DataWareHouse;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using NOM.DomainGlobal._Base.Extentions;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class TestDataQueryHandler : IRequestHandler<TestDataQuery, JObject>
    {
        private ApplicationDbContext _context;
        private DataWareHouseDbContext _dh;
        private IMapper _mapper;
        private IMediator _mediator;

        public TestDataQueryHandler(ApplicationDbContext context,
            DataWareHouseDbContext dh,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _dh = dh;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<JObject> Handle(TestDataQuery request, CancellationToken cancellationToken)
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
                                            if (Jitem.GetValue(keyName).ToObject(Jitem.GetType()).Equals(y.GetValue(keyName).ToObject(Jitem.GetType())))
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
                            JArray hColumn = new JArray();

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

                                if (Jitem.ContainsKey("HColumn"))
                                {
                                    var checkZColumn = hColumn.FirstOrDefault(x => x.Value<object>().Equals(Jitem.Value<object>("HColumn")));
                                    if (checkZColumn == null)
                                    {
                                        hColumn.Add(Jitem.Value<string>("HColumn"));
                                    }
                                }
                            }

                            var SttItem = new JArray();

                            var totalItem = new JArray();

                            //add header
                            var HeaderItem = new JArray();
                            var HeaderItem2 = new JArray();
                            foreach (object Xitem in xColumn)
                            {
                                HeaderItem.Add(Xitem);
                                foreach (var HItem in hColumn)
                                {
                                    HeaderItem2.Add(HItem);
                                }
                            }

                            var stt = 0;
                            foreach (object Yitem in yColumn)
                            {
                                var NItem = new JArray();
                                NItem.Add(Yitem);

                                stt++;
                                SttItem.Add(stt);

                                foreach (object Xitem in xColumn)
                                {
                                    if (hColumn.Count == 0)
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
                                    else
                                    {
                                        foreach (var Hitem in hColumn)
                                        {
                                            var value = sqlData.Where(x => x.Value<object>("XColumn").Equals(Xitem) &&
                                                                         x.Value<object>("YColumn").Equals(Yitem) &&
                                                                         x.Value<object>("HColumn").Equals(Hitem))
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
                                    }

                                }
                                datArray.Add(NItem);
                            }

                            // Ttnh tong
                            foreach (JArray dItem in datArray)
                            {
                                var index = 0;
                                foreach (JValue IItem in dItem)
                                {
                                    if (totalItem.Count < dItem.Count) {
                                        totalItem.Add(0);
                                    }

                                    if (IItem.Value != null && IItem.Type == JTokenType.Integer)
                                    {
                                        totalItem[index] = totalItem[index].Value<int>() + IItem.Value<int>();
                                    }
                                    else if (IItem.Value != null && IItem.Type == JTokenType.Float)
                                    {
                                        totalItem[index] = totalItem[index].Value<float>() + IItem.Value<float>();
                                    }
                                    index++;
                                }
                            }

                            JObject dataConvert = new JObject();
                            dataConvert.Add("S", SttItem);
                            dataConvert.Add("H", new JArray() { HeaderItem });
                            dataConvert.Add("H2", new JArray() { HeaderItem2 });
                            dataConvert.Add("B", datArray);
                            dataConvert.Add("T", totalItem);

                            dataBuild.Add(item.Name, dataConvert);
                        }
                        break;
                    default:
                        break;
                }
            };
            return dataBuild;
        }
    }
}


