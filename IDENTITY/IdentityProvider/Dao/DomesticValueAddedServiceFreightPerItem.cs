using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightPerItem
    {
        public int DomesticValueAddedServiceFreightPerItemCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public double? FreightPerItem { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public double? MinimumFreight { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
    }
}
