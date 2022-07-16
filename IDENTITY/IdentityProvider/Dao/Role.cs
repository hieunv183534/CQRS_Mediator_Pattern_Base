using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Role
    {
        public Role()
        {
            GroupRole = new HashSet<GroupRole>();
            InverseParentRoleCodeNavigation = new HashSet<Role>();
        }

        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string ParentRoleCode { get; set; }

        public virtual Role ParentRoleCodeNavigation { get; set; }
        public virtual ICollection<GroupRole> GroupRole { get; set; }
        public virtual ICollection<Role> InverseParentRoleCodeNavigation { get; set; }
    }
}
