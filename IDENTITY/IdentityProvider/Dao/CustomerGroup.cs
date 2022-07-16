using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CustomerGroup
    {
        public CustomerGroup()
        {
            Item = new HashSet<Item>();
        }

        public string CustomerGroupCode { get; set; }
        public string CustomerGroupName { get; set; }
        public string CustomerGroupContent { get; set; }
        public string DeliveryRequirement { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
