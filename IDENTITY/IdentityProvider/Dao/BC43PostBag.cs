using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC43PostBag
    {
        public string BC43Code { get; set; }
        public string FromPosCode { get; set; }
        public string ToPosCode { get; set; }
        public int PostBagIndex { get; set; }
        public string PostBagFromPosCode { get; set; }
        public string PostBagToPosCode { get; set; }
        public string PostBagMailTripType { get; set; }
        public string PostBagServiceCode { get; set; }
        public string PostBagYear { get; set; }
        public string PostBagMailTripNumber { get; set; }
        public string PostBagCode { get; set; }
        public double? PostBagOriginalWeight { get; set; }
        public byte? Status { get; set; }
        public string ItemCodeCorrect { get; set; }
        public int? Quantity { get; set; }
        public bool? F { get; set; }
        public bool? IsPrinted { get; set; }
        public int? PostBagStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
