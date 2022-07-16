using AutoMapper;
using BCCP.DomainGlobal._Base.Mappings;
using BCCP.Common.Entities;
using FluentValidation;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class DowloadQueryValidation : AbstractValidator<DowloadQuery>
    {
        public DowloadQueryValidation()
        {
            
        }
    }
}