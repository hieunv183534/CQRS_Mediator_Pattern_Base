using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverMailtripDelivery
    {
        public long ShiftHandoverID { get; set; }
        public long MailtripID { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual MailtripDelivery Mailtrip { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
