using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSVersion
    {
        public string POSCode { get; set; }
        public string MachineName { get; set; }
        public string BCCPVersion { get; set; }
        public string BCCPDBVersion { get; set; }
        public string WindowsVersion { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
