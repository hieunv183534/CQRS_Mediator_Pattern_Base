using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Deduction
    {
        public Deduction()
        {
            DeductionDetail = new HashSet<DeductionDetail>();
            DeductionPOS = new HashSet<DeductionPOS>();
            DeductionProvince = new HashSet<DeductionProvince>();
        }

        public string DeductionCode { get; set; }
        public string DeductionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ServiceCode { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<DeductionDetail> DeductionDetail { get; set; }
        public virtual ICollection<DeductionPOS> DeductionPOS { get; set; }
        public virtual ICollection<DeductionProvince> DeductionProvince { get; set; }
    }
}
