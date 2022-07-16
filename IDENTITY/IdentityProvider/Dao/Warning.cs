using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Warning
    {
        public long ID { get; set; }
        public string POSCode { get; set; }
        public byte? WarningType { get; set; }
        public byte? WarningLevel { get; set; }
        public string WarningContent { get; set; }
        public long? ExternalID { get; set; }
        public byte? Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
