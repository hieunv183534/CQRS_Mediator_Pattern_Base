using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRouteSchedule_MBCSync
    {
        public string MailRouteScheduleCode { get; set; }
        public string MailRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string Description { get; set; }
        public string MailRouteScheduleName { get; set; }
    }
}
