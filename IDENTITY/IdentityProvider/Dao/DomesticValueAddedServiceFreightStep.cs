using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticValueAddedServiceFreightStep
    {
        public DomesticValueAddedServiceFreightStep()
        {
            DetailValueAddedServiceProvinceFreight = new HashSet<DetailValueAddedServiceProvinceFreight>();
            DetailValueAddedServiceRegionFreight = new HashSet<DetailValueAddedServiceRegionFreight>();
        }

        public int DomesticValueAddedServiceFreightStepId { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public double FromWeight { get; set; }
        public double ToWeight { get; set; }
        public string ItemTypeCode { get; set; }
        public double FreightStep { get; set; }
        public byte CalculationMethod { get; set; }
        public bool? IsBatch { get; set; }
        public double? InternalProvinceFreight { get; set; }
        public string ValueAddedServiceCode { get; set; }

        public virtual DomesticFreightRule DomesticValueAddedServiceFreightStepNavigation { get; set; }
        public virtual ICollection<DetailValueAddedServiceProvinceFreight> DetailValueAddedServiceProvinceFreight { get; set; }
        public virtual ICollection<DetailValueAddedServiceRegionFreight> DetailValueAddedServiceRegionFreight { get; set; }
    }
}
