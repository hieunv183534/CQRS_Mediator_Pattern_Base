using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Province
    {
        public Province()
        {
            DeductionProvince = new HashSet<DeductionProvince>();
            District = new HashSet<District>();
            GroupReceiverObjectDetail = new HashSet<GroupReceiverObjectDetail>();
            Item = new HashSet<Item>();
            NearProvince = new HashSet<NearProvince>();
            ProvinceFreightRegion = new HashSet<ProvinceFreightRegion>();
            ProvinceInterconnectFromProvinceCodeNavigation = new HashSet<ProvinceInterconnect>();
            ProvinceInterconnectToProvinceCodeNavigation = new HashSet<ProvinceInterconnect>();
        }

        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string Description { get; set; }
        public string RegionCode { get; set; }
        public string ProvinceListCode { get; set; }
        public string ProvinceCombobox { get; set; }
        public string ProvinceNameSearch { get; set; }

        public virtual Region RegionCodeNavigation { get; set; }
        public virtual ICollection<DeductionProvince> DeductionProvince { get; set; }
        public virtual ICollection<District> District { get; set; }
        public virtual ICollection<GroupReceiverObjectDetail> GroupReceiverObjectDetail { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<NearProvince> NearProvince { get; set; }
        public virtual ICollection<ProvinceFreightRegion> ProvinceFreightRegion { get; set; }
        public virtual ICollection<ProvinceInterconnect> ProvinceInterconnectFromProvinceCodeNavigation { get; set; }
        public virtual ICollection<ProvinceInterconnect> ProvinceInterconnectToProvinceCodeNavigation { get; set; }
    }
}
