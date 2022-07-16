using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Service_MBCSync
    {
        public string ServiceCode { get; set; }
        public string ShortName { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string ServiceTypeCode { get; set; }
        public string SupplyScope { get; set; }
        public string ImageName { get; set; }
        public string AutomaticGenerationCharacterFrom { get; set; }
        public string AutomaticGenerationCharacterTo { get; set; }
        public string PrintCharacterFrom { get; set; }
        public string PrintCharacterTo { get; set; }
        public string ServicePriorityCode { get; set; }
        public bool? IsAllowNegotiating { get; set; }
        public double? LightDivideFactor { get; set; }
        public double? VATPercentage { get; set; }
        public int? AirCoefficientConvertWeight { get; set; }
        public int? SurfaceCoefficientConvertWeight { get; set; }
    }
}
