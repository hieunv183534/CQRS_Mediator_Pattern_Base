using AutoMapper;
using NOM.Common.Entities;
using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Queries
{
    public class GetCountQueryValidation : AbstractValidator<GetCountQuery>
    {
        public GetCountQueryValidation()
        {
            
        }
    }
}
