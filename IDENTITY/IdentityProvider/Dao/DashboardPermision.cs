using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DashboardPermision
    {
        public long Id { get; set; }
        public long SettingId { get; set; }
        public string RoleId { get; set; }
        public string PostCode { get; set; }

        public virtual DashboardSetting Setting { get; set; }
    }
}
