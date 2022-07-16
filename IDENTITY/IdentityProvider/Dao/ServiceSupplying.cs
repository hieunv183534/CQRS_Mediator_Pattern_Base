using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServiceSupplying
    {
        public string CommuneCode { get; set; }
        public string POSCode { get; set; }

        public virtual Commune CommuneCodeNavigation { get; set; }
        public virtual POS POSCodeNavigation { get; set; }
    }
}
