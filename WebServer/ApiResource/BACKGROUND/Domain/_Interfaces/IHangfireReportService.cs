using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NOM.BACKGROUND.Domain._Interfaces
{
    public interface IHangfireReportService
    {
        Task CalReport(NOM.Common.Enums.ReportType reportType);

        Task SendMailReoprt();
    }
}
