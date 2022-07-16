using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripItem
    {
        public long MailtripID { get; set; }
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string ExtendServiceCode { get; set; }
        public string Year { get; set; }
        public string MailtripNumber { get; set; }
        public byte? Status { get; set; }
        public int? Sheet { get; set; }
        public int? IndexNumber { get; set; }

        public virtual Item Item { get; set; }
        public virtual MailtripDelivery Mailtrip { get; set; }
    }
}
