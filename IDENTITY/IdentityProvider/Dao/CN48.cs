using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CN48
    {
        public CN48()
        {
            CN48Item = new HashSet<CN48Item>();
        }

        public string CN48Code { get; set; }
        public string CountryCode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public byte? QuarterOfYear { get; set; }
        public string Year { get; set; }
        public string UnitCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? DirectionCode { get; set; }
        public string Note { get; set; }
        public string AttachmentFileName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual ICollection<CN48Item> CN48Item { get; set; }
    }
}
