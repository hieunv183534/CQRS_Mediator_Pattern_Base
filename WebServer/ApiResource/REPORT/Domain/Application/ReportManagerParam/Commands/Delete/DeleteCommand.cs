using AutoMapper;
using MediatR;
using System;
using System.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Commands
{
    public class DeleteCommand : IRequest<long[]>
    {
        public long[] Id { get; set; }
    }
}


