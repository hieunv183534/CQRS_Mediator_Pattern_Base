using System;
using System.Collections.Generic;
using System.Text;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class DowloadQueryResult
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
