using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightPropertyValue
    {
        public int DomesticFreightPropertyValueID { get; set; }
        public string DomesticFreightPropertyCode { get; set; }
        public string Value { get; set; }
        public int? DomesticFreightObjectFreightID { get; set; }

        public virtual DomesticFreightObjectFreight DomesticFreightObjectFreight { get; set; }
        public virtual DomesticFreightProperty DomesticFreightPropertyCodeNavigation { get; set; }
    }
}
