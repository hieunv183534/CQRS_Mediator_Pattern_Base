using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemVASFreight
    {
        public long Id { get; set; }
        public long? ItemID { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public double? Freight { get; set; }

        public virtual Item Item { get; set; }
    }
}
