using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RegionGroup
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string ListProvince { get; set; }
        public string ListDistrict { get; set; }
        public bool Contrary { get; set; }
        public string ListCommune { get; set; }
        public string ListRegion { get; set; }
        public string NameSearch { get; set; }
        public string ListObject { get; set; }
    }
}
