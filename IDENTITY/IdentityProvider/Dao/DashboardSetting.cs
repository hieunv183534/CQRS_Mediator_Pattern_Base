using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DashboardSetting
    {
        public DashboardSetting()
        {
            DashboardPermision = new HashSet<DashboardPermision>();
        }

        public long Id { get; set; }
        public long DatasetId { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public int Period { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public double Index { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsPermissionAll { get; set; }
        public string Name { get; set; }

        public virtual DashboardDataset Dataset { get; set; }
        public virtual ICollection<DashboardPermision> DashboardPermision { get; set; }
    }
}
