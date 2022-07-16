using System;
using System.Collections.Generic;

namespace NOM.Dao.Entities
{
    public partial class Document
    {
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNo { get; set; }
        public string Unit { get; set; }
        public DateTime IssueDdate { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
