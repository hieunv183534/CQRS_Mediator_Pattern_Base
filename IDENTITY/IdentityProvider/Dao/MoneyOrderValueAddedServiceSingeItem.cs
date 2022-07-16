using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MoneyOrderValueAddedServiceSingeItem
    {
        public string ValueAddedServiceCode { get; set; }
        public string MoneyOrderRuleCode { get; set; }
        public string MoneyOrderValueAddedServiceSingeItemCode { get; set; }
        public double? Freight { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual MoneyOrderValueAddedService MoneyOrderValueAddedService { get; set; }
    }
}
