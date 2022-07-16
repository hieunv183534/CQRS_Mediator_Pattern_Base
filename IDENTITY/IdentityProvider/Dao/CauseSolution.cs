using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CauseSolution
    {
        public string CauseCode { get; set; }
        public string SolutionCode { get; set; }

        public virtual Cause CauseCodeNavigation { get; set; }
        public virtual Solution SolutionCodeNavigation { get; set; }
    }
}
