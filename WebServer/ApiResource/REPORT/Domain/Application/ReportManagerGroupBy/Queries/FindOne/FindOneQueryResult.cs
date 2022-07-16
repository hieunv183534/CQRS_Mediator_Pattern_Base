using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using System;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Queries
{
    public class FindOneQueryResult: IMapFrom<Dao.Entities.ReportManagerGroupBy>
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Key { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.Entities.ReportManagerGroupBy, FindOneQueryResult>();
        }
    }
}

