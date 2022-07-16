using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class StampMachineFeight
    {
        public string POSCode { get; set; }
        public string StampMachineNumber { get; set; }
        public DateTime DateInput { get; set; }
        public int? StartNumber { get; set; }
        public int? EndNumber { get; set; }

        public virtual StampMachine StampMachine { get; set; }
    }
}
