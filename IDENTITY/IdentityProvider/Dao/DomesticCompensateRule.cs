using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticCompensateRule
    {
        public string DomesitcCompensateRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public DateTime ValueDate { get; set; }
        public string RuleNumber { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
