using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightPerMoney
    {
        public string DomesticValueAddedServiceFreightPerMoneyCode { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double? PercentMoney { get; set; }
        public double? MinimumMoney { get; set; }
        public double? MaximumMoney { get; set; }
        public double? ReturnMoney { get; set; }

        public virtual VASUsing VASUsing { get; set; }
    }
}
