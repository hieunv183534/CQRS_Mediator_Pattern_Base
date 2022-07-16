using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DnnModuleControl
    {
        public DnnModuleControl()
        {
            DnnModuleControlPermission = new HashSet<DnnModuleControlPermission>();
        }

        public string DnnModuleControlName { get; set; }
        public string DnnModuleControlFriendlyName { get; set; }
        public string DnnModuleName { get; set; }

        public virtual ICollection<DnnModuleControlPermission> DnnModuleControlPermission { get; set; }
    }
}
