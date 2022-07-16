using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class UnitType
    {
        public UnitType()
        {
            Unit = new HashSet<Unit>();
        }

        public string UnitTypeCode { get; set; }
        public string UnitTypeName { get; set; }
        public string Description { get; set; }
        public string UnitTypeNameSearch { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
