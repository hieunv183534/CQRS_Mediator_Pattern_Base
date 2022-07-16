using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DnnModuleControlPermission
    {
        public int DnnModuleControlPermissionId { get; set; }
        public string DnnModuleControlName { get; set; }
        public string RoleGroupName { get; set; }
        public string RoleName { get; set; }
        public bool CanView { get; set; }
        public bool CanInsert { get; set; }
        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }

        public virtual DnnModuleControl DnnModuleControlNameNavigation { get; set; }
    }
}
