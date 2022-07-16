using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomessticFreightRuleVASUsing
    {
        public string ServiceCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public byte? CalculationMethod { get; set; }
    }
}
