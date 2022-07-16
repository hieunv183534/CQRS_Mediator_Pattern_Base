using NOM.DomainGlobal._Base.Models;
using MediatR;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Queries
{
    public class ComboboxQuery : BasePagingModel, IRequest<PagingResultModel<ComboboxQueryResult>>
    {
        public long[] ValueSearch { get; set; }

        public string TextSearch { get; set; }
    }

}
