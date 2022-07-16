using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ValueAddedServiceItem
    {
        public long ItemID { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Item Item { get; set; }
        public virtual VASUsing VASUsing { get; set; }
    }
}
