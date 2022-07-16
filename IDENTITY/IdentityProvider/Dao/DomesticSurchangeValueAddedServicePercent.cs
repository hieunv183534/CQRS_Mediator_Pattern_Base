using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticSurchangeValueAddedServicePercent
    {
        public string DomesticFreightRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public double? FuelSurchangePercent { get; set; }
        public DateTime ValueDate { get; set; }

        public virtual VASUsing VASUsing { get; set; }
    }
}
