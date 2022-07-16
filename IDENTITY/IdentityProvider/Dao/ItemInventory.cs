using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemInventory
    {
        public long ShiftHandoverID { get; set; }
        public long ItemID { get; set; }
        public byte? Status { get; set; }

        public virtual Item Item { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
