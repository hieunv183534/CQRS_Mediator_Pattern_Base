using MediatR;
using Newtonsoft.Json.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class TestDataQuery : IRequest<JObject>
    {
        public long? ReportId { get; set; }

        public string ReportCode { get; set; }

        public string ReportParams { get; set; }
    }

}

