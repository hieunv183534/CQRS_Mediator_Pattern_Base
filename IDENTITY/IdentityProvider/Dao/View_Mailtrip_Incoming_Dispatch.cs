using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_Mailtrip_Incoming_Dispatch
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public long PostBagID { get; set; }
        public long MailtripID { get; set; }
    }
}
