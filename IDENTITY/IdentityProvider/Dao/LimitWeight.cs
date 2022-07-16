using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class LimitWeight
    {
        public string CountryCode { get; set; }
        public string ServiceCode { get; set; }
        public double? MaximumWeightAir { get; set; }
        public double? MaximumWeightSurface { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
