using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class StampMachine
    {
        public StampMachine()
        {
            StampMachineFeight = new HashSet<StampMachineFeight>();
        }

        public string POSCode { get; set; }
        public string StampMachineNumber { get; set; }
        public string StampMachineName { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<StampMachineFeight> StampMachineFeight { get; set; }
    }
}
