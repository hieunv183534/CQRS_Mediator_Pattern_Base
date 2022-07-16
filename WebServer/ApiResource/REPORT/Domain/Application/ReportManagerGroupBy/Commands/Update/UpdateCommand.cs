using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using MediatR;
using System;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Commands
{
    public class UpdateCommand : IRequest<long>, IMapTo<Dao.Entities.ReportManagerGroupBy>
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public long DataSetId { get; set; }
        public string Key { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCommand, Dao.Entities.ReportManagerGroupBy>();
        }
    }
}
