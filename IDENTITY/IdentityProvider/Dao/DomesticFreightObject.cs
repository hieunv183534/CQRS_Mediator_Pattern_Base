using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightObject
    {
        public DomesticFreightObject()
        {
            DomesticFreightObjectFreight = new HashSet<DomesticFreightObjectFreight>();
            DomesticFreightProperty = new HashSet<DomesticFreightProperty>();
        }

        public string DomesticFreightObjectCode { get; set; }
        public string DomesticFreightObjectName { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public string Formula { get; set; }

        public virtual ICollection<DomesticFreightObjectFreight> DomesticFreightObjectFreight { get; set; }
        public virtual ICollection<DomesticFreightProperty> DomesticFreightProperty { get; set; }
    }
}
