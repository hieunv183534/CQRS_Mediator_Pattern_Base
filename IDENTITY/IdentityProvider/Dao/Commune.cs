using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Commune
    {
        public Commune()
        {
            CommuneFreightRegion = new HashSet<CommuneFreightRegion>();
            DeliveryScoping = new HashSet<DeliveryScoping>();
            DomesticFarRegionCommune = new HashSet<DomesticFarRegionCommune>();
            GroupReceiverObjectDetail = new HashSet<GroupReceiverObjectDetail>();
            Item = new HashSet<Item>();
            ServiceSupplying = new HashSet<ServiceSupplying>();
            Unit = new HashSet<Unit>();
        }

        public string CommuneCode { get; set; }
        public string CommuneName { get; set; }
        public string DistrictCode { get; set; }
        public string CommuneCombobox { get; set; }
        public string Description { get; set; }
        public string CommuneNameSearch { get; set; }

        public virtual District DistrictCodeNavigation { get; set; }
        public virtual ICollection<CommuneFreightRegion> CommuneFreightRegion { get; set; }
        public virtual ICollection<DeliveryScoping> DeliveryScoping { get; set; }
        public virtual ICollection<DomesticFarRegionCommune> DomesticFarRegionCommune { get; set; }
        public virtual ICollection<GroupReceiverObjectDetail> GroupReceiverObjectDetail { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<ServiceSupplying> ServiceSupplying { get; set; }
        public virtual ICollection<Unit> Unit { get; set; }
    }
}
