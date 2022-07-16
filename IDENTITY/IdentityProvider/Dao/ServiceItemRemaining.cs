using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServiceItemRemaining
    {
        public int HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string POSCode { get; set; }
        public string CounterCode { get; set; }
        public string ServiceCode { get; set; }
        public int? ItemRemaining { get; set; }
    }
}
