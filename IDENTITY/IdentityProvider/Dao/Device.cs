using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Device
    {
        public Device()
        {
            ShiftHandoverDevice = new HashSet<ShiftHandoverDevice>();
        }

        public long DeviceID { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public string POSCode { get; set; }
        public short Status { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<ShiftHandoverDevice> ShiftHandoverDevice { get; set; }
    }
}
