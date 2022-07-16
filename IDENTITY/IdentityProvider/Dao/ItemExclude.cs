using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemExclude
    {
        public long ExcludeID { get; set; }
        public long ItemID { get; set; }
        public long PostBagID { get; set; }
        public string Reason { get; set; }
        public string ItemCode { get; set; }
        public long? ShifthandoverID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual Item Item { get; set; }
        public virtual PostBag PostBag { get; set; }
    }
}
