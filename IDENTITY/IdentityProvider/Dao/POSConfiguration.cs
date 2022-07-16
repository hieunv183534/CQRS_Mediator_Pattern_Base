using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSConfiguration
    {
        public string POSCode { get; set; }
        public string ConfigCode { get; set; }
        public string ConfigValue { get; set; }

        public virtual Configuration ConfigCodeNavigation { get; set; }
        public virtual POS POSCodeNavigation { get; set; }
    }
}
