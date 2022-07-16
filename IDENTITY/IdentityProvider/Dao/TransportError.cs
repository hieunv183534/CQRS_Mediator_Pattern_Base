using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TransportError
    {
        public long TransportErrorID { get; set; }
        public string TransportCode { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public double? Long { get; set; }
        public double? Lat { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual Transport TransportCodeNavigation { get; set; }
    }
}
