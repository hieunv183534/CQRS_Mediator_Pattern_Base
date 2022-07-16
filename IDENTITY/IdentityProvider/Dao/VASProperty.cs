using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class VASProperty
    {
        public VASProperty()
        {
            ItemVASPropertyValue = new HashSet<ItemVASPropertyValue>();
        }

        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string DataType { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string Description { get; set; }
        public string Control { get; set; }
        public string ControlValue { get; set; }

        public virtual ValueAddedService ValueAddedServiceCodeNavigation { get; set; }
        public virtual ICollection<ItemVASPropertyValue> ItemVASPropertyValue { get; set; }
    }
}
