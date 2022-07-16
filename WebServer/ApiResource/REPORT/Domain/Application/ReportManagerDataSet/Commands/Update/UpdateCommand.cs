using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using MediatR;
using System;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Commands
{
    public class UpdateCommand : IRequest<long>, IMapTo<Dao.Entities.ReportManagerDataSet>
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
            profile.CreateMap<UpdateCommand, Dao.Entities.ReportManagerDataSet>();
        }
    }
}
