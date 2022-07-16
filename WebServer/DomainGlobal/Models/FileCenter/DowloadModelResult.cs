using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal.Models.FileCenter
{
    public class DowloadModelResult
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
