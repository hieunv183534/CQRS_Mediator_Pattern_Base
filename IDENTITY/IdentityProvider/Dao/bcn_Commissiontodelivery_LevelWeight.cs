using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class bcn_Commissiontodelivery_LevelWeight
    {
        public int Levelweight { get; set; }
        public double? FromWeight { get; set; }
        public double? ToWeight { get; set; }
        public bool? isDomestic { get; set; }
    }
}
