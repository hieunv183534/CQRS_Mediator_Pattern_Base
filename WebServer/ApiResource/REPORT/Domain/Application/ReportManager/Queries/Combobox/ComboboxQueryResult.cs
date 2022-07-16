using AutoMapper;
using NOM.DomainGlobal._Base.Models;
using NOM.REPORT.Domain._Base.Mappings;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class ComboboxQueryResult : ComboboxModel<long>, IMapFrom<Dao.Entities.ReportManager>
    {

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.Entities.ReportManager, ComboboxQueryResult>()
                //.ForMember(d => d.Text, opt => opt.MapFrom(s => s.ColText))
			    .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id));
        }
    }
}
