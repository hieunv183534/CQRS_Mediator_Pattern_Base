using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using System;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class GetPagingQueryResult : IMapFrom<Dao.Entities.ReportManager>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string ParentTag { get; set; }
        public int Type { get; set; }
        public string FileTemplate { get; set; }
        public string DataSource { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }
     
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.Entities.ReportManager, GetPagingQueryResult>();
        }
    }
}
