using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripPostBagEmpty
    {
        public long MailtripID { get; set; }
        public string PostBagTypeCode { get; set; }
        public int? Amount { get; set; }

        public virtual Mailtrip Mailtrip { get; set; }
        public virtual PostBagType PostBagTypeCodeNavigation { get; set; }
    }
}
