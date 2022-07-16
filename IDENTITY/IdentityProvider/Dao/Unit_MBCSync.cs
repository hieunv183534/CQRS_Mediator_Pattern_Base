using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Unit_MBCSync
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string ParentUnitCode { get; set; }
        public string CommuneCode { get; set; }
        public string UnitTypeCode { get; set; }
    }
}
