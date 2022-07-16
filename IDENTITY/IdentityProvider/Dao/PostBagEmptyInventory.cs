using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PostBagEmptyInventory
    {
        public long ShiftHandoverID { get; set; }
        public string PostBagTypeCode { get; set; }
        public int? Amount { get; set; }
        public byte? Status { get; set; }

        public virtual PostBagType PostBagTypeCodeNavigation { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
