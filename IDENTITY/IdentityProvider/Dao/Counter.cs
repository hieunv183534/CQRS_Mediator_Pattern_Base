using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Counter
    {
        public Counter()
        {
            Machine = new HashSet<Machine>();
        }

        public string CounterCode { get; set; }
        public string POSCode { get; set; }
        public string CounterName { get; set; }
        public string Description { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<Machine> Machine { get; set; }
    }
}
