using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TMSTransport
    {
        public string TOMasterCode { get; set; }
        public string TypeOfTrip { get; set; }
        public string OPSRoutingName { get; set; }
        public string BD10RoutingTypeName { get; set; }
        public string OPSRoutingOfficeName { get; set; }
        public string RoutingCategoryName { get; set; }
        public string RoutingContentName { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public string GroupOfVendorCode { get; set; }
        public string VehicleCode { get; set; }
        public string VehicleGroupName { get; set; }
        public string GroupOfVehicleRangeName { get; set; }
        public string VehicleTypeName { get; set; }
        public string DriverName { get; set; }
        public string HRM { get; set; }
        public string TypeOfContractDriverName { get; set; }
        public string DriverName2 { get; set; }
        public string HRM2 { get; set; }
        public string TypeOfContractDriverName2 { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime? ATD { get; set; }
        public DateTime? ATA { get; set; }
        public decimal KmGPS { get; set; }
        public string BD10 { get; set; }
        public string BC37StartingCode { get; set; }
        public string BC37DestinationCode { get; set; }
        public long? BC37ID { get; set; }
    }
}
