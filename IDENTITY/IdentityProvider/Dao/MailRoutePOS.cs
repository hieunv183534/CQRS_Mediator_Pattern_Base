using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRoutePOS
    {
        public string MailRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string OnMailRoutePOSCode { get; set; }
        public byte? POSOrder { get; set; }
        public string MailRouteScheduleCode { get; set; }
        public bool Type { get; set; }
        public DateTime? IncomingTime { get; set; }
        public DateTime? OutgoingTime { get; set; }

        public virtual MailRouteSchedule MailRouteSchedule { get; set; }
        public virtual POS OnMailRoutePOSCodeNavigation { get; set; }
    }
}
