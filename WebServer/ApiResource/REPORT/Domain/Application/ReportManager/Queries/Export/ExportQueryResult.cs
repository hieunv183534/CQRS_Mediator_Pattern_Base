using AutoMapper;
using System;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class ExportQueryResult
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}

