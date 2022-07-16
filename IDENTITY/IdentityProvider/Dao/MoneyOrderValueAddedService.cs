using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MoneyOrderValueAddedService
    {
        public MoneyOrderValueAddedService()
        {
            MoneyOrderValueAddedServiceSingeItem = new HashSet<MoneyOrderValueAddedServiceSingeItem>();
        }

        public string ValueAddedServiceCode { get; set; }
        public string MoneyOrderRuleCode { get; set; }
        public byte CalculationMethod { get; set; }
        public double? PerItem { get; set; }
        public double? PercentMoney { get; set; }
        public double? MinimumMoney { get; set; }
        public double? MaximumMoney { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual MoneyOrderRule MoneyOrderRule { get; set; }
        public virtual ValueAddedService ValueAddedServiceCodeNavigation { get; set; }
        public virtual ICollection<MoneyOrderValueAddedServiceSingeItem> MoneyOrderValueAddedServiceSingeItem { get; set; }
    }
}
