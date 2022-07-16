using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairServedFreight
    {
        public byte AffairTypeCode { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public byte ItemStatusCode { get; set; }
        public string RangeCode { get; set; }
        public double Freight { get; set; }

        public virtual Range RangeCodeNavigation { get; set; }
        public virtual VASUsing VASUsing { get; set; }
    }
}
