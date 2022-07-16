using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RangeValueAddedServicePhase
    {
        public string RangeCode { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string PhaseCode { get; set; }

        public virtual Range RangeCodeNavigation { get; set; }
        public virtual ValueAddedServicePhase ValueAddedServicePhase { get; set; }
    }
}
