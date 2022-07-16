using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RevenueSharing
    {
        public string ServiceCode { get; set; }
        public string ItemCode { get; set; }
        public string POSCode { get; set; }
        public string PhaseCode { get; set; }
        public double? Revenue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ServicePhase ServicePhase { get; set; }
    }
}
