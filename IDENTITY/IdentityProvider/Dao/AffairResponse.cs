using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairResponse
    {
        public int AffairResponseID { get; set; }
        public int AffairIndex { get; set; }
        public string Demonstration { get; set; }
        public DateTime? Date { get; set; }
        public string POSResponse { get; set; }
        public string UserResponse { get; set; }
        public string AffairProcess { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
