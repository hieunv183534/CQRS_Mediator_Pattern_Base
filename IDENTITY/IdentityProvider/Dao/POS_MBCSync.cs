using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POS_MBCSync
    {
        public string POSCode { get; set; }
        public string POSName { get; set; }
        public string Address { get; set; }
        public string AddressCode { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string IP { get; set; }
        public string DatabaseServer { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
        public string POSTypeCode { get; set; }
        public string ProvinceCode { get; set; }
        public string ServiceServer { get; set; }
        public int? ServicePort { get; set; }
        public string POSLevelCode { get; set; }
        public string CommuneCode { get; set; }
        public bool? IsOffline { get; set; }
        public string UnitCode { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
