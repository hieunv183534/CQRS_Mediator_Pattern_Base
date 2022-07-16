using NOM.DomainGlobal._Base.Models;
using MediatR;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Queries
{
    public class ComboboxQuery : BasePagingModel, IRequest<PagingResultModel<ComboboxQueryResult>>
    {
        public long[] ValueSearch { get; set; }

        public string TextSearch { get; set; }
    }

}
