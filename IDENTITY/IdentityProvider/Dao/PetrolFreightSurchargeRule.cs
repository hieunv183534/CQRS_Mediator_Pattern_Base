using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PetrolFreightSurchargeRule
    {
        public string PetrolFreightSurchargeRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public string RuleNo { get; set; }
        public DateTime ValueDate { get; set; }
    }
}
