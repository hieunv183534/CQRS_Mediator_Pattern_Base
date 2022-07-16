using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailValueAddedServiceRegionFreight
    {
        public int DetailValueAddedServiceRegionFreightId { get; set; }
        public string FromFreightRegionCode { get; set; }
        public string ToFreightRegionCode { get; set; }
        public int DomesticValueAddedServiceFreightStepId { get; set; }
        public double? Freight { get; set; }

        public virtual DomesticValueAddedServiceFreightStep DomesticValueAddedServiceFreightStep { get; set; }
    }
}
