using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class QualityTargetRule
    {
        public QualityTargetRule()
        {
            PhaseQualityTarget = new HashSet<PhaseQualityTarget>();
            WholeQualityTarget = new HashSet<WholeQualityTarget>();
        }

        public string QualityTargetRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public string RuleNo { get; set; }
        public DateTime ValueDate { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<PhaseQualityTarget> PhaseQualityTarget { get; set; }
        public virtual ICollection<WholeQualityTarget> WholeQualityTarget { get; set; }
    }
}
