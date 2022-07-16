using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Driver
    {
        public Driver()
        {
            MailtripTransport = new HashSet<MailtripTransport>();
        }

        public string DriverCode { get; set; }
        public string DriverName { get; set; }
        public string POSCode { get; set; }
        public bool? IsEcort { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<MailtripTransport> MailtripTransport { get; set; }
    }
}
