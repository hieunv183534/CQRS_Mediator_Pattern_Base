using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using System;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Queries
{
    public class GetPagingQueryResult : IMapFrom<Dao.Entities.ReportManagerParam>
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public int InputType { get; set; }
        public string DataDefault { get; set; }
        public byte[] DataFileDefault { get; set; }
     
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.Entities.ReportManagerParam, GetPagingQueryResult>();
        }
    }
}
