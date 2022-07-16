using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightPerTotalItemInBatch
    {
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double? FromNumberOfItem { get; set; }
        public double? ToNumberOfItem { get; set; }
        public double? Freight { get; set; }
        public double? MinimumFreight { get; set; }
        public string DomesticValueAddedServiceFreightPerTotalItemInBatchCode { get; set; }

        public virtual VASUsing VASUsing { get; set; }
    }
}
