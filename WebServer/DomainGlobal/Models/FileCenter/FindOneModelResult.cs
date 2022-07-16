using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal.Models.FileCenter
{
    public class FindOneModelResult
    {
        public long Id { get; set; }
        public Guid FileNumber { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int FileType { get; set; }
        public decimal? FileSize { get; set; }
        public long? ParentId { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Url { get; set; }
    }
}
