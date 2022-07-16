using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRoute_MBCSync
    {
        public string MailRouteCode { get; set; }
        public string TransportTypeCode { get; set; }
        public string MailRouteName { get; set; }
        public string Description { get; set; }
        public string MailRouteTypeCode { get; set; }
        public string FromPOSCode { get; set; }
        public byte? MailTripFrequencePerDay { get; set; }
    }
}
