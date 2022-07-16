using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class SolutionCustomer
    {
        public string SolutionCode { get; set; }
        public string CustomerCode { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; }
        public virtual Solution SolutionCodeNavigation { get; set; }
    }
}
