using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PermissionAndGroupPermission
    {
        public PermissionAndGroupPermission()
        {
            RolesGrantPermission = new HashSet<RolesGrantPermission>();
        }

        public int PerId { get; set; }
        public int PermissionId { get; set; }
        public int PermissionGroupId { get; set; }
        public bool? Enable { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual PermissionGroup PermissionGroup { get; set; }
        public virtual ICollection<RolesGrantPermission> RolesGrantPermission { get; set; }
    }
}
