using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using System;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Queries
{
    public class FindOneQueryResult: IMapFrom<Dao.Entities.ReportManagerDataSet>
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public int SourceType { get; set; }
        public int DataType { get; set; }
        public string DataValue { get; set; }
        public string ConnectString { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.Entities.ReportManagerDataSet, FindOneQueryResult>();
        }
    }
}

