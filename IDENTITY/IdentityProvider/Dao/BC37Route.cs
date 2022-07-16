using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC37Route
    {
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string AcceptedPOSCode { get; set; }
        public byte? Type { get; set; }
    }
}
