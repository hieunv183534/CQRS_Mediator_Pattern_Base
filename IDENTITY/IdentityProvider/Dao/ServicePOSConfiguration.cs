using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServicePOSConfiguration
    {
        public string POSCode { get; set; }
        public string ServiceCode { get; set; }
        public string ConfigCode { get; set; }
        public string ConfigValue { get; set; }

        public virtual Configuration ConfigCodeNavigation { get; set; }
        public virtual POS POSCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
