using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightPerStockDay
    {
        public string DomesticValueAddedServiceFreightPerStockDayCode { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public double? FreightWeightPerStockDay { get; set; }
        public string DomesticFreightRuleCode { get; set; }

        public virtual VASUsing VASUsing { get; set; }
    }
}
