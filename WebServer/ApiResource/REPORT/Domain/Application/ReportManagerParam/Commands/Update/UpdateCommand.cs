using AutoMapper;
using MediatR;
using System;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Commands
{
    public class UpdateCommand : IRequest<long>
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public int InputType { get; set; }
        public string DataDefault { get; set; }
        public byte[] DataFileDefault { get; set; }
    }
}


