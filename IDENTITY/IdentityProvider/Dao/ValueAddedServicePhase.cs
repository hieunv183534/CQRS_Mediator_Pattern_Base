using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ValueAddedServicePhase
    {
        public ValueAddedServicePhase()
        {
            RangeValueAddedServicePhase = new HashSet<RangeValueAddedServicePhase>();
        }

        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string PhaseCode { get; set; }

        public virtual Phase PhaseCodeNavigation { get; set; }
        public virtual VASUsing VASUsing { get; set; }
        public virtual ICollection<RangeValueAddedServicePhase> RangeValueAddedServicePhase { get; set; }
    }
}
