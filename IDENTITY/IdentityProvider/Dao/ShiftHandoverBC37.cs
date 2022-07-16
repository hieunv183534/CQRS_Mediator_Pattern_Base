using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverBC37
    {
        public string POSCode { get; set; }
        public int HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string CounterCode { get; set; }
        public string BC37Date { get; set; }
        public int BC37Index { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string TransportTypeCode { get; set; }
        public byte Status { get; set; }
        public long BC37ID { get; set; }
        public long ShiftHandoverID { get; set; }

        public virtual BC37 BC37 { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
