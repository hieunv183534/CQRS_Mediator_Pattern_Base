using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailValueAddedServiceProvinceFreight
    {
        public int DetailValueAddedServiceProvinceFreightId { get; set; }
        public string FromProvinceCode { get; set; }
        public string ToProvinceCode { get; set; }
        public int DomesticValueAddedServiceFreightStepId { get; set; }
        public double? Freight { get; set; }

        public virtual DomesticValueAddedServiceFreightStep DomesticValueAddedServiceFreightStep { get; set; }
    }
}
