using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CommunicationConfig
    {
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Description { get; set; }
    }
}
