using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class NearRegion
    {
        public string OriginalRegionCode { get; set; }
        public string NearRegionCode { get; set; }

        public virtual Region NearRegionCodeNavigation { get; set; }
        public virtual Region OriginalRegionCodeNavigation { get; set; }
    }
}
