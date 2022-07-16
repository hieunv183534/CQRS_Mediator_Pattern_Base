using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Region
    {
        public Region()
        {
            NearProvince = new HashSet<NearProvince>();
            NearRegionNearRegionCodeNavigation = new HashSet<NearRegion>();
            NearRegionOriginalRegionCodeNavigation = new HashSet<NearRegion>();
            Province = new HashSet<Province>();
        }

        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string Description { get; set; }
        public string RegionNameSearch { get; set; }

        public virtual ICollection<NearProvince> NearProvince { get; set; }
        public virtual ICollection<NearRegion> NearRegionNearRegionCodeNavigation { get; set; }
        public virtual ICollection<NearRegion> NearRegionOriginalRegionCodeNavigation { get; set; }
        public virtual ICollection<Province> Province { get; set; }
    }
}
