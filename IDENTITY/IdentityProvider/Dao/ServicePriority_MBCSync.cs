using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServicePriority_MBCSync
    {
        public string ServicePriorityCode { get; set; }
        public string ServicePriorityName { get; set; }
        public double? Priority { get; set; }
    }
}
