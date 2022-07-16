using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimEmails
    {
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MailCc { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string CreatedPerson { get; set; }
        public string CreatedPosCode { get; set; }
        public string Notes { get; set; }
        public string ClaimNumber { get; set; }
        public string RecevingClaimPOSCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
