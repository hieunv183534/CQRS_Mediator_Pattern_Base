using System;
using System.Collections.Generic;
using System.Text;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class UploadCommandResult
    {
        public string FileNumber { get; set; }

        public string FileName { get; set; }

        public decimal? FileSize { get; set; }

        public string FileExtension { get; set; }

        public string FileUrl { get; set; }
    }
}
