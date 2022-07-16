using AutoMapper;
using AutoMapper.QueryableExtensions;
using NOM.Common.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class ExportQuery : IRequest<ExportQueryResult>
    {
        public long? ReportId { get; set; }

        public string ReportCode { get; set; }

        public string ReportParams { get; set; }

        public int Type { get; set; }

        public string FileName { get; set; }
    }

}

