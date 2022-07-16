using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RevenueSharingItemType
    {
        public string ProvinceCode { get; set; }
        public DateTime ValueDate { get; set; }
        public double? InProvinceA { get; set; }
        public double? InProvinceB { get; set; }
        public double? OutProvince { get; set; }
        public double? International { get; set; }
        public string ItemType { get; set; }
        public string ServiceCode { get; set; }
    }
}
