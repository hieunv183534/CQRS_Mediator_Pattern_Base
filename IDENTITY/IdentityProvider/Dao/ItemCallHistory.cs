using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemCallHistory
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public int DeliveryIndex { get; set; }
        public string ToPOSCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
