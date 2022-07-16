using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServicePriority
    {
        public ServicePriority()
        {
            Service = new HashSet<Service>();
        }

        public string ServicePriorityCode { get; set; }
        public string ServicePriorityName { get; set; }
        public double? Priority { get; set; }

        public virtual ICollection<Service> Service { get; set; }
    }
}
