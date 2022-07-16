using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TracePostBag
    {
        public long TracePostBagID { get; set; }
        public long PostbagID { get; set; }
        public int TraceIndex { get; set; }
        public string POSCode { get; set; }
        public byte Status { get; set; }
        public DateTime TraceDate { get; set; }
        public string StatusDescription { get; set; }
        public string Note { get; set; }
        public string TableName { get; set; }
        public long? TableID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual PostBag Postbag { get; set; }
    }
}
