using System;

namespace NOM._Base.Models
{
    public class FromSubmissionEmailModel
    {
        public string note { get; set; }
        public string approverName { get; set; }
        public string employeeName { get; set; }
        public DateTime createDate { get; set; }
    }
}