using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class District
    {
        public District()
        {
            Commune = new HashSet<Commune>();
            DistrictFreightRegion = new HashSet<DistrictFreightRegion>();
            DomesticFarRegion = new HashSet<DomesticFarRegion>();
            GroupReceiverObjectDetail = new HashSet<GroupReceiverObjectDetail>();
            Item = new HashSet<Item>();
        }

        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string Description { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCombobox { get; set; }
        public string DistrictNameSearch { get; set; }

        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual ICollection<Commune> Commune { get; set; }
        public virtual ICollection<DistrictFreightRegion> DistrictFreightRegion { get; set; }
        public virtual ICollection<DomesticFarRegion> DomesticFarRegion { get; set; }
        public virtual ICollection<GroupReceiverObjectDetail> GroupReceiverObjectDetail { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
