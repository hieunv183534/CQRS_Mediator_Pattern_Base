using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Mailtrip_Sync
    {
        public long? MailtripID { get; set; }
        public string StartingCode { get; set; }
        public string DestinationCode { get; set; }
        public string MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailtripNumber { get; set; }
        public DateTime? OutgoingDate { get; set; }
        public byte? Status { get; set; }
        public string MailRouteCode { get; set; }
        public string BC37Number { get; set; }
        public DateTime? IncomingDate { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public int? NumberItemPerSheet { get; set; }
        public string PackagingTime { get; set; }
        public string PackagingUser { get; set; }
        public string PackagingMachineName { get; set; }
        public DateTime? OpeningTime { get; set; }
        public string OpeningUser { get; set; }
        public string OpeningMachineName { get; set; }
        public DateTime? InitialTime { get; set; }
        public string InitialMachineName { get; set; }
        public string InitialUser { get; set; }
        public DateTime? TrasferTime { get; set; }
        public string TransferMachine { get; set; }
        public string TransferUser { get; set; }
        public string TransportNumber { get; set; }
        public string TransportCode { get; set; }
        public string OriginalTransportPOSCode { get; set; }
        public string TransportDate { get; set; }
        public string CounterCode { get; set; }
        public string DeliveryRoute { get; set; }
        public byte? Type { get; set; }
        public string TransferPOSCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool? TransferStatus { get; set; }
        public int? TransferTimes { get; set; }
        public string TransferID { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string AirCode { get; set; }
        public string AirportGoCode { get; set; }
        public string AirportToCode { get; set; }
    }
}
