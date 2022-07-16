using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticServiceSurchange
    {
        public string DomesticServiceSurchangeCode { get; set; }
        public string ServiceCode { get; set; }
        public DateTime ValueDate { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchangeFreightPercent { get; set; }
        public string Notes { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double? ValueAddedServiceFreightPercent { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
