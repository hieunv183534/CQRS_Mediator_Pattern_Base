using AutoMapper;
using NOM.REPORT.Domain._Base.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class UpdateCommand : IRequest<long>, IMapTo<Dao.Entities.ReportManager>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string ParentTag { get; set; }
        public int Type { get; set; }
        public string? FileTemplate { get; set; }
        public string DataSource { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }

        public List<ReportManagerParamModel> Params { get; set; }
        public List<ReportManagerDataSetModal> ReportManagerDataSet { get; set; }
        public List<ReportManagerGroupByModel> ReportManagerGroupBy { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReportManagerParamModel, Dao.Entities.ReportManagerParam>();
            profile.CreateMap<ReportManagerDataSetModal, Dao.Entities.ReportManagerDataSet>();
            profile.CreateMap<ReportManagerGroupByModel, Dao.Entities.ReportManagerGroupBy>();
            profile.CreateMap<UpdateCommand, Dao.Entities.ReportManager>()
                .ForMember(s => s.ReportManagerParam, otp => otp.MapFrom(s => s.Params));
        }

        public class ReportManagerParamModel
        {
            public long? Id { get; set; }
            public long? ReportManagerId { get; set; }
            public string Name { get; set; }
            public int DataType { get; set; }
            public int InputType { get; set; }
            public string DataDefault { get; set; }
            public string? DataFileDefault { get; set; }
        }

        public partial class ReportManagerDataSetModal
        {
            public long? Id { get; set; }
            public long? ReportManagerId { get; set; }
            public string Name { get; set; }
            public int SourceType { get; set; }
            public int DataType { get; set; }
            public string DataValue { get; set; }
            public string ConnectString { get; set; }
        }

        public partial class ReportManagerGroupByModel
        {
            public long? Id { get; set; }
            public long? ReportManagerId { get; set; }
            public string Name { get; set; }
            public long? DataSetId { get; set; }
            public string Key { get; set; }
        }
    }
}


