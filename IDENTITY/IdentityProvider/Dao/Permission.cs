using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionAndGroupPermission = new HashSet<PermissionAndGroupPermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionAndGroupPermission> PermissionAndGroupPermission { get; set; }
    }
}
