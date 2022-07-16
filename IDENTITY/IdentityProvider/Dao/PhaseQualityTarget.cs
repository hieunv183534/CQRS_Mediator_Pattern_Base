using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PhaseQualityTarget
    {
        public string PhaseCode { get; set; }
        public string ServiceCode { get; set; }
        public string RegionTypeCode { get; set; }
        public double TargetDate { get; set; }
        public string QualityTargetRuleCode { get; set; }

        public virtual QualityTargetRule QualityTargetRule { get; set; }
        public virtual RegionType RegionTypeCodeNavigation { get; set; }
        public virtual ServicePhase ServicePhase { get; set; }
    }
}
