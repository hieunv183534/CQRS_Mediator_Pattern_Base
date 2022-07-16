using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFarRegionFreightStep
    {
        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public double Freight { get; set; }
        public double FromWeight { get; set; }
        public double ToWeight { get; set; }
        public double FreightStep { get; set; }
        public byte CalculationMethod { get; set; }
        public string ItemTypeCode { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
    }
}
