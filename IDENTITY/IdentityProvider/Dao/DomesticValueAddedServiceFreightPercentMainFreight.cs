using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightPercentMainFreight
    {
        public int Id { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public double? PercentMainFreight { get; set; }
        public int DomesticFreightRuleId { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
    }
}
