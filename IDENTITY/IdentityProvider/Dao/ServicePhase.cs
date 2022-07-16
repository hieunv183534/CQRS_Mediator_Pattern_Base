using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServicePhase
    {
        public ServicePhase()
        {
            PhaseQualityTarget = new HashSet<PhaseQualityTarget>();
            RevenueSharing = new HashSet<RevenueSharing>();
        }

        public string PhaseCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual Phase PhaseCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<PhaseQualityTarget> PhaseQualityTarget { get; set; }
        public virtual ICollection<RevenueSharing> RevenueSharing { get; set; }
    }
}
