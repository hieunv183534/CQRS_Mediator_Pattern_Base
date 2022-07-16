using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class NearProvince
    {
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }

        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual Region RegionCodeNavigation { get; set; }
    }
}
