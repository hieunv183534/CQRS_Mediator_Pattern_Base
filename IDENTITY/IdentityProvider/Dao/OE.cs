using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class OE
    {
        public string OECode { get; set; }
        public string CountryCode { get; set; }
        public string OEName { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
    }
}
