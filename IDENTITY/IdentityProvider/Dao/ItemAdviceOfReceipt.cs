using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemAdviceOfReceipt
    {
        public long ItemID { get; set; }
        public string AdviceOfReceiptCode { get; set; }
        public string ItemCode { get; set; }
        public string CheckContentOnDeliveryCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual ItemReturn Item { get; set; }
    }
}
