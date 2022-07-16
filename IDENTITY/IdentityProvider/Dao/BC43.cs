using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC43
    {
        public BC43()
        {
            BC43Affair = new HashSet<BC43Affair>();
            BD21AffairResponse = new HashSet<BD21AffairResponse>();
        }

        public string BC43Code { get; set; }
        public string FromPosCode { get; set; }
        public string BC37Code { get; set; }
        public string ReasonCreateBC43 { get; set; }
        public int? BC43Type { get; set; }
        public string BC43Content { get; set; }
        public string BC43Creator { get; set; }
        public string BC43LeaderOfPos { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? BC37Index { get; set; }
        public string BC37FromPosCode { get; set; }
        public string BC37ToPosCode { get; set; }
        public string BC37TransportTypeCode { get; set; }
        public string BC37Date { get; set; }
        public string MailTripNumber { get; set; }
        public DateTime? MailTripDate { get; set; }
        public string MailTripStartingCode { get; set; }
        public string MailTripDestinationCode { get; set; }
        public string MailTripType { get; set; }
        public string MailTripServiceCode { get; set; }
        public string MailTripYear { get; set; }
        public string BC43ViewPOS { get; set; }
        public string BC43ReplyFromReceptionPOS { get; set; }
        public string AttachmentFileName { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? ExpiredDateBigCustomer { get; set; }
        public int? BC43SubType { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual BC43Type BC43TypeNavigation { get; set; }
        public virtual ICollection<BC43Affair> BC43Affair { get; set; }
        public virtual ICollection<BD21AffairResponse> BD21AffairResponse { get; set; }
    }
}
