using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CauseCustomer
    {
        public string CauseCode { get; set; }
        public string CustomerCode { get; set; }

        public virtual Cause CauseCodeNavigation { get; set; }
        public virtual Customer CustomerCodeNavigation { get; set; }
    }
}
