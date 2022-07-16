using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverPostBagEmpty
    {
        public long ShiftHandoverID { get; set; }
        public long PostBagEmptyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual PostBagEmpty PostBagEmpty { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
