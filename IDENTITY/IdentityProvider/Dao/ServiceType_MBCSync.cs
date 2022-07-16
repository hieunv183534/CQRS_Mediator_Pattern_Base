using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServiceType_MBCSync
    {
        public string ServiceTypeCode { get; set; }
        public string ServiceTypeName { get; set; }
        public string Description { get; set; }
        public string ServiceTypeParentCode { get; set; }
    }
}
