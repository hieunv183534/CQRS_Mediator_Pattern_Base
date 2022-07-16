using AutoMapper;
using NOM.Common.Entities;
using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class FindOneQueryValidation : AbstractValidator<FindOneQuery>
    {
        public FindOneQueryValidation()
        {
            
        }
    }
}

