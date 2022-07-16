using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Phase
    {
        public Phase()
        {
            InverseParentPhaseCodeNavigation = new HashSet<Phase>();
            ServicePhase = new HashSet<ServicePhase>();
            ValueAddedServicePhase = new HashSet<ValueAddedServicePhase>();
        }

        public string PhaseCode { get; set; }
        public string PhaseName { get; set; }
        public string Description { get; set; }
        public string ParentPhaseCode { get; set; }

        public virtual Phase ParentPhaseCodeNavigation { get; set; }
        public virtual ICollection<Phase> InverseParentPhaseCodeNavigation { get; set; }
        public virtual ICollection<ServicePhase> ServicePhase { get; set; }
        public virtual ICollection<ValueAddedServicePhase> ValueAddedServicePhase { get; set; }
    }
}
