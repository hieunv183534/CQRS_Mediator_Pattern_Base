using NOM.BACKGROUND.Domain._Interfaces;
using NOM.Dao.DataWareHouse;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.BACKGROUND.Domain._Services
{
    public class HangfireReportService : IHangfireReportService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HangfireReportService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task CalReport(NOM.Common.Enums.ReportType reportType)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var kt1 = scopedServices.GetRequiredService<ApplicationDbContext>();
                IConfiguration _configuration = scopedServices.GetRequiredService<IConfiguration>();
                IWebHostEnvironment _hostingEnvironment = scopedServices.GetRequiredService<IWebHostEnvironment>();

                var lstTask = kt1.ReportDynamic.Where(a => a.TypeRun == (int)reportType).ToList();
                if(lstTask.Count > 0)
                {
                    //type DownLoad 1 - pdf 2 - excel 3 - doc
                    string frmEndPoint = _configuration.GetValue<string>("UrlReport", @"https://vnpost.ddns.net/report/api/ReportBi/Export")  + @"?ReportCode={0}&FileName={0}&Type={1}&ReportParams={2}&access_token={3}";
                    
                    var date = GetDate(reportType);
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    var pathFolder = Path.Combine(webRootPath, "Report", DateTime.Today.ToString("yyyyMMdd"));
                    if (!Directory.Exists(pathFolder))
                    {
                        Directory.CreateDirectory(pathFolder);
                    }
                    //todo: Miss token
                    string token = string.Empty;
                    foreach (var task in lstTask)
                    {
                        string param = task.Param
                                    .Replace("@TuNgay@", date.Item1.ToString("yyyyMMdd"))
                                    .Replace("@DenNgay@", date.Item2.ToString("yyyyMMdd"))
                                    .Replace("@Year@", date.Item3.ToString("#"))
                                    .Replace("@Month@", date.Item4.ToString("#"))
                                    .Replace("@Quy@", date.Item5.ToString("#"));
                        string endPoint = string.Format(frmEndPoint, task.ReportName, 2, param, token);
                        var pathFile = Path.Combine(pathFolder, RT.Comb.Provider.Sql.CreateDoubleID(88888) + task.ReportName + ".xlsx");
                        await ReportServices.GetReportAsync(endPoint, pathFile);
                        await kt1.AddAsync(new ReportMail
                        {
                            AttactFile = pathFile,
                            Email = task.Email,
                            MailBody = task.MailBody,
                            MailSubject = task.MailSubject,
                            Sended = false,
                            CreateTime = DateTime.Now,
                            DeleteFile = false

                        });
                    }
                    await kt1.SaveChangesAsync();
                }
            }
        }

        private Tuple<DateTime, DateTime, int, int, int> GetDate(NOM.Common.Enums.ReportType reportType)
        {
            DateTime today = DateTime.Today;
            DateTime minDate;
            DateTime maxDate;
            int quy=0;
            switch (reportType)
            {
                case Common.Enums.ReportType.Ngay:
                    minDate = today.AddDays(-1);
                    maxDate = minDate;
                    break;
                case Common.Enums.ReportType.Tuan:
                    minDate = today.AddDays(-7 - (int)today.DayOfWeek);
                    maxDate = minDate.AddDays(6);
                    break;
                case Common.Enums.ReportType.Thang:
                    minDate = today.AddMonths(-1);
                    minDate = minDate.AddDays(0-minDate.Day);
                    maxDate = minDate.AddMonths(1).AddDays(-1);
                    break;
                case Common.Enums.ReportType.Quy:
                    if (today.Month > 9)
                    {
                        quy = 3;
                        minDate = new DateTime(today.Year, 7, 1);
                    }
                    else if (today.Month > 6)
                    {
                        quy = 2;
                        minDate = new DateTime(today.Year, 4, 1);
                    }
                    else if (today.Month > 3)
                    {
                        quy = 1;
                        minDate = new DateTime(today.Year, 1, 1);
                    }
                    else
                    {
                        quy = 4;
                        minDate = new DateTime(today.Year - 1, 10, 1);
                    }
                    maxDate = minDate.AddMonths(3).AddDays(-1);
                    break;
                default:
                    minDate = today;
                    maxDate = today;
                    break;
            }
            return new Tuple<DateTime, DateTime, int, int, int>(minDate, maxDate, minDate.Year, minDate.Month, quy);
        }

        public async Task SendMailReoprt()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var kt1 = scopedServices.GetRequiredService<ApplicationDbContext>();
                var _configuration = scopedServices.GetRequiredService<IConfiguration>();
                IWebHostEnvironment _hostingEnvironment = scopedServices.GetRequiredService<IWebHostEnvironment>();

                var lstTask = kt1.ReportMail.Where(a => a.Sended == false).ToList();
                if (lstTask.Count > 0)
                {
                    using (MailHelper mailHelper = new MailHelper(_configuration))
                    {
                        foreach (var task in lstTask)
                        {
                            var ok = mailHelper.Send(_configuration["Gmail:Username"], task.Email, task.MailSubject, task.MailBody, new List<string> { task.AttactFile });
                            if (ok)
                            {
                                task.Sended = true;
                                task.SendTime = DateTime.Now;
                                //FileInfo fileInfo = new FileInfo(task.AttactFile);
                                //fileInfo.Delete();
                                //task.DeleteFile = true;
                                kt1.ReportMail.Update(task);
                            }
                            Thread.Sleep(5000);
                        }
                    }
                    await kt1.SaveChangesAsync();
                }
            }
        }
    }
}
