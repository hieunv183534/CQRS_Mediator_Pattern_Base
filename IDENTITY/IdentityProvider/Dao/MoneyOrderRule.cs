using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MoneyOrderRule
    {
        public MoneyOrderRule()
        {
            MoneyOrderStep = new HashSet<MoneyOrderStep>();
            MoneyOrderValueAddedService = new HashSet<MoneyOrderValueAddedService>();
        }

        public string MoneyOrderRuleCode { get; set; }
        public DateTime ValueDate { get; set; }
        public string RuleNo { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual ICollection<MoneyOrderStep> MoneyOrderStep { get; set; }
        public virtual ICollection<MoneyOrderValueAddedService> MoneyOrderValueAddedService { get; set; }
    }
}
