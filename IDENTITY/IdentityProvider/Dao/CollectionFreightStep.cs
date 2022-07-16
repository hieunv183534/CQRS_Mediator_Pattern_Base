using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CollectionFreightStep
    {
        public string CollectionFreightStepCode { get; set; }
        public string ServiceCode { get; set; }
        public double FromWeight { get; set; }
        public double ToWeight { get; set; }
        public double Freight { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
