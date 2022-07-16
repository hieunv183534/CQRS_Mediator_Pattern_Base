using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Machine
    {
        public string MachineCode { get; set; }
        public string CounterCode { get; set; }
        public string POSCode { get; set; }
        public string MachineName { get; set; }
        public string MachineIP { get; set; }
        public string MachineRequestCode { get; set; }
        public string MachineKey { get; set; }
        public string Description { get; set; }

        public virtual Counter Counter { get; set; }
    }
}
