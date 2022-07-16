using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Property
    {
        public Property()
        {
            ServiceProperty = new HashSet<ServiceProperty>();
        }

        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
        public string Control { get; set; }
        public string ControlValue { get; set; }
        public int? OrderIndex { get; set; }
        public string GroupPropertyCode { get; set; }

        public virtual GroupProperty GroupPropertyCodeNavigation { get; set; }
        public virtual ICollection<ServiceProperty> ServiceProperty { get; set; }
    }
}
