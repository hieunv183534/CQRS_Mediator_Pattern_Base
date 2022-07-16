using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ValueAddedService
    {
        public ValueAddedService()
        {
            MoneyOrderValueAddedService = new HashSet<MoneyOrderValueAddedService>();
            VASProperty = new HashSet<VASProperty>();
            VASUsing = new HashSet<VASUsing>();
        }

        public string ValueAddedServiceCode { get; set; }
        public string ValueAddedServiceName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public string ValueAddedServiceNameSearch { get; set; }

        public virtual ICollection<MoneyOrderValueAddedService> MoneyOrderValueAddedService { get; set; }
        public virtual ICollection<VASProperty> VASProperty { get; set; }
        public virtual ICollection<VASUsing> VASUsing { get; set; }
    }
}
