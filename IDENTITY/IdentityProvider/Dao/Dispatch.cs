using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Dispatch
    {
        public long DispatchID { get; set; }
        public long PostBagID { get; set; }
        public long ItemID { get; set; }
        public byte Status { get; set; }
        public int? IndexNumber { get; set; }
        public int? Sheet { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string ConfirmedBy { get; set; }
        public string ItemCode { get; set; }

        public virtual Item Item { get; set; }
        public virtual PostBag PostBag { get; set; }
    }
}
