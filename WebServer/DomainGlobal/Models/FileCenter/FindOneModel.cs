using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal.Models.FileCenter
{
    public class FindOneModel
    {
        public long? Id { get; set; }

        public string? FileNumber { get; set; }

        public string? Url { get; set; }
    }
}
