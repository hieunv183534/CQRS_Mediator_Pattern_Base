using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Transport_MBCSync
    {
        public string TransportCode { get; set; }
        public string TransportGroup { get; set; }
        public double? TotalLoad { get; set; }
        public byte? Status { get; set; }
        public string POSCode { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int? Partner { get; set; }
    }
}
