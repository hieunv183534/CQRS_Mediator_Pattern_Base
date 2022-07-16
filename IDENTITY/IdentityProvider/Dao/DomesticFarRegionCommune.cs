using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFarRegionCommune
    {
        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string CommuneCode { get; set; }

        public virtual Commune CommuneCodeNavigation { get; set; }
        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
    }
}
