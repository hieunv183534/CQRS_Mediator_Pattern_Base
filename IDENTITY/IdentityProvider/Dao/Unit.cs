using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Unit
    {
        public Unit()
        {
            InverseParentUnitCodeNavigation = new HashSet<Unit>();
        }

        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string ParentUnitCode { get; set; }
        public string CommuneCode { get; set; }
        public string UnitTypeCode { get; set; }
        public string UnitNameSearch { get; set; }

        public virtual Commune CommuneCodeNavigation { get; set; }
        public virtual Unit ParentUnitCodeNavigation { get; set; }
        public virtual UnitType UnitTypeCodeNavigation { get; set; }
        public virtual ICollection<Unit> InverseParentUnitCodeNavigation { get; set; }
    }
}
