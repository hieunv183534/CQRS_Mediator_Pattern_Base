using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ExchangeRelationship
    {
        public string FromPOSCode { get; set; }
        public string OnMailRoutePOSCode { get; set; }
        public string MailRouteCode { get; set; }
        public string ExchangePOSCode { get; set; }
        public string MailRouteScheduleCode { get; set; }
        public bool? Type { get; set; }
        public string ServiceCode { get; set; }
        public byte? ResetType { get; set; }
        public bool? IsDiscreteMailRoute { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string OnMailRoutePOSName { get; set; }
        public string ExchangePOSName { get; set; }
        public string ExchangeID { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
