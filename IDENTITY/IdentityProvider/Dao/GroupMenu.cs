using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class GroupMenu
    {
        public string GroupCode { get; set; }
        public string MenuCode { get; set; }

        public virtual Group GroupCodeNavigation { get; set; }
        public virtual Menu MenuCodeNavigation { get; set; }
    }
}
