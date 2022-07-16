using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRouteSchedule
    {
        public MailRouteSchedule()
        {
            MailRoutePOS = new HashSet<MailRoutePOS>();
            MailtripTransport = new HashSet<MailtripTransport>();
        }

        public string MailRouteScheduleCode { get; set; }
        public string MailRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string Description { get; set; }
        public string MailRouteScheduleName { get; set; }

        public virtual MailRoute MailRoute { get; set; }
        public virtual ICollection<MailRoutePOS> MailRoutePOS { get; set; }
        public virtual ICollection<MailtripTransport> MailtripTransport { get; set; }
    }
}
