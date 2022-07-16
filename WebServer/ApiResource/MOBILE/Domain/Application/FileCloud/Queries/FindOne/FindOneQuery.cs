using MediatR;
using BCCP.DomainGlobal._Base.Models;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class FindOneQuery : BaseWhereModel, IRequest<FindOneQueryResult>
    {
        public long? Id { get; set; }

        public string? FileNumber { get; set; }

        public string? Url { get; set; }
    }

}
