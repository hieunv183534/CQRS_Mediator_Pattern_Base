using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TargetCataloge
    {
        public TargetCataloge()
        {
            InverseTargetCatalogeParentCodeNavigation = new HashSet<TargetCataloge>();
            Targets = new HashSet<Targets>();
        }

        public string TargetCatalogeCode { get; set; }
        public string TargetCatalogeName { get; set; }
        public string TargetCatalogeParentCode { get; set; }

        public virtual TargetCataloge TargetCatalogeParentCodeNavigation { get; set; }
        public virtual ICollection<TargetCataloge> InverseTargetCatalogeParentCodeNavigation { get; set; }
        public virtual ICollection<Targets> Targets { get; set; }
    }
}
