using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRouteService
    {
        public string ServiceCode { get; set; }
        public string MailRouteCode { get; set; }
        public string FromPOSCode { get; set; }

        public virtual MailRoute MailRoute { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
