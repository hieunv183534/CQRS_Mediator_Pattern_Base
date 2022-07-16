using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class LetterMoneyOrderRule
    {
        public LetterMoneyOrderRule()
        {
            LetterMoneyOrder = new HashSet<LetterMoneyOrder>();
        }

        public string LetterMoneyOrderRuleCode { get; set; }
        public DateTime ValueDate { get; set; }
        public string RuleNo { get; set; }
        public string Description { get; set; }
        public string ServiceCode { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<LetterMoneyOrder> LetterMoneyOrder { get; set; }
    }
}
