using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MenuService
    {
        public string MenuCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual Menu MenuCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
