using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC37BCCP
    {
        public int BC37Index { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string TransportTypeCode { get; set; }
        public string BC37Date { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
