using MediatR;
using BCCP.DomainGlobal._Base.Models;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class DowloadQuery : IRequest<DowloadQueryResult>
    {
        public long? Id { get; set; }

        public string? FileNumber { get; set; }

        public string? Url { get; set; }
    }

}
