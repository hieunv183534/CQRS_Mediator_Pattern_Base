using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal._Base.Models
{
    public class FromSubmissionEmailModel
    {
        public string note { get; set; }
        public string approverName { get; set; }
        public string employeeName { get; set; }
        public DateTime createDate { get; set; }
    }
}
