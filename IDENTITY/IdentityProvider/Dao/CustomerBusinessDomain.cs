using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CustomerBusinessDomain
    {
        public string POSCode { get; set; }
        public string CustomerCode { get; set; }
        public string BusinessDomainCode { get; set; }

        public virtual BusinessDomain BusinessDomainCodeNavigation { get; set; }
    }
}
