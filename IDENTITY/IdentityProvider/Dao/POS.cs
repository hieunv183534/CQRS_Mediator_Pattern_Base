using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POS
    {
        public POS()
        {
            BatchPOS = new HashSet<BatchPOS>();
            Counter = new HashSet<Counter>();
            DeductionPOS = new HashSet<DeductionPOS>();
            DeliveryRoute = new HashSet<DeliveryRoute>();
            Device = new HashSet<Device>();
            Driver = new HashSet<Driver>();
            GroupReceiverObject = new HashSet<GroupReceiverObject>();
            Item = new HashSet<Item>();
            MailRoute = new HashSet<MailRoute>();
            MailRoutePOS = new HashSet<MailRoutePOS>();
            MailtripDestinationCodeNavigation = new HashSet<Mailtrip>();
            MailtripStartingCodeNavigation = new HashSet<Mailtrip>();
            OfflinePOSOfflinePOSCodeNavigation = new HashSet<OfflinePOS>();
            OfflinePOSOnlinePOSCodeNavigation = new HashSet<OfflinePOS>();
            POSConfiguration = new HashSet<POSConfiguration>();
            POSFreightRegion = new HashSet<POSFreightRegion>();
            POSService = new HashSet<POSService>();
            PostBagEmpty = new HashSet<PostBagEmpty>();
            ReportManagerPrinter = new HashSet<ReportManagerPrinter>();
            RequestAccepted = new HashSet<RequestAccepted>();
            RevenueSharing = new HashSet<RevenueSharing>();
            Section = new HashSet<Section>();
            Server = new HashSet<Server>();
            ServicePOSConfiguration = new HashSet<ServicePOSConfiguration>();
            ServiceSupplying = new HashSet<ServiceSupplying>();
            Shift = new HashSet<Shift>();
            StampMachine = new HashSet<StampMachine>();
            Transport = new HashSet<Transport>();
            User = new HashSet<User>();
        }

        public string POSCode { get; set; }
        public string POSName { get; set; }
        public string Address { get; set; }
        public string AddressCode { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string IP { get; set; }
        public string DatabaseServer { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
        public string POSTypeCode { get; set; }
        public string ProvinceCode { get; set; }
        public string ServiceServer { get; set; }
        public int? ServicePort { get; set; }
        public string POSLevelCode { get; set; }
        public string CommuneCode { get; set; }
        public bool? IsOffline { get; set; }
        public string UnitCode { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string DistrictCode { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string Stamp { get; set; }
        public string POSNameSearch { get; set; }

        public virtual POSInternal POSInternal { get; set; }
        public virtual ICollection<BatchPOS> BatchPOS { get; set; }
        public virtual ICollection<Counter> Counter { get; set; }
        public virtual ICollection<DeductionPOS> DeductionPOS { get; set; }
        public virtual ICollection<DeliveryRoute> DeliveryRoute { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<GroupReceiverObject> GroupReceiverObject { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<MailRoute> MailRoute { get; set; }
        public virtual ICollection<MailRoutePOS> MailRoutePOS { get; set; }
        public virtual ICollection<Mailtrip> MailtripDestinationCodeNavigation { get; set; }
        public virtual ICollection<Mailtrip> MailtripStartingCodeNavigation { get; set; }
        public virtual ICollection<OfflinePOS> OfflinePOSOfflinePOSCodeNavigation { get; set; }
        public virtual ICollection<OfflinePOS> OfflinePOSOnlinePOSCodeNavigation { get; set; }
        public virtual ICollection<POSConfiguration> POSConfiguration { get; set; }
        public virtual ICollection<POSFreightRegion> POSFreightRegion { get; set; }
        public virtual ICollection<POSService> POSService { get; set; }
        public virtual ICollection<PostBagEmpty> PostBagEmpty { get; set; }
        public virtual ICollection<ReportManagerPrinter> ReportManagerPrinter { get; set; }
        public virtual ICollection<RequestAccepted> RequestAccepted { get; set; }
        public virtual ICollection<RevenueSharing> RevenueSharing { get; set; }
        public virtual ICollection<Section> Section { get; set; }
        public virtual ICollection<Server> Server { get; set; }
        public virtual ICollection<ServicePOSConfiguration> ServicePOSConfiguration { get; set; }
        public virtual ICollection<ServiceSupplying> ServiceSupplying { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<StampMachine> StampMachine { get; set; }
        public virtual ICollection<Transport> Transport { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
