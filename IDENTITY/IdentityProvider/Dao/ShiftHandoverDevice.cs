using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverDevice
    {
        public long ShiftHandoverID { get; set; }
        public long DeviceID { get; set; }
        public byte Status { get; set; }
        public int? ItemNumber { get; set; }
        public string Reason { get; set; }

        public virtual Device Device { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
