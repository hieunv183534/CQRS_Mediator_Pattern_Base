using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PermissionGroup
    {
        public PermissionGroup()
        {
            PermissionAndGroupPermission = new HashSet<PermissionAndGroupPermission>();
        }

        public int PermissionGroupId { get; set; }
        public string PermissionGroupName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionAndGroupPermission> PermissionAndGroupPermission { get; set; }
    }
}
