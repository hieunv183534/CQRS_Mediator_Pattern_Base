using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimTimeProcessRule
    {
        public int ClaimTimeProcessCode { get; set; }
        public string MainFunction { get; set; }
        public string MainContent { get; set; }
        public string TimeRuleNormalCustomer { get; set; }
        public string TimeRuleBigCustomer { get; set; }
        public string RuleNo { get; set; }
        public DateTime? ValueDate { get; set; }
        public string Note { get; set; }
    }
}
