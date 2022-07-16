using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class bcn_commissiontodelivery
    {
        public int ID { get; set; }
        public int Levelweight { get; set; }
        public int Region { get; set; }
        public int IsSubOffice { get; set; }
        public string ItemTypeCode { get; set; }
        public string VASICode { get; set; }
        public double Ems_Value { get; set; }
        public bool? IsAdd { get; set; }
        public double? EMS_Value_Total { get; set; }
    }
}
