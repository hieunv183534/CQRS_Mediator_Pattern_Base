using AutoMapper;
using MediatR;
using System;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class ChangeParentCommand : IRequest<long>
    {
        public long Id { get; set; }
        public long? IdParent { get; set; }
    }
}


