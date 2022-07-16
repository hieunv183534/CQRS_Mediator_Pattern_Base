using AutoMapper;
using NOM.Common.Entities;
using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Queries
{
    public class GetPagingQueryValidation : AbstractValidator<GetPagingQuery>
    {
        public GetPagingQueryValidation()
        {
            
        }
    }
}
