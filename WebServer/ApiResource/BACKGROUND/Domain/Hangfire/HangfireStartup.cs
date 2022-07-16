using NOM.BACKGROUND.Domain._Interfaces;
using NOM.BACKGROUND.Domain.Interfaces;
using Hangfire;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.BACKGROUND.Domain.Hangfire
{
    public class HangfireStartup : IHostedService
    {
        private IRecurringJobManager _recurringJobManager;
        public HangfireStartup(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //setup schedule 2 phut chay 1 lan
            // cấu hình time theo trang https://www.freeformatter.com/cron-expression-generator-quartz.html
            //_recurringJobManager.AddOrUpdate<IHangfireExampleService>("test", x => x.test("abc"), "0 */2 * ? * *");

            //Ngay
            _recurringJobManager.AddOrUpdate<IHangfireReportService>("CalReportDay", x => x.CalReport(NOM.Common.Enums.ReportType.Ngay), "0 30 0 ? * *");
            //Tuan
            _recurringJobManager.AddOrUpdate<IHangfireReportService>("CalReportWeek", x => x.CalReport(NOM.Common.Enums.ReportType.Tuan), "* 45 0 ? * SUN");
            //Thang
            _recurringJobManager.AddOrUpdate<IHangfireReportService>("CalReportThang", x => x.CalReport(NOM.Common.Enums.ReportType.Thang), "0 30 0 1 * ?");
            //Quy
            _recurringJobManager.AddOrUpdate<IHangfireReportService>("CalReportQuy", x => x.CalReport(NOM.Common.Enums.ReportType.Quy), "* 30 0 1 JAN,APR,JUL,OCT ?");
            //sen main
            _recurringJobManager.AddOrUpdate<IHangfireReportService>("SendMailReport", x => x.SendMailReoprt(), "* 30 7 ? * *");

            return Task.CompletedTask;


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
