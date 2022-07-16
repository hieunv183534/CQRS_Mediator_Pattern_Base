using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Server
    {
        public string ServerCode { get; set; }
        public byte Type { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
        public bool? IsHeadQuarter { get; set; }
        public bool? IsActive { get; set; }
        public string POSCode { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
    }
}
