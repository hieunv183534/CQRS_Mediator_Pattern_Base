using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Roles
    {
        public Roles()
        {
            RolesGrantPermission = new HashSet<RolesGrantPermission>();
        }

        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RolesGrantPermission> RolesGrantPermission { get; set; }
    }
}
