using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Configuration
    {
        public Configuration()
        {
            POSConfiguration = new HashSet<POSConfiguration>();
            ServiceConfiguration = new HashSet<ServiceConfiguration>();
            ServicePOSConfiguration = new HashSet<ServicePOSConfiguration>();
        }

        public string ConfigCode { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigName { get; set; }

        public virtual ICollection<POSConfiguration> POSConfiguration { get; set; }
        public virtual ICollection<ServiceConfiguration> ServiceConfiguration { get; set; }
        public virtual ICollection<ServicePOSConfiguration> ServicePOSConfiguration { get; set; }
    }
}
