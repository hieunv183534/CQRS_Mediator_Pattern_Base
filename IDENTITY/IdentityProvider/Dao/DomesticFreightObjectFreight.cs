using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightObjectFreight
    {
        public DomesticFreightObjectFreight()
        {
            DomesticFreightPropertyValue = new HashSet<DomesticFreightPropertyValue>();
        }

        public int DomesticFreightObjectFreightID { get; set; }
        public string DomesticFreightObjectCode { get; set; }
        public int? RowIndex { get; set; }
        public double? Freight { get; set; }

        public virtual DomesticFreightObject DomesticFreightObjectCodeNavigation { get; set; }
        public virtual ICollection<DomesticFreightPropertyValue> DomesticFreightPropertyValue { get; set; }
    }
}
