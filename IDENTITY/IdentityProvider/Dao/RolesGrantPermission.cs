using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RolesGrantPermission
    {
        public RolesGrantPermission()
        {
            RoleObject = new HashSet<RoleObject>();
        }

        public int RolesGrantPermissionId { get; set; }
        public string RoleCode { get; set; }
        public int PerId { get; set; }

        public virtual PermissionAndGroupPermission Per { get; set; }
        public virtual Roles RoleCodeNavigation { get; set; }
        public virtual ICollection<RoleObject> RoleObject { get; set; }
    }
}
