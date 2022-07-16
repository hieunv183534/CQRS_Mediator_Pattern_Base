using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftHandover = new HashSet<ShiftHandover>();
        }

        public string ShiftCode { get; set; }
        public string POSCode { get; set; }
        public string ShiftName { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? FinishHour { get; set; }
        public string Description { get; set; }
        public string ShiftNameSearch { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<ShiftHandover> ShiftHandover { get; set; }
    }
}
