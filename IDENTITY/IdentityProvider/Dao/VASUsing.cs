using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class VASUsing
    {
        public VASUsing()
        {
            AffairServedFreight = new HashSet<AffairServedFreight>();
            AffairValueAddedService = new HashSet<AffairValueAddedService>();
            DomesticSurchangeValueAddedServicePercent = new HashSet<DomesticSurchangeValueAddedServicePercent>();
            DomesticValueAddedServiceFreightPerMoney = new HashSet<DomesticValueAddedServiceFreightPerMoney>();
            DomesticValueAddedServiceFreightPerStockDay = new HashSet<DomesticValueAddedServiceFreightPerStockDay>();
            DomesticValueAddedServiceFreightPerTotalItem = new HashSet<DomesticValueAddedServiceFreightPerTotalItem>();
            DomesticValueAddedServiceFreightPerTotalItemInBatch = new HashSet<DomesticValueAddedServiceFreightPerTotalItemInBatch>();
            DomesticValueAddedServiceFreightTotalWeight = new HashSet<DomesticValueAddedServiceFreightTotalWeight>();
            ValueAddedServiceItem = new HashSet<ValueAddedServiceItem>();
            ValueAddedServicePhase = new HashSet<ValueAddedServicePhase>();
        }

        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public byte? CalculationMethod { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ValueAddedService ValueAddedServiceCodeNavigation { get; set; }
        public virtual ICollection<AffairServedFreight> AffairServedFreight { get; set; }
        public virtual ICollection<AffairValueAddedService> AffairValueAddedService { get; set; }
        public virtual ICollection<DomesticSurchangeValueAddedServicePercent> DomesticSurchangeValueAddedServicePercent { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPerMoney> DomesticValueAddedServiceFreightPerMoney { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPerStockDay> DomesticValueAddedServiceFreightPerStockDay { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPerTotalItem> DomesticValueAddedServiceFreightPerTotalItem { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPerTotalItemInBatch> DomesticValueAddedServiceFreightPerTotalItemInBatch { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightTotalWeight> DomesticValueAddedServiceFreightTotalWeight { get; set; }
        public virtual ICollection<ValueAddedServiceItem> ValueAddedServiceItem { get; set; }
        public virtual ICollection<ValueAddedServicePhase> ValueAddedServicePhase { get; set; }
    }
}
