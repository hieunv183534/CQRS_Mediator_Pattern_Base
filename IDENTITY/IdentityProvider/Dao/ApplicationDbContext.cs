using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityProvider.Dao
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLogType> ActivityLogType { get; set; }
        public virtual DbSet<Affair> Affair { get; set; }
        public virtual DbSet<AffairDetailItem> AffairDetailItem { get; set; }
        public virtual DbSet<AffairHistory> AffairHistory { get; set; }
        public virtual DbSet<AffairItem> AffairItem { get; set; }
        public virtual DbSet<AffairItemVASPropertyValue> AffairItemVASPropertyValue { get; set; }
        public virtual DbSet<AffairMessage> AffairMessage { get; set; }
        public virtual DbSet<AffairMessagePOS> AffairMessagePOS { get; set; }
        public virtual DbSet<AffairResponse> AffairResponse { get; set; }
        public virtual DbSet<AffairServedFreight> AffairServedFreight { get; set; }
        public virtual DbSet<AffairTransactionsCollection> AffairTransactionsCollection { get; set; }
        public virtual DbSet<AffairTransport> AffairTransport { get; set; }
        public virtual DbSet<AffairVASItem> AffairVASItem { get; set; }
        public virtual DbSet<AffairValue> AffairValue { get; set; }
        public virtual DbSet<AffairValueAddedService> AffairValueAddedService { get; set; }
        public virtual DbSet<Affair_Sync> Affair_Sync { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<ApplicationVersion> ApplicationVersion { get; set; }
        public virtual DbSet<BC37> BC37 { get; set; }
        public virtual DbSet<BC37BCCP> BC37BCCP { get; set; }
        public virtual DbSet<BC37Route> BC37Route { get; set; }
        public virtual DbSet<BC37RouteType> BC37RouteType { get; set; }
        public virtual DbSet<BC37_Sync> BC37_Sync { get; set; }
        public virtual DbSet<BC43> BC43 { get; set; }
        public virtual DbSet<BC43Affair> BC43Affair { get; set; }
        public virtual DbSet<BC43Dispatch> BC43Dispatch { get; set; }
        public virtual DbSet<BC43PostBag> BC43PostBag { get; set; }
        public virtual DbSet<BC43Type> BC43Type { get; set; }
        public virtual DbSet<BCCL_Region> BCCL_Region { get; set; }
        public virtual DbSet<BCCL_RegionProvince> BCCL_RegionProvince { get; set; }
        public virtual DbSet<BCNConstance> BCNConstance { get; set; }
        public virtual DbSet<BCNServiceList> BCNServiceList { get; set; }
        public virtual DbSet<BCN_PCDT> BCN_PCDT { get; set; }
        public virtual DbSet<BD21AffairResponse> BD21AffairResponse { get; set; }
        public virtual DbSet<BD21Disscusion> BD21Disscusion { get; set; }
        public virtual DbSet<BD21History> BD21History { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<BatchPOS> BatchPOS { get; set; }
        public virtual DbSet<Batch_Sync> Batch_Sync { get; set; }
        public virtual DbSet<BusinessDomain> BusinessDomain { get; set; }
        public virtual DbSet<BuuGuiWithAddress> BuuGuiWithAddress { get; set; }
        public virtual DbSet<CN08> CN08 { get; set; }
        public virtual DbSet<CN48> CN48 { get; set; }
        public virtual DbSet<CN48Item> CN48Item { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cause> Cause { get; set; }
        public virtual DbSet<CauseCustomer> CauseCustomer { get; set; }
        public virtual DbSet<CauseSolution> CauseSolution { get; set; }
        public virtual DbSet<ChangeReason> ChangeReason { get; set; }
        public virtual DbSet<ChangedItem> ChangedItem { get; set; }
        public virtual DbSet<ChemicalType> ChemicalType { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<ClaimAnswerMethod> ClaimAnswerMethod { get; set; }
        public virtual DbSet<ClaimCompensate> ClaimCompensate { get; set; }
        public virtual DbSet<ClaimCompensateRule> ClaimCompensateRule { get; set; }
        public virtual DbSet<ClaimConclusion> ClaimConclusion { get; set; }
        public virtual DbSet<ClaimDirection> ClaimDirection { get; set; }
        public virtual DbSet<ClaimEmails> ClaimEmails { get; set; }
        public virtual DbSet<ClaimItem> ClaimItem { get; set; }
        public virtual DbSet<ClaimMailTrip> ClaimMailTrip { get; set; }
        public virtual DbSet<ClaimPayCompensatePOS> ClaimPayCompensatePOS { get; set; }
        public virtual DbSet<ClaimPriority> ClaimPriority { get; set; }
        public virtual DbSet<ClaimReply> ClaimReply { get; set; }
        public virtual DbSet<ClaimResponse> ClaimResponse { get; set; }
        public virtual DbSet<ClaimResponseMailtrip> ClaimResponseMailtrip { get; set; }
        public virtual DbSet<ClaimResult> ClaimResult { get; set; }
        public virtual DbSet<ClaimStatus> ClaimStatus { get; set; }
        public virtual DbSet<ClaimTimeProcessRule> ClaimTimeProcessRule { get; set; }
        public virtual DbSet<ClaimTransportUnit> ClaimTransportUnit { get; set; }
        public virtual DbSet<ClaimType> ClaimType { get; set; }
        public virtual DbSet<ClaimTypeError> ClaimTypeError { get; set; }
        public virtual DbSet<ClientReservation> ClientReservation { get; set; }
        public virtual DbSet<CollectionFreightStep> CollectionFreightStep { get; set; }
        public virtual DbSet<Column> Column { get; set; }
        public virtual DbSet<CommodityType> CommodityType { get; set; }
        public virtual DbSet<Commune> Commune { get; set; }
        public virtual DbSet<CommuneFreightRegion> CommuneFreightRegion { get; set; }
        public virtual DbSet<Commune_MBCSync> Commune_MBCSync { get; set; }
        public virtual DbSet<CommunicationConfig> CommunicationConfig { get; set; }
        public virtual DbSet<CompensateCategory> CompensateCategory { get; set; }
        public virtual DbSet<CompensateRate> CompensateRate { get; set; }
        public virtual DbSet<CompensateResult> CompensateResult { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Controls> Controls { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Counter1> Counter1 { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerBusinessDomain> CustomerBusinessDomain { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroup { get; set; }
        public virtual DbSet<CustomerObject> CustomerObject { get; set; }
        public virtual DbSet<Dasboard_SANLUONGBUUGUIUUTIENDACBIET> Dasboard_SANLUONGBUUGUIUUTIENDACBIET { get; set; }
        public virtual DbSet<Dasboard_SanLuongPhatALienTinh> Dasboard_SanLuongPhatALienTinh { get; set; }
        public virtual DbSet<Dasboard_SanLuong_BCCP_BCCC_ChieuDen> Dasboard_SanLuong_BCCP_BCCC_ChieuDen { get; set; }
        public virtual DbSet<Dasboard_SanLuong_BCCP_BCCC_ChieuDi> Dasboard_SanLuong_BCCP_BCCC_ChieuDi { get; set; }
        public virtual DbSet<DashboardDataset> DashboardDataset { get; set; }
        public virtual DbSet<DashboardPermision> DashboardPermision { get; set; }
        public virtual DbSet<DashboardSetting> DashboardSetting { get; set; }
        public virtual DbSet<Dashboard_4VanPhong> Dashboard_4VanPhong { get; set; }
        public virtual DbSet<DbVersion> DbVersion { get; set; }
        public virtual DbSet<Deduction> Deduction { get; set; }
        public virtual DbSet<DeductionDetail> DeductionDetail { get; set; }
        public virtual DbSet<DeductionPOS> DeductionPOS { get; set; }
        public virtual DbSet<DeductionProvince> DeductionProvince { get; set; }
        public virtual DbSet<DeleteParameter> DeleteParameter { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryBCCP> DeliveryBCCP { get; set; }
        public virtual DbSet<DeliveryBCCP_Sync> DeliveryBCCP_Sync { get; set; }
        public virtual DbSet<DeliveryPoint> DeliveryPoint { get; set; }
        public virtual DbSet<DeliveryPointReceiver> DeliveryPointReceiver { get; set; }
        public virtual DbSet<DeliveryPointReceiver_Back> DeliveryPointReceiver_Back { get; set; }
        public virtual DbSet<DeliveryRevenueSharing> DeliveryRevenueSharing { get; set; }
        public virtual DbSet<DeliveryRoute> DeliveryRoute { get; set; }
        public virtual DbSet<DeliveryRoutePoint> DeliveryRoutePoint { get; set; }
        public virtual DbSet<DeliveryRouteService> DeliveryRouteService { get; set; }
        public virtual DbSet<DeliveryRouteService_MBCSync> DeliveryRouteService_MBCSync { get; set; }
        public virtual DbSet<DeliveryRoute_MBCSync> DeliveryRoute_MBCSync { get; set; }
        public virtual DbSet<DeliveryScoping> DeliveryScoping { get; set; }
        public virtual DbSet<Delivery_Log> Delivery_Log { get; set; }
        public virtual DbSet<Delivery_Sync> Delivery_Sync { get; set; }
        public virtual DbSet<DetailBlockFreight> DetailBlockFreight { get; set; }
        public virtual DbSet<DetailItemAffairCOD> DetailItemAffairCOD { get; set; }
        public virtual DbSet<DetailItemChanged> DetailItemChanged { get; set; }
        public virtual DbSet<DetailItem_Sync> DetailItem_Sync { get; set; }
        public virtual DbSet<DetailProvinceFreight> DetailProvinceFreight { get; set; }
        public virtual DbSet<DetailRegionFreight> DetailRegionFreight { get; set; }
        public virtual DbSet<DetailValueAddedServiceProvinceFreight> DetailValueAddedServiceProvinceFreight { get; set; }
        public virtual DbSet<DetailValueAddedServiceRegionFreight> DetailValueAddedServiceRegionFreight { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DirectionRoute> DirectionRoute { get; set; }
        public virtual DbSet<Dispatch> Dispatch { get; set; }
        public virtual DbSet<DispatchBack_Sync> DispatchBack_Sync { get; set; }
        public virtual DbSet<Dispatch_Sync> Dispatch_Sync { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DistrictFreightRegion> DistrictFreightRegion { get; set; }
        public virtual DbSet<District_MBCSync> District_MBCSync { get; set; }
        public virtual DbSet<DnnModuleControl> DnnModuleControl { get; set; }
        public virtual DbSet<DnnModuleControlPermission> DnnModuleControlPermission { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<DomessticFreightRuleVASUsing> DomessticFreightRuleVASUsing { get; set; }
        public virtual DbSet<DomesticCollectionFreight> DomesticCollectionFreight { get; set; }
        public virtual DbSet<DomesticCommodityType> DomesticCommodityType { get; set; }
        public virtual DbSet<DomesticCompensateRule> DomesticCompensateRule { get; set; }
        public virtual DbSet<DomesticFarRegion> DomesticFarRegion { get; set; }
        public virtual DbSet<DomesticFarRegionCommune> DomesticFarRegionCommune { get; set; }
        public virtual DbSet<DomesticFarRegionFreightStep> DomesticFarRegionFreightStep { get; set; }
        public virtual DbSet<DomesticFreightBlock> DomesticFreightBlock { get; set; }
        public virtual DbSet<DomesticFreightObject> DomesticFreightObject { get; set; }
        public virtual DbSet<DomesticFreightObjectFreight> DomesticFreightObjectFreight { get; set; }
        public virtual DbSet<DomesticFreightProperty> DomesticFreightProperty { get; set; }
        public virtual DbSet<DomesticFreightPropertyValue> DomesticFreightPropertyValue { get; set; }
        public virtual DbSet<DomesticFreightRule> DomesticFreightRule { get; set; }
        public virtual DbSet<DomesticFreightRuleItemTypeUsing> DomesticFreightRuleItemTypeUsing { get; set; }
        public virtual DbSet<DomesticFreightRuleLastUpdate> DomesticFreightRuleLastUpdate { get; set; }
        public virtual DbSet<DomesticFreightStep> DomesticFreightStep { get; set; }
        public virtual DbSet<DomesticServiceSurchange> DomesticServiceSurchange { get; set; }
        public virtual DbSet<DomesticSurchangeValueAddedServicePercent> DomesticSurchangeValueAddedServicePercent { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPerItem> DomesticValueAddedServiceFreightPerItem { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPerMoney> DomesticValueAddedServiceFreightPerMoney { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPerStockDay> DomesticValueAddedServiceFreightPerStockDay { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPerTotalItem> DomesticValueAddedServiceFreightPerTotalItem { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPerTotalItemInBatch> DomesticValueAddedServiceFreightPerTotalItemInBatch { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightPercentMainFreight> DomesticValueAddedServiceFreightPercentMainFreight { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightStep> DomesticValueAddedServiceFreightStep { get; set; }
        public virtual DbSet<DomesticValueAddedServiceFreightTotalWeight> DomesticValueAddedServiceFreightTotalWeight { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<EmailAccount> EmailAccount { get; set; }
        public virtual DbSet<Example> Example { get; set; }
        public virtual DbSet<Example1> Example1 { get; set; }
        public virtual DbSet<Example2> Example2 { get; set; }
        public virtual DbSet<ExampleFile> ExampleFile { get; set; }
        public virtual DbSet<ExampleMultiKey> ExampleMultiKey { get; set; }
        public virtual DbSet<ExchangeRelationship> ExchangeRelationship { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<FreightRegion> FreightRegion { get; set; }
        public virtual DbSet<GetDependOn> GetDependOn { get; set; }
        public virtual DbSet<GetParameter> GetParameter { get; set; }
        public virtual DbSet<GetType> GetType { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupMenu> GroupMenu { get; set; }
        public virtual DbSet<GroupProperty> GroupProperty { get; set; }
        public virtual DbSet<GroupReceiverObject> GroupReceiverObject { get; set; }
        public virtual DbSet<GroupReceiverObjectDetail> GroupReceiverObjectDetail { get; set; }
        public virtual DbSet<GroupRole> GroupRole { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Incident> Incident { get; set; }
        public virtual DbSet<IncidentCategory> IncidentCategory { get; set; }
        public virtual DbSet<IncidentCategoryType> IncidentCategoryType { get; set; }
        public virtual DbSet<IncidentItem> IncidentItem { get; set; }
        public virtual DbSet<IncidentPostbag> IncidentPostbag { get; set; }
        public virtual DbSet<IncidentResponseType> IncidentResponseType { get; set; }
        public virtual DbSet<IncidentType> IncidentType { get; set; }
        public virtual DbSet<IntercityJourneysTarget> IntercityJourneysTarget { get; set; }
        public virtual DbSet<IntercityJourneysTarget_District> IntercityJourneysTarget_District { get; set; }
        public virtual DbSet<IntercityJourneysTarget_KhuVuc> IntercityJourneysTarget_KhuVuc { get; set; }
        public virtual DbSet<IntercityJourneysTarget_Provice> IntercityJourneysTarget_Provice { get; set; }
        public virtual DbSet<IntercityJourneysTarget_View> IntercityJourneysTarget_View { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemAdviceOfReceipt> ItemAdviceOfReceipt { get; set; }
        public virtual DbSet<ItemBack_Sync> ItemBack_Sync { get; set; }
        public virtual DbSet<ItemCallHistory> ItemCallHistory { get; set; }
        public virtual DbSet<ItemCommodityType> ItemCommodityType { get; set; }
        public virtual DbSet<ItemCommodityType_Sync> ItemCommodityType_Sync { get; set; }
        public virtual DbSet<ItemCompensate> ItemCompensate { get; set; }
        public virtual DbSet<ItemCompensate_Sync> ItemCompensate_Sync { get; set; }
        public virtual DbSet<ItemDeliveryTransfered> ItemDeliveryTransfered { get; set; }
        public virtual DbSet<ItemExclude> ItemExclude { get; set; }
        public virtual DbSet<ItemForward> ItemForward { get; set; }
        public virtual DbSet<ItemForward_Sync> ItemForward_Sync { get; set; }
        public virtual DbSet<ItemInventory> ItemInventory { get; set; }
        public virtual DbSet<ItemPropertyValue_Sync> ItemPropertyValue_Sync { get; set; }
        public virtual DbSet<ItemReturn> ItemReturn { get; set; }
        public virtual DbSet<ItemReturn_Sync> ItemReturn_Sync { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<ItemTypeNotUsedValueAddedService> ItemTypeNotUsedValueAddedService { get; set; }
        public virtual DbSet<ItemTypeUsedValueAddedService> ItemTypeUsedValueAddedService { get; set; }
        public virtual DbSet<ItemType_MBCSync> ItemType_MBCSync { get; set; }
        public virtual DbSet<ItemVASFreight> ItemVASFreight { get; set; }
        public virtual DbSet<ItemVASPropertyValue> ItemVASPropertyValue { get; set; }
        public virtual DbSet<ItemVASPropertyValueChanged> ItemVASPropertyValueChanged { get; set; }
        public virtual DbSet<ItemVASPropertyValueLog> ItemVASPropertyValueLog { get; set; }
        public virtual DbSet<ItemVASPropertyValue_Sync> ItemVASPropertyValue_Sync { get; set; }
        public virtual DbSet<Item_Sync> Item_Sync { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<LetterMoneyOrder> LetterMoneyOrder { get; set; }
        public virtual DbSet<LetterMoneyOrderRule> LetterMoneyOrderRule { get; set; }
        public virtual DbSet<LicenseInformation> LicenseInformation { get; set; }
        public virtual DbSet<LicenseStorage> LicenseStorage { get; set; }
        public virtual DbSet<LimitWeight> LimitWeight { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MailRoute> MailRoute { get; set; }
        public virtual DbSet<MailRoutePOS> MailRoutePOS { get; set; }
        public virtual DbSet<MailRoutePOS_MBCSync> MailRoutePOS_MBCSync { get; set; }
        public virtual DbSet<MailRouteSchedule> MailRouteSchedule { get; set; }
        public virtual DbSet<MailRouteSchedule_MBCSync> MailRouteSchedule_MBCSync { get; set; }
        public virtual DbSet<MailRouteService> MailRouteService { get; set; }
        public virtual DbSet<MailRouteType> MailRouteType { get; set; }
        public virtual DbSet<MailRouteType_MBCSync> MailRouteType_MBCSync { get; set; }
        public virtual DbSet<MailRoute_MBCSync> MailRoute_MBCSync { get; set; }
        public virtual DbSet<MailTripBCCP> MailTripBCCP { get; set; }
        public virtual DbSet<Mailtrip> Mailtrip { get; set; }
        public virtual DbSet<MailtripDelivery> MailtripDelivery { get; set; }
        public virtual DbSet<MailtripItem> MailtripItem { get; set; }
        public virtual DbSet<MailtripPostBagEmpty> MailtripPostBagEmpty { get; set; }
        public virtual DbSet<MailtripTransport> MailtripTransport { get; set; }
        public virtual DbSet<MailtripTransportBC37> MailtripTransportBC37 { get; set; }
        public virtual DbSet<MailtripTransportPostBag> MailtripTransportPostBag { get; set; }
        public virtual DbSet<MailtripTransportPostBagLog> MailtripTransportPostBagLog { get; set; }
        public virtual DbSet<MailtripTransportPostBag_Sync> MailtripTransportPostBag_Sync { get; set; }
        public virtual DbSet<MailtripTransportTrace> MailtripTransportTrace { get; set; }
        public virtual DbSet<MailtripType> MailtripType { get; set; }
        public virtual DbSet<Mailtrip_Sync> Mailtrip_Sync { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuParameter> MenuParameter { get; set; }
        public virtual DbSet<MenuService> MenuService { get; set; }
        public virtual DbSet<MenuVersion> MenuVersion { get; set; }
        public virtual DbSet<MessageType> MessageType { get; set; }
        public virtual DbSet<MessageTypeLastCall> MessageTypeLastCall { get; set; }
        public virtual DbSet<MessageTypeTable> MessageTypeTable { get; set; }
        public virtual DbSet<Mobile_View_DuongThu> Mobile_View_DuongThu { get; set; }
        public virtual DbSet<MoneyOrderRule> MoneyOrderRule { get; set; }
        public virtual DbSet<MoneyOrderStep> MoneyOrderStep { get; set; }
        public virtual DbSet<MoneyOrderValueAddedService> MoneyOrderValueAddedService { get; set; }
        public virtual DbSet<MoneyOrderValueAddedServiceSingeItem> MoneyOrderValueAddedServiceSingeItem { get; set; }
        public virtual DbSet<NearProvince> NearProvince { get; set; }
        public virtual DbSet<NearRegion> NearRegion { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<NodeToNode> NodeToNode { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Notification_User> Notification_User { get; set; }
        public virtual DbSet<OE> OE { get; set; }
        public virtual DbSet<ObjectReceiver> ObjectReceiver { get; set; }
        public virtual DbSet<ObjectRef> ObjectRef { get; set; }
        public virtual DbSet<ObjectSender> ObjectSender { get; set; }
        public virtual DbSet<OfflinePOS> OfflinePOS { get; set; }
        public virtual DbSet<OnlineBatch> OnlineBatch { get; set; }
        public virtual DbSet<OnlineItem> OnlineItem { get; set; }
        public virtual DbSet<OnlineOrder> OnlineOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<POS> POS { get; set; }
        public virtual DbSet<POSConfiguration> POSConfiguration { get; set; }
        public virtual DbSet<POSFreightRegion> POSFreightRegion { get; set; }
        public virtual DbSet<POSInternal> POSInternal { get; set; }
        public virtual DbSet<POSInternalFull> POSInternalFull { get; set; }
        public virtual DbSet<POSLevel> POSLevel { get; set; }
        public virtual DbSet<POSLevel_MBCSync> POSLevel_MBCSync { get; set; }
        public virtual DbSet<POSService> POSService { get; set; }
        public virtual DbSet<POSService_MBCSync> POSService_MBCSync { get; set; }
        public virtual DbSet<POSType> POSType { get; set; }
        public virtual DbSet<POSType_MBCSync> POSType_MBCSync { get; set; }
        public virtual DbSet<POSVersion> POSVersion { get; set; }
        public virtual DbSet<POS_MBCSync> POS_MBCSync { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionAndGroupPermission> PermissionAndGroupPermission { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<Permission_GroupReport_ShiftReport> Permission_GroupReport_ShiftReport { get; set; }
        public virtual DbSet<Permission_Report_ShiftReport> Permission_Report_ShiftReport { get; set; }
        public virtual DbSet<PetrolFreightSurchargeRule> PetrolFreightSurchargeRule { get; set; }
        public virtual DbSet<Phase> Phase { get; set; }
        public virtual DbSet<PhaseQualityTarget> PhaseQualityTarget { get; set; }
        public virtual DbSet<PostBag> PostBag { get; set; }
        public virtual DbSet<PostBagEmpty> PostBagEmpty { get; set; }
        public virtual DbSet<PostBagEmptyInventory> PostBagEmptyInventory { get; set; }
        public virtual DbSet<PostBagLog> PostBagLog { get; set; }
        public virtual DbSet<PostBagType> PostBagType { get; set; }
        public virtual DbSet<Postbag_Sync> Postbag_Sync { get; set; }
        public virtual DbSet<PrintedMatter> PrintedMatter { get; set; }
        public virtual DbSet<PrintedMatterMachine> PrintedMatterMachine { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ProvinceFreightRegion> ProvinceFreightRegion { get; set; }
        public virtual DbSet<ProvinceInterconnect> ProvinceInterconnect { get; set; }
        public virtual DbSet<Province_MBCSync> Province_MBCSync { get; set; }
        public virtual DbSet<QualityTargetRule> QualityTargetRule { get; set; }
        public virtual DbSet<RP_CustomerAcceptanceReports> RP_CustomerAcceptanceReports { get; set; }
        public virtual DbSet<Range> Range { get; set; }
        public virtual DbSet<RangeCause> RangeCause { get; set; }
        public virtual DbSet<RangeCommodityType> RangeCommodityType { get; set; }
        public virtual DbSet<RangeServiceItemType> RangeServiceItemType { get; set; }
        public virtual DbSet<RangeSolution> RangeSolution { get; set; }
        public virtual DbSet<RangeUndeliveryGuide> RangeUndeliveryGuide { get; set; }
        public virtual DbSet<RangeValueAddedServicePhase> RangeValueAddedServicePhase { get; set; }
        public virtual DbSet<RateUser> RateUser { get; set; }
        public virtual DbSet<Receptacles_OETemp> Receptacles_OETemp { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionGroup> RegionGroup { get; set; }
        public virtual DbSet<RegionInterconnect> RegionInterconnect { get; set; }
        public virtual DbSet<RegionType> RegionType { get; set; }
        public virtual DbSet<Region_MBCSync> Region_MBCSync { get; set; }
        public virtual DbSet<ReportManager> ReportManager { get; set; }
        public virtual DbSet<ReportManagerDataSet> ReportManagerDataSet { get; set; }
        public virtual DbSet<ReportManagerGroupBy> ReportManagerGroupBy { get; set; }
        public virtual DbSet<ReportManagerParam> ReportManagerParam { get; set; }
        public virtual DbSet<ReportManagerPrinter> ReportManagerPrinter { get; set; }
        public virtual DbSet<RequestAccepted> RequestAccepted { get; set; }
        public virtual DbSet<RequestAcceptedConfirm> RequestAcceptedConfirm { get; set; }
        public virtual DbSet<RequestAcceptedDetail> RequestAcceptedDetail { get; set; }
        public virtual DbSet<RevenueSharing> RevenueSharing { get; set; }
        public virtual DbSet<RevenueSharingItemType> RevenueSharingItemType { get; set; }
        public virtual DbSet<RevenueSharingRule> RevenueSharingRule { get; set; }
        public virtual DbSet<RevenueSharingValueAddedService> RevenueSharingValueAddedService { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleObject> RoleObject { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesGrantPermission> RolesGrantPermission { get; set; }
        public virtual DbSet<SMS> SMS { get; set; }
        public virtual DbSet<SaleChannel> SaleChannel { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Server1> Server1 { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCommodityType> ServiceCommodityType { get; set; }
        public virtual DbSet<ServiceConfiguration> ServiceConfiguration { get; set; }
        public virtual DbSet<ServiceItemRemaining> ServiceItemRemaining { get; set; }
        public virtual DbSet<ServiceItemType> ServiceItemType { get; set; }
        public virtual DbSet<ServicePOSConfiguration> ServicePOSConfiguration { get; set; }
        public virtual DbSet<ServicePhase> ServicePhase { get; set; }
        public virtual DbSet<ServicePriority> ServicePriority { get; set; }
        public virtual DbSet<ServicePriority_MBCSync> ServicePriority_MBCSync { get; set; }
        public virtual DbSet<ServiceProperty> ServiceProperty { get; set; }
        public virtual DbSet<ServiceSaleChannel> ServiceSaleChannel { get; set; }
        public virtual DbSet<ServiceSupplying> ServiceSupplying { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<ServiceType_MBCSync> ServiceType_MBCSync { get; set; }
        public virtual DbSet<Service_MBCSync> Service_MBCSync { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<ShiftHandover> ShiftHandover { get; set; }
        public virtual DbSet<ShiftHandoverBC37> ShiftHandoverBC37 { get; set; }
        public virtual DbSet<ShiftHandoverDevice> ShiftHandoverDevice { get; set; }
        public virtual DbSet<ShiftHandoverItem> ShiftHandoverItem { get; set; }
        public virtual DbSet<ShiftHandoverMailtrip> ShiftHandoverMailtrip { get; set; }
        public virtual DbSet<ShiftHandoverMailtripDelivery> ShiftHandoverMailtripDelivery { get; set; }
        public virtual DbSet<ShiftHandoverMailtripTransport> ShiftHandoverMailtripTransport { get; set; }
        public virtual DbSet<ShiftHandoverPostBag> ShiftHandoverPostBag { get; set; }
        public virtual DbSet<ShiftHandoverPostBagEmpty> ShiftHandoverPostBagEmpty { get; set; }
        public virtual DbSet<ShiftHandoverRequestAccepted> ShiftHandoverRequestAccepted { get; set; }
        public virtual DbSet<Solution> Solution { get; set; }
        public virtual DbSet<SolutionCustomer> SolutionCustomer { get; set; }
        public virtual DbSet<StampMachine> StampMachine { get; set; }
        public virtual DbSet<StampMachineFeight> StampMachineFeight { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StoreBehavior> StoreBehavior { get; set; }
        public virtual DbSet<StoreDependOn> StoreDependOn { get; set; }
        public virtual DbSet<StoreType> StoreType { get; set; }
        public virtual DbSet<SynchronizationHistory> SynchronizationHistory { get; set; }
        public virtual DbSet<TMSTransport> TMSTransport { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TargetCataloge> TargetCataloge { get; set; }
        public virtual DbSet<TargetParameters> TargetParameters { get; set; }
        public virtual DbSet<TargetValues> TargetValues { get; set; }
        public virtual DbSet<Targets> Targets { get; set; }
        public virtual DbSet<TraceItem> TraceItem { get; set; }
        public virtual DbSet<TraceItem_Sync> TraceItem_Sync { get; set; }
        public virtual DbSet<TracePostBag> TracePostBag { get; set; }
        public virtual DbSet<TracePostBag_Sync> TracePostBag_Sync { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
        public virtual DbSet<TransportError> TransportError { get; set; }
        public virtual DbSet<TransportGroup> TransportGroup { get; set; }
        public virtual DbSet<TransportGroup_MBCSync> TransportGroup_MBCSync { get; set; }
        public virtual DbSet<TransportType> TransportType { get; set; }
        public virtual DbSet<TransportType_MBCSync> TransportType_MBCSync { get; set; }
        public virtual DbSet<Transport_MBCSync> Transport_MBCSync { get; set; }
        public virtual DbSet<UndeliveryGuide> UndeliveryGuide { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }
        public virtual DbSet<UnitType_MBCSync> UnitType_MBCSync { get; set; }
        public virtual DbSet<Unit_MBCSync> Unit_MBCSync { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTargets> UserTargets { get; set; }
        public virtual DbSet<VASProperty> VASProperty { get; set; }
        public virtual DbSet<VASUsing> VASUsing { get; set; }
        public virtual DbSet<ValueAddedService> ValueAddedService { get; set; }
        public virtual DbSet<ValueAddedServiceItem> ValueAddedServiceItem { get; set; }
        public virtual DbSet<ValueAddedServiceItem_Sync> ValueAddedServiceItem_Sync { get; set; }
        public virtual DbSet<ValueAddedServicePhase> ValueAddedServicePhase { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<View_15> View_15 { get; set; }
        public virtual DbSet<View_2> View_2 { get; set; }
        public virtual DbSet<View_3> View_3 { get; set; }
        public virtual DbSet<View_4> View_4 { get; set; }
        public virtual DbSet<View_5> View_5 { get; set; }
        public virtual DbSet<View_717066_MailTrip> View_717066_MailTrip { get; set; }
        public virtual DbSet<View_Acceptance> View_Acceptance { get; set; }
        public virtual DbSet<View_AllTables> View_AllTables { get; set; }
        public virtual DbSet<View_BaoCaoSanLuong> View_BaoCaoSanLuong { get; set; }
        public virtual DbSet<View_CompareRequestAcceptance> View_CompareRequestAcceptance { get; set; }
        public virtual DbSet<View_HCM_All> View_HCM_All { get; set; }
        public virtual DbSet<View_HCM_BK> View_HCM_BK { get; set; }
        public virtual DbSet<View_HCM_GS> View_HCM_GS { get; set; }
        public virtual DbSet<View_HCM_KT1> View_HCM_KT1 { get; set; }
        public virtual DbSet<View_Item_ToanTrinh> View_Item_ToanTrinh { get; set; }
        public virtual DbSet<View_LK_BCUT> View_LK_BCUT { get; set; }
        public virtual DbSet<View_LK_BK_QT> View_LK_BK_QT { get; set; }
        public virtual DbSet<View_LK_BK_TN> View_LK_BK_TN { get; set; }
        public virtual DbSet<View_LK_GS_QT> View_LK_GS_QT { get; set; }
        public virtual DbSet<View_LK_GS_TN> View_LK_GS_TN { get; set; }
        public virtual DbSet<View_LK_KT1> View_LK_KT1 { get; set; }
        public virtual DbSet<View_Mailtrip_Incoming> View_Mailtrip_Incoming { get; set; }
        public virtual DbSet<View_Mailtrip_Incoming_AdditionalInfo> View_Mailtrip_Incoming_AdditionalInfo { get; set; }
        public virtual DbSet<View_Mailtrip_Incoming_Dispatch> View_Mailtrip_Incoming_Dispatch { get; set; }
        public virtual DbSet<View_Mailtrip_Outgoing> View_Mailtrip_Outgoing { get; set; }
        public virtual DbSet<View_Mailtrip_Outgoing_Dispatch> View_Mailtrip_Outgoing_Dispatch { get; set; }
        public virtual DbSet<View_Offline_BK> View_Offline_BK { get; set; }
        public virtual DbSet<View_Offline_BK_LastDay> View_Offline_BK_LastDay { get; set; }
        public virtual DbSet<View_Offline_GS> View_Offline_GS { get; set; }
        public virtual DbSet<View_Offline_GS_LastDay> View_Offline_GS_LastDay { get; set; }
        public virtual DbSet<View_Offline_TT_BK> View_Offline_TT_BK { get; set; }
        public virtual DbSet<View_Offline_TT_BK_LastDay> View_Offline_TT_BK_LastDay { get; set; }
        public virtual DbSet<View_Offline_TT_GS> View_Offline_TT_GS { get; set; }
        public virtual DbSet<View_Offline_TT_GS_LastDay> View_Offline_TT_GS_LastDay { get; set; }
        public virtual DbSet<View_Offline_TT_UT> View_Offline_TT_UT { get; set; }
        public virtual DbSet<View_Offline_TT_UT_LastDay> View_Offline_TT_UT_LastDay { get; set; }
        public virtual DbSet<View_Offline_UT> View_Offline_UT { get; set; }
        public virtual DbSet<View_Offline_UT_LastDay> View_Offline_UT_LastDay { get; set; }
        public virtual DbSet<View_PosExternal> View_PosExternal { get; set; }
        public virtual DbSet<View_PosFull> View_PosFull { get; set; }
        public virtual DbSet<View_PostBagEmpty> View_PostBagEmpty { get; set; }
        public virtual DbSet<View_RequestAccepted> View_RequestAccepted { get; set; }
        public virtual DbSet<View_Tinh_BCUT> View_Tinh_BCUT { get; set; }
        public virtual DbSet<View_Tinh_BCUT_LastDay> View_Tinh_BCUT_LastDay { get; set; }
        public virtual DbSet<View_Tinh_BK> View_Tinh_BK { get; set; }
        public virtual DbSet<View_Tinh_BK_QT> View_Tinh_BK_QT { get; set; }
        public virtual DbSet<View_Tinh_BK_QT_LastDay> View_Tinh_BK_QT_LastDay { get; set; }
        public virtual DbSet<View_Tinh_BK_TN> View_Tinh_BK_TN { get; set; }
        public virtual DbSet<View_Tinh_BK_TN_LastDay> View_Tinh_BK_TN_LastDay { get; set; }
        public virtual DbSet<View_Tinh_GS> View_Tinh_GS { get; set; }
        public virtual DbSet<View_Tinh_GS_QT> View_Tinh_GS_QT { get; set; }
        public virtual DbSet<View_Tinh_GS_QT_LastDay> View_Tinh_GS_QT_LastDay { get; set; }
        public virtual DbSet<View_Tinh_GS_TN> View_Tinh_GS_TN { get; set; }
        public virtual DbSet<View_Tinh_GS_TN_LastDay> View_Tinh_GS_TN_LastDay { get; set; }
        public virtual DbSet<View_Tinh_KT1> View_Tinh_KT1 { get; set; }
        public virtual DbSet<View_Tinh_KT11> View_Tinh_KT11 { get; set; }
        public virtual DbSet<View_Tinh_KT11_LastDay> View_Tinh_KT11_LastDay { get; set; }
        public virtual DbSet<View_TraCuu_ToanTrinh> View_TraCuu_ToanTrinh { get; set; }
        public virtual DbSet<View_TraCuu_ToanTrinh_Report> View_TraCuu_ToanTrinh_Report { get; set; }
        public virtual DbSet<View_TraceItemLast> View_TraceItemLast { get; set; }
        public virtual DbSet<View_sp_BaoCaoChuyenThuNoiTinh> View_sp_BaoCaoChuyenThuNoiTinh { get; set; }
        public virtual DbSet<View_sp_GetUser> View_sp_GetUser { get; set; }
        public virtual DbSet<View_sp_Report_Mailtrip_Incoming> View_sp_Report_Mailtrip_Incoming { get; set; }
        public virtual DbSet<Warning> Warning { get; set; }
        public virtual DbSet<WebsiteSupport> WebsiteSupport { get; set; }
        public virtual DbSet<WholeQualityTarget> WholeQualityTarget { get; set; }
        public virtual DbSet<bcn_Commissiontodelivery_LevelWeight> bcn_Commissiontodelivery_LevelWeight { get; set; }
        public virtual DbSet<bcn_Commissiontodelivery_SubOffice> bcn_Commissiontodelivery_SubOffice { get; set; }
        public virtual DbSet<bcn_commissiontodelivery> bcn_commissiontodelivery { get; set; }
        public virtual DbSet<bcn_commissiontodeliveryspecial> bcn_commissiontodeliveryspecial { get; set; }
        public virtual DbSet<sp_BangKe_BuuGui_ChuyenPhat> sp_BangKe_BuuGui_ChuyenPhat { get; set; }
        public virtual DbSet<temptmp_Item_0312> temptmp_Item_0312 { get; set; }
        public virtual DbSet<tmp_Transport> tmp_Transport { get; set; }
        public virtual DbSet<vSelectItemsByBatchCode> vSelectItemsByBatchCode { get; set; }
        public virtual DbSet<vSelectUserBelongGroup> vSelectUserBelongGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=vnpost.ddns.net;Database=KT1;User ID=sa;Password=bccp@123;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLogType>(entity =>
            {
                entity.Property(e => e.ActionKeyword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Affair>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.ItemID });

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.AffairCODStatus).HasComment("0:Khởi tạo sự vụ; 1:Phê duyệt không chấp nhận; 2:Phê duyệt chấp nhận cấp 1; 3:Phê duyệt không chấp nhận cấp 2; 4:Phê duyệt chấp nhận cấp 2");

                entity.Property(e => e.AffairContent).HasMaxLength(50);

                entity.Property(e => e.AffairDate).HasColumnType("datetime");

                entity.Property(e => e.AffairLevel).HasComment("Cấp xử lý. 1: Cấp bưu cục (mặc định); 2: Cấp tỉnh (khi chuyển)");

                entity.Property(e => e.AffairNumber).HasMaxLength(12);

                entity.Property(e => e.ApprovedContentLevelOne).HasMaxLength(500);

                entity.Property(e => e.ApprovedContentLevelTwo).HasMaxLength(500);

                entity.Property(e => e.ApprovedDateLevelOne).HasColumnType("datetime");

                entity.Property(e => e.ApprovedDateLevelTwo).HasColumnType("datetime");

                entity.Property(e => e.ApprovedPOSLevelOne).HasMaxLength(100);

                entity.Property(e => e.ApprovedPOSLevelTwo).HasMaxLength(100);

                entity.Property(e => e.ApprovedUserLevelOne).HasMaxLength(200);

                entity.Property(e => e.ApprovedUserLevelTwo).HasMaxLength(200);

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.ClosedPOSCode).HasMaxLength(6);

                entity.Property(e => e.ClosedTime).HasColumnType("datetime");

                entity.Property(e => e.CollectionPerson).HasMaxLength(50);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Demonstration).HasMaxLength(255);

                entity.Property(e => e.DistrictNew).HasMaxLength(50);

                entity.Property(e => e.DistrictOld).HasMaxLength(50);

                entity.Property(e => e.InputUser).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(50);

                entity.Property(e => e.MailTripNumber).HasMaxLength(4);

                entity.Property(e => e.PostBagNumber).HasMaxLength(3);

                entity.Property(e => e.Processing).HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceNew).HasMaxLength(50);

                entity.Property(e => e.ProvinceOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverAddressNew).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverContact).HasMaxLength(50);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(100);

                entity.Property(e => e.ReceiverFullnameNew).HasMaxLength(50);

                entity.Property(e => e.ReceiverFullnameOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentificationNew).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentificationOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverPosCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.ReturnPerson).HasMaxLength(50);

                entity.Property(e => e.SenderAddressNew).HasMaxLength(50);

                entity.Property(e => e.SenderAddressOld).HasMaxLength(50);

                entity.Property(e => e.ToPoscode).HasMaxLength(6);

                entity.Property(e => e.TransactionsPaymentCode).HasMaxLength(50);

                entity.Property(e => e.TransactionsReceiverCode).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Affair)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affair_ItemReturn");
            });

            modelBuilder.Entity<AffairDetailItem>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.ItemIndex, e.ItemID });

                entity.Property(e => e.ChemicalItemName).HasMaxLength(500);

                entity.Property(e => e.ChemicalItemNameOld).HasMaxLength(500);

                entity.Property(e => e.ChemicalName).HasMaxLength(500);

                entity.Property(e => e.ChemicalNameOld).HasMaxLength(500);

                entity.Property(e => e.ChemicalTypeCode).HasMaxLength(5);

                entity.Property(e => e.ChemicalTypeCodeOld).HasMaxLength(5);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DetailItemName).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OriginalCountryCode).HasMaxLength(3);

                entity.Property(e => e.OriginalCountryCodeOld).HasMaxLength(3);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.TaxCodeOld).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.UnitOld).HasMaxLength(50);
            });

            modelBuilder.Entity<AffairHistory>(entity =>
            {
                entity.Property(e => e.AffairHistoryId).ValueGeneratedNever();

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.HistoryContent).HasMaxLength(1000);

                entity.Property(e => e.HistoryCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HistoryCreatedPOS).HasMaxLength(200);

                entity.Property(e => e.HistoryCreator).HasMaxLength(100);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AffairItem>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.ItemID });

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AffairItemVASPropertyValue>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.PropertyCode, e.ValueAddedServiceCode, e.ItemID })
                    .HasName("PK_AffairItemVASPropertyValue_1");

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Value).HasMaxLength(500);
            });

            modelBuilder.Entity<AffairMessage>(entity =>
            {
                entity.Property(e => e.AttachmentFileName).HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<AffairMessagePOS>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.ToPosCode).HasMaxLength(6);

                entity.HasOne(d => d.AffairMessage)
                    .WithMany(p => p.AffairMessagePOS)
                    .HasForeignKey(d => d.AffairMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairMessagePOS_AffairMessage");
            });

            modelBuilder.Entity<AffairResponse>(entity =>
            {
                entity.Property(e => e.AffairResponseID).ValueGeneratedNever();

                entity.Property(e => e.AffairProcess).HasMaxLength(250);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Demonstration)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.POSResponse).HasMaxLength(6);

                entity.Property(e => e.UserResponse).HasMaxLength(50);
            });

            modelBuilder.Entity<AffairServedFreight>(entity =>
            {
                entity.HasKey(e => new { e.AffairTypeCode, e.ServiceCode, e.ValueAddedServiceCode, e.ItemStatusCode, e.RangeCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.AffairServedFreight)
                    .HasForeignKey(d => d.RangeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairServedFreight_Range");

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.AffairServedFreight)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairServedFreight_VASUsing");
            });

            modelBuilder.Entity<AffairTransactionsCollection>(entity =>
            {
                entity.HasKey(e => e.AffairTransactionsCollection1);

                entity.Property(e => e.AffairTransactionsCollection1)
                    .HasColumnName("AffairTransactionsCollection")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCertificateIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverCertificateNumber).HasMaxLength(50);

                entity.Property(e => e.ReceiverCertificateOtherName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCertificatePlace).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(100);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.TransactionsCollectionChannel).HasMaxLength(50);

                entity.Property(e => e.TransactionsCollectionCode).HasMaxLength(50);

                entity.Property(e => e.TransactionsCollectionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AffairTransport>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.FromPOSCode });

                entity.Property(e => e.AffairIndex).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(50);

                entity.Property(e => e.AffairContent).HasMaxLength(3000);

                entity.Property(e => e.AffairDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.InputUser).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(50);

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(50);

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.TransportCode).HasMaxLength(50);

                entity.Property(e => e.TransportDate).HasMaxLength(8);

                entity.Property(e => e.TransportNumber).HasMaxLength(3);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AffairVASItem>(entity =>
            {
                entity.HasKey(e => new { e.AffairIndex, e.ServiceCode, e.ValueAddedServiceCode, e.ItemID })
                    .HasName("PK_AffairVASItem_1");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PhaseCode).HasMaxLength(3);
            });

            modelBuilder.Entity<AffairValue>(entity =>
            {
                entity.HasKey(e => e.AffairID);

                entity.Property(e => e.AffairID).ValueGeneratedNever();

                entity.Property(e => e.AffairName).HasMaxLength(50);
            });

            modelBuilder.Entity<AffairValueAddedService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ValueAddedServiceCode, e.ItemStatusCode, e.RangeCode, e.AffairTypeCode })
                    .HasName("PK_AffairService");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.AffairValueAddedService)
                    .HasForeignKey(d => d.RangeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairService_Range");

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.AffairValueAddedService)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairService_VASUsing");
            });

            modelBuilder.Entity<Affair_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.AffairContent).HasMaxLength(500);

                entity.Property(e => e.AffairDate).HasColumnType("datetime");

                entity.Property(e => e.AffairNumber).HasMaxLength(12);

                entity.Property(e => e.ApprovedContentLevelOne).HasMaxLength(500);

                entity.Property(e => e.ApprovedContentLevelTwo).HasMaxLength(500);

                entity.Property(e => e.ApprovedDateLevelOne).HasColumnType("datetime");

                entity.Property(e => e.ApprovedDateLevelTwo).HasColumnType("datetime");

                entity.Property(e => e.ApprovedPOSLevelOne).HasMaxLength(100);

                entity.Property(e => e.ApprovedPOSLevelTwo).HasMaxLength(100);

                entity.Property(e => e.ApprovedUserLevelOne).HasMaxLength(200);

                entity.Property(e => e.ApprovedUserLevelTwo).HasMaxLength(200);

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.ClosedPOSCode).HasMaxLength(6);

                entity.Property(e => e.ClosedTime).HasColumnType("datetime");

                entity.Property(e => e.CollectionPerson).HasMaxLength(50);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Demonstration).HasMaxLength(255);

                entity.Property(e => e.DistrictNew).HasMaxLength(50);

                entity.Property(e => e.DistrictOld).HasMaxLength(50);

                entity.Property(e => e.InputUser).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemTypeCodeNew).HasMaxLength(2);

                entity.Property(e => e.ItemTypeCodeOld).HasMaxLength(2);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(50);

                entity.Property(e => e.MailTripNumber).HasMaxLength(4);

                entity.Property(e => e.PostBagNumber).HasMaxLength(3);

                entity.Property(e => e.Processing).HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceNew).HasMaxLength(50);

                entity.Property(e => e.ProvinceOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(7);

                entity.Property(e => e.ReceiverAddressNew).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverContact).HasMaxLength(50);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(100);

                entity.Property(e => e.ReceiverFullnameNew).HasMaxLength(50);

                entity.Property(e => e.ReceiverFullnameOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentificationNew).HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentificationOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverPosCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.ReturnPerson).HasMaxLength(50);

                entity.Property(e => e.SenderAddressNew).HasMaxLength(50);

                entity.Property(e => e.SenderAddressOld).HasMaxLength(50);

                entity.Property(e => e.ToPoscode).HasMaxLength(6);

                entity.Property(e => e.TransactionsPaymentCode).HasMaxLength(50);

                entity.Property(e => e.TransactionsReceiverCode).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "KT1");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicationVersion>(entity =>
            {
                entity.HasKey(e => e.ApplicationVersionNumber);

                entity.Property(e => e.ApplicationVersionNumber).HasMaxLength(10);

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RequiredDbVersionNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.VersionChanges).HasMaxLength(500);
            });

            modelBuilder.Entity<BC37>(entity =>
            {
                entity.Property(e => e.BC37ID).ValueGeneratedNever();

                entity.Property(e => e.BC37Code).HasMaxLength(50);

                entity.Property(e => e.BC37Date)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.MailRouteFromPOSCode).HasMaxLength(6);

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(6);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasComment("0:Khởi tạo;1:Đã đi;2:Đã xác nhận");

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<BC37BCCP>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BC37Date)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<BC37Route>(entity =>
            {
                entity.HasKey(e => new { e.FromPOSCode, e.ToPOSCode, e.AcceptedPOSCode });

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.AcceptedPOSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<BC37RouteType>(entity =>
            {
                entity.HasKey(e => e.TypeID);

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<BC37_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BC37Code).HasMaxLength(50);

                entity.Property(e => e.BC37Date)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.MailRouteFromPOSCode).HasMaxLength(6);

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(6);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<BC43>(entity =>
            {
                entity.HasKey(e => new { e.BC43Code, e.FromPosCode })
                    .HasName("PK_BC43_1");

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.AttachmentFileName).HasMaxLength(500);

                entity.Property(e => e.BC37Code).HasMaxLength(50);

                entity.Property(e => e.BC37Date).HasMaxLength(8);

                entity.Property(e => e.BC37FromPosCode).HasMaxLength(6);

                entity.Property(e => e.BC37ToPosCode).HasMaxLength(6);

                entity.Property(e => e.BC37TransportTypeCode).HasMaxLength(1);

                entity.Property(e => e.BC43Content).HasMaxLength(4000);

                entity.Property(e => e.BC43Creator).HasMaxLength(200);

                entity.Property(e => e.BC43LeaderOfPos).HasMaxLength(200);

                entity.Property(e => e.BC43ReplyFromReceptionPOS).HasMaxLength(1000);

                entity.Property(e => e.BC43Type).HasComment("Loại BC43: mất, chậm, hư hỏng, thiếu, suy chuyển");

                entity.Property(e => e.BC43ViewPOS).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiredDateBigCustomer).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripDate).HasColumnType("datetime");

                entity.Property(e => e.MailTripDestinationCode).HasMaxLength(6);

                entity.Property(e => e.MailTripNumber).HasMaxLength(4);

                entity.Property(e => e.MailTripServiceCode).HasMaxLength(2);

                entity.Property(e => e.MailTripStartingCode).HasMaxLength(6);

                entity.Property(e => e.MailTripType).HasMaxLength(1);

                entity.Property(e => e.MailTripYear).HasMaxLength(8);

                entity.Property(e => e.ReasonCreateBC43).HasMaxLength(2000);

                entity.HasOne(d => d.BC43TypeNavigation)
                    .WithMany(p => p.BC43)
                    .HasForeignKey(d => d.BC43Type)
                    .HasConstraintName("FK_BC43_BC43Type");
            });

            modelBuilder.Entity<BC43Affair>(entity =>
            {
                entity.HasKey(e => new { e.BC43Code, e.FromPosCode, e.ToPosCode });

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.ToPosCode).HasMaxLength(6);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsClosed).HasComment("Sự vụ được đóng hay chưa?");

                entity.Property(e => e.IsForwardedPosCode).HasComment("True: Đây là sự vụ được chuyển tiếp;");

                entity.Property(e => e.IsReplied).HasComment("Trạng thái đã trả lời hay chưa?");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LeaderOfToPosCode).HasMaxLength(200);

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyFromToPosCode).HasMaxLength(4000);

                entity.Property(e => e.ReplyPersonName).HasMaxLength(200);

                entity.Property(e => e.ResolveAffairPosCode)
                    .HasMaxLength(8)
                    .HasComment("Bưu cục được chỉ định giải quyết sự vụ");

                entity.HasOne(d => d.BC43)
                    .WithMany(p => p.BC43Affair)
                    .HasForeignKey(d => new { d.BC43Code, d.FromPosCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BC43Affair_BC43");
            });

            modelBuilder.Entity<BC43Dispatch>(entity =>
            {
                entity.HasKey(e => new { e.BC43Code, e.FromPosCode, e.ToPosCode, e.PostBagIndex, e.PostBagFromPosCode, e.PostBagToPosCode, e.PostBagMailTripType, e.PostBagServiceCode, e.PostBagYear, e.PostBagMailTripNumber, e.ItemCode });

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.ToPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagFromPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagToPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagMailTripType).HasMaxLength(1);

                entity.Property(e => e.PostBagServiceCode).HasMaxLength(2);

                entity.Property(e => e.PostBagYear).HasMaxLength(8);

                entity.Property(e => e.PostBagMailTripNumber).HasMaxLength(4);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AdviceOfReceiptCode).HasMaxLength(13);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CODAddress).HasMaxLength(200);

                entity.Property(e => e.CertificateNumber).HasMaxLength(50);

                entity.Property(e => e.CheckContentOnDeliveryCode).HasMaxLength(13);

                entity.Property(e => e.CheckSum).HasMaxLength(1);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerAccountNo).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.CustomerGroupCode).HasMaxLength(20);

                entity.Property(e => e.DataCode).HasMaxLength(50);

                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.DecisionNo).HasMaxLength(500);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.ExchangeRateCode).HasMaxLength(50);

                entity.Property(e => e.ExecuteOrder).HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ItemCodeCorrect).HasMaxLength(13);

                entity.Property(e => e.ItemNumber).HasMaxLength(50);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.MachineName).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.OtherAttachedInfor).HasMaxLength(100);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(50);

                entity.Property(e => e.ReceiverCustomReference).HasMaxLength(500);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverJob).HasMaxLength(500);

                entity.Property(e => e.ReceiverMobile).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.ReturnBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.SectionCode).HasMaxLength(3);

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderAddressCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomReference).HasMaxLength(500);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SenderIdentification).HasMaxLength(50);

                entity.Property(e => e.SenderIssueCountry).HasMaxLength(50);

                entity.Property(e => e.SenderIssueDate).HasColumnType("datetime");

                entity.Property(e => e.SenderJob).HasMaxLength(500);

                entity.Property(e => e.SenderMobile).HasMaxLength(15);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(20);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.UndeliverableReason).HasMaxLength(500);
            });

            modelBuilder.Entity<BC43PostBag>(entity =>
            {
                entity.HasKey(e => new { e.BC43Code, e.FromPosCode, e.ToPosCode, e.PostBagIndex, e.PostBagFromPosCode, e.PostBagToPosCode, e.PostBagMailTripType, e.PostBagServiceCode, e.PostBagYear, e.PostBagMailTripNumber, e.PostBagCode });

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.ToPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagFromPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagToPosCode).HasMaxLength(6);

                entity.Property(e => e.PostBagMailTripType).HasMaxLength(1);

                entity.Property(e => e.PostBagServiceCode).HasMaxLength(2);

                entity.Property(e => e.PostBagYear).HasMaxLength(8);

                entity.Property(e => e.PostBagMailTripNumber).HasMaxLength(4);

                entity.Property(e => e.PostBagCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCodeCorrect).HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BC43Type>(entity =>
            {
                entity.HasKey(e => e.BC43Type1);

                entity.Property(e => e.BC43Type1)
                    .HasColumnName("BC43Type")
                    .ValueGeneratedNever();

                entity.Property(e => e.BC43Description).HasMaxLength(500);

                entity.Property(e => e.BC43TypeName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BCCL_Region>(entity =>
            {
                entity.HasKey(e => e.RegionID);

                entity.Property(e => e.RegionID).ValueGeneratedNever();

                entity.Property(e => e.ProvinceCode_Center).HasMaxLength(6);

                entity.Property(e => e.RegionName).HasMaxLength(200);
            });

            modelBuilder.Entity<BCCL_RegionProvince>(entity =>
            {
                entity.HasKey(e => new { e.RegionID, e.ProvinceCode });

                entity.Property(e => e.ProvinceCode).HasMaxLength(6);
            });

            modelBuilder.Entity<BCNConstance>(entity =>
            {
                entity.HasKey(e => e.ParCode);

                entity.Property(e => e.ParCode).HasMaxLength(100);

                entity.Property(e => e.ParValue).HasMaxLength(20);
            });

            modelBuilder.Entity<BCNServiceList>(entity =>
            {
                entity.Property(e => e.CurrentIndex)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrentIndexOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrentIndexSort)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemTypeCode).HasMaxLength(10);

                entity.Property(e => e.LevelValue)
                    .HasMaxLength(10)
                    .HasComment("1: Nội tỉnh, 2: Liên tỉnh, 3: Quốc tế");

                entity.Property(e => e.LevelValueName).HasMaxLength(30);

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(10)
                    .HasComment("Mã dịch vụ");

                entity.Property(e => e.ServiceCodeName).HasMaxLength(30);

                entity.Property(e => e.ServiceName).HasMaxLength(150);

                entity.Property(e => e.ServiceNameCombobox).HasMaxLength(128);

                entity.Property(e => e.ValueAddedServiceCode)
                    .HasMaxLength(10)
                    .HasComment("Mã dịch vụ cộng thêm hoặc loại bưu gửi");

                entity.Property(e => e.ValueAddedServiceCodeRef).HasMaxLength(10);
            });

            modelBuilder.Entity<BCN_PCDT>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BieuMau).HasMaxLength(3);

                entity.Property(e => e.DenNgay).HasColumnType("datetime");

                entity.Property(e => e.DichVu).HasMaxLength(2);

                entity.Property(e => e.DichVuCongThem).HasMaxLength(4);

                entity.Property(e => e.GiaTri).HasMaxLength(128);

                entity.Property(e => e.TuNgay).HasColumnType("datetime");
            });

            modelBuilder.Entity<BD21AffairResponse>(entity =>
            {
                entity.HasKey(e => e.AffairResponseNumber)
                    .HasName("PK_AffairResponse");

                entity.Property(e => e.AffairResponseNumber).HasMaxLength(12);

                entity.Property(e => e.AffairResultContent).HasMaxLength(1000);

                entity.Property(e => e.Answer).HasMaxLength(2000);

                entity.Property(e => e.AnswerAtRelatePos).HasMaxLength(2000);

                entity.Property(e => e.AnswerDate).HasColumnType("datetime");

                entity.Property(e => e.AnswerUser).HasMaxLength(50);

                entity.Property(e => e.AttachmentFile).HasMaxLength(500);

                entity.Property(e => e.AttachmentFileReply).HasMaxLength(1000);

                entity.Property(e => e.BC43Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BD10FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OtherBD10Code).HasMaxLength(500);

                entity.Property(e => e.Question).HasMaxLength(2000);

                entity.Property(e => e.ReasonNotAccept).HasMaxLength(500);

                entity.Property(e => e.ReceivingTime).HasColumnType("datetime");

                entity.Property(e => e.ReceivingUser).HasMaxLength(50);

                entity.Property(e => e.ResponseDateExpired).HasColumnType("datetime");

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.SendingUser).HasMaxLength(50);

                entity.Property(e => e.SentBackTime).HasColumnType("datetime");

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.HasOne(d => d.BC43)
                    .WithMany(p => p.BD21AffairResponse)
                    .HasForeignKey(d => new { d.BC43Code, d.FromPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AffairResponse_BC43");
            });

            modelBuilder.Entity<BD21Disscusion>(entity =>
            {
                entity.HasKey(e => new { e.CreatedDate, e.MailtripPOS, e.BC43Code, e.FromPosCode })
                    .HasName("PK_[Message");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MailtripPOS).HasMaxLength(6);

                entity.Property(e => e.BC43Code).HasMaxLength(50);

                entity.Property(e => e.FromPosCode).HasMaxLength(6);

                entity.Property(e => e.AttachmentFileName).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DisscusionContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.ReplyUser).HasMaxLength(100);
            });

            modelBuilder.Entity<BD21History>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.HistoryId).HasMaxLength(100);

                entity.Property(e => e.BD21Code).HasMaxLength(30);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedPOS)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HistoryContent)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.RelateCode).HasMaxLength(100);
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasKey(e => e.BatchCode);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.OtherAttachedInfor).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Batch)
                    .HasForeignKey(d => new { d.OrderCode, d.POSCode, d.CustomerCode })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Batch_Order1");
            });

            modelBuilder.Entity<BatchPOS>(entity =>
            {
                entity.HasKey(e => e.BatchCode);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.BatchPOS)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_BatchPOS_POS");
            });

            modelBuilder.Entity<Batch_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BatchCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.OtherAttachedInfor).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<BusinessDomain>(entity =>
            {
                entity.HasKey(e => e.BusinessDomainCode);

                entity.Property(e => e.BusinessDomainCode).HasMaxLength(5);

                entity.Property(e => e.BusinessDomainName).HasMaxLength(50);
            });

            modelBuilder.Entity<BuuGuiWithAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BuuGuiWithAddress");

                entity.Property(e => e.DeliveryPointCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemCodeCustomer).HasMaxLength(500);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverInfor)
                    .IsRequired()
                    .HasMaxLength(1505);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SenderCustomerName).HasMaxLength(100);

                entity.Property(e => e.SenderInfor)
                    .IsRequired()
                    .HasMaxLength(1001);
            });

            modelBuilder.Entity<CN08>(entity =>
            {
                entity.HasKey(e => e.CN08Code);

                entity.Property(e => e.CN08Code).HasMaxLength(12);

                entity.Property(e => e.CN08CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CN08Note).HasMaxLength(500);

                entity.Property(e => e.CN08OtherResult).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CN48>(entity =>
            {
                entity.HasKey(e => e.CN48Code);

                entity.Property(e => e.CN48Code).HasMaxLength(12);

                entity.Property(e => e.AttachmentFileName).HasMaxLength(500);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UnitCode).HasMaxLength(6);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CN48Item>(entity =>
            {
                entity.HasKey(e => new { e.CN48Code, e.ItemCode, e.AcceptancePOSCode, e.ReferenceCode })
                    .HasName("PK_CN48Item_1");

                entity.Property(e => e.CN48Code).HasMaxLength(12);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.ReferenceCode).HasMaxLength(80);

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DateOfPosting).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Destination).HasMaxLength(100);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.CN48CodeNavigation)
                    .WithMany(p => p.CN48Item)
                    .HasForeignKey(d => d.CN48Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CN48Item_CN48");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.CategoryCode, e.ServiceCode });

                entity.Property(e => e.CategoryCode).HasMaxLength(2);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Cause>(entity =>
            {
                entity.HasKey(e => e.CauseCode);

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.DeliveryType).HasComment("0 - Tại địa chỉ, 1 - Tại bưu cục, 2 - Tất cả");

                entity.Property(e => e.EnglishCauseName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RangeCause).HasComment("0 - Trong nước,1 - Quốc tế , 3 - Tất cả");

                entity.Property(e => e.VietnameseCauseName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CauseCustomer>(entity =>
            {
                entity.HasKey(e => new { e.CauseCode, e.CustomerCode });

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.HasOne(d => d.CauseCodeNavigation)
                    .WithMany(p => p.CauseCustomer)
                    .HasForeignKey(d => d.CauseCode)
                    .HasConstraintName("FK_CauseCustomer_Cause");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.CauseCustomer)
                    .HasForeignKey(d => d.CustomerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CauseCustomer_Customer");
            });

            modelBuilder.Entity<CauseSolution>(entity =>
            {
                entity.HasKey(e => new { e.CauseCode, e.SolutionCode });

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.HasOne(d => d.CauseCodeNavigation)
                    .WithMany(p => p.CauseSolution)
                    .HasForeignKey(d => d.CauseCode)
                    .HasConstraintName("FK_CauseSolution_Cause");

                entity.HasOne(d => d.SolutionCodeNavigation)
                    .WithMany(p => p.CauseSolution)
                    .HasForeignKey(d => d.SolutionCode)
                    .HasConstraintName("FK_CauseSolution_Solution");
            });

            modelBuilder.Entity<ChangeReason>(entity =>
            {
                entity.HasKey(e => e.ChangeReasonCode);

                entity.Property(e => e.ChangeReasonCode).ValueGeneratedNever();

                entity.Property(e => e.ChangeReasonName).HasMaxLength(200);
            });

            modelBuilder.Entity<ChangedItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemChangedIndex, e.ItemID })
                    .HasName("PK_ChangedItem_1");

                entity.Property(e => e.ChangedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemCodeOld)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<ChemicalType>(entity =>
            {
                entity.HasKey(e => e.ChemicalTypeCode);

                entity.Property(e => e.ChemicalTypeCode).HasMaxLength(5);

                entity.Property(e => e.ChemicalTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.RecevingClaimPOSCode });

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.RecevingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.AttachmentFileName).HasMaxLength(500);

                entity.Property(e => e.BigCustomerCode).HasMaxLength(50);

                entity.Property(e => e.CN08Code).HasMaxLength(12);

                entity.Property(e => e.ClaimContent).HasMaxLength(2000);

                entity.Property(e => e.ClaimCreator).HasMaxLength(200);

                entity.Property(e => e.ClaimDateExpired).HasColumnType("datetime");

                entity.Property(e => e.ClaimPersonAddress).HasMaxLength(200);

                entity.Property(e => e.ClaimPersonEmail).HasMaxLength(50);

                entity.Property(e => e.ClaimPersonName).HasMaxLength(50);

                entity.Property(e => e.ClaimPersonTel).HasMaxLength(50);

                entity.Property(e => e.ClaimPriorityCode).HasMaxLength(5);

                entity.Property(e => e.ClaimReceivingTime).HasColumnType("datetime");

                entity.Property(e => e.ClaimTime).HasColumnType("datetime");

                entity.Property(e => e.ClaimTypeCode).HasMaxLength(5);

                entity.Property(e => e.ClaimTypeOther).HasMaxLength(500);

                entity.Property(e => e.ClosingTime).HasColumnType("datetime");

                entity.Property(e => e.ClosingUser).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.HeadOfRecevingUnit).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.OpeningReason).HasMaxLength(200);

                entity.Property(e => e.OpeningTime).HasColumnType("datetime");

                entity.Property(e => e.OpeningUser).HasMaxLength(50);

                entity.Property(e => e.ResolveClaimPosCode).HasMaxLength(6);

                entity.HasOne(d => d.ClaimAnswerMethodCodeNavigation)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.ClaimAnswerMethodCode)
                    .HasConstraintName("FK_Claim_ClaimAnswerMethod");

                entity.HasOne(d => d.ClaimDirectionCodeNavigation)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.ClaimDirectionCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Claim_ClaimDirection");

                entity.HasOne(d => d.ClaimPriorityCodeNavigation)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.ClaimPriorityCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Claim_ClaimPriority");

                entity.HasOne(d => d.ClaimTypeCodeNavigation)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.ClaimTypeCode)
                    .HasConstraintName("FK_Claim_ClaimType");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Claim_ClaimStatus");
            });

            modelBuilder.Entity<ClaimAnswerMethod>(entity =>
            {
                entity.HasKey(e => e.ClaimAnswerMethodCode)
                    .HasName("PK__ClaimAns__07AAC4FB1D1D0420");

                entity.Property(e => e.ClaimAnswerMethodCode).ValueGeneratedNever();

                entity.Property(e => e.ClaimAnswerMethodDescription).HasMaxLength(500);

                entity.Property(e => e.ClaimAnswerMethodName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ClaimCompensate>(entity =>
            {
                entity.HasKey(e => e.ClaimCompensateCode);

                entity.Property(e => e.ClaimCompensateCode).HasMaxLength(12);

                entity.Property(e => e.AttachmentFile).HasMaxLength(1000);

                entity.Property(e => e.ClaimCompensateRuleCode).HasMaxLength(10);

                entity.Property(e => e.ClaimNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.CompensateMoney).HasComment("Tiền Bồi thường khách hàng");

                entity.Property(e => e.CompensateReason).HasMaxLength(2000);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatorName).HasMaxLength(50);

                entity.Property(e => e.CreatorPOSCode).HasMaxLength(6);

                entity.Property(e => e.CustomerFreightPaid).HasComment("Cước KH đã trả");

                entity.Property(e => e.CustomerReturnMoney).HasComment("Tiền hoàn lại KH");

                entity.Property(e => e.DamagedOrLostWeight).HasComment("Khối lượng bưu gửi hỏng");

                entity.Property(e => e.DamagedWeightPercent).HasComment("Phần trăm khối lượng hỏng");

                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.DecisionSigner).HasMaxLength(50);

                entity.Property(e => e.HandlerName).HasMaxLength(50);

                entity.Property(e => e.HandlerPOSCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.PaidPOSCode).HasMaxLength(6);

                entity.Property(e => e.PaidPerson).HasMaxLength(200);

                entity.Property(e => e.ReceivingClaimPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.TotalCompensateMoneyPayCustomer).HasComment("Tổng số tiền cần bồi thường");

                entity.Property(e => e.TotalItemWeight).HasComment("Tổng khối lượng bưu gửi");

                entity.HasOne(d => d.ClaimCompensateRule)
                    .WithMany(p => p.ClaimCompensate)
                    .HasForeignKey(d => new { d.ClaimCompensateRuleCode, d.ServiceCode })
                    .HasConstraintName("FK_ClaimCompensate_ClaimCompensateRule1");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimCompensate)
                    .HasForeignKey(d => new { d.ClaimNumber, d.ReceivingClaimPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimCompensate_Claim");
            });

            modelBuilder.Entity<ClaimCompensateRule>(entity =>
            {
                entity.HasKey(e => new { e.ClaimCompensateRuleCode, e.ServiceCode });

                entity.Property(e => e.ClaimCompensateRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CompensateCategoryCode)
                    .HasMaxLength(10)
                    .HasComment("Mã loại BT");

                entity.Property(e => e.CompensateFreightFormula)
                    .HasMaxLength(1000)
                    .HasComment("Cước bồi thường");

                entity.Property(e => e.CompensateFreightMaxFormula)
                    .HasMaxLength(500)
                    .HasComment("Giá trị BT lớn nhất");

                entity.Property(e => e.CompensateFreightMinFormula).HasMaxLength(500);

                entity.Property(e => e.CompensateItemFreightSentFormula)
                    .HasMaxLength(1000)
                    .HasComment("Cước BT cước ký gửi");

                entity.Property(e => e.CompensateResultCode)
                    .HasMaxLength(1)
                    .HasComment("Mã Kết quả BT");

                entity.Property(e => e.ExchangeRateCode)
                    .HasMaxLength(50)
                    .HasComment("Mã tỷ giá");

                entity.Property(e => e.IsDomestic).HasComment("Trong nước/Quốc tế");

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(100)
                    .HasComment("Mã bưu phẩm (BPquốc tế)");

                entity.Property(e => e.RuleNo)
                    .HasMaxLength(50)
                    .HasComment("Số luật QĐ ban hành");

                entity.Property(e => e.TransportTypeCode)
                    .HasMaxLength(2)
                    .HasComment("Mã phương tiện vận chuyển (BK quốc tế)");

                entity.Property(e => e.ValueDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày áp dụng");
            });

            modelBuilder.Entity<ClaimConclusion>(entity =>
            {
                entity.HasKey(e => e.ClaimConclusionCode)
                    .HasName("PK__ClaimCon__27E3369C194C733C");

                entity.Property(e => e.ClaimConclusionCode).HasMaxLength(14);

                entity.Property(e => e.ClaimConclusionDescription).HasMaxLength(500);

                entity.Property(e => e.ClaimConclusionName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ClaimDirection>(entity =>
            {
                entity.HasKey(e => e.ClaimDirectionCode)
                    .HasName("PK__ClaimDir__2D1BF73401AABAFD");

                entity.Property(e => e.ClaimDirectionCode).ValueGeneratedNever();

                entity.Property(e => e.ClaimDirectionDescription).HasMaxLength(500);

                entity.Property(e => e.ClaimDirectionName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ClaimEmails>(entity =>
            {
                entity.HasKey(e => new { e.MailFrom, e.MailTo, e.CreatedDate });

                entity.Property(e => e.MailFrom).HasMaxLength(100);

                entity.Property(e => e.MailTo).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedPerson).HasMaxLength(100);

                entity.Property(e => e.CreatedPosCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailBody).HasMaxLength(2000);

                entity.Property(e => e.MailCc).HasMaxLength(100);

                entity.Property(e => e.MailSubject).HasMaxLength(300);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.RecevingClaimPOSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<ClaimItem>(entity =>
            {
                entity.HasKey(e => new { e.ClaimNumber, e.RecevingClaimPOSCode, e.ItemID })
                    .HasName("PK_ClaimItem_1");

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.RecevingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.CN48CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CountryCode).HasMaxLength(2);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRateCode).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(2);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(1000);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(50);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(100);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverMobile).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.SenderAddress).HasMaxLength(1000);

                entity.Property(e => e.SenderCode).HasMaxLength(17);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(50);

                entity.Property(e => e.SenderFullname).HasMaxLength(100);

                entity.Property(e => e.SenderIdentification).HasMaxLength(50);

                entity.Property(e => e.SenderMobile).HasMaxLength(50);

                entity.Property(e => e.SenderPosCode).HasMaxLength(6);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(20);

                entity.Property(e => e.SenderTel).HasMaxLength(50);

                entity.Property(e => e.SendingContent).HasMaxLength(4000);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ClaimItem)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimItem_Item");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ClaimItem)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ClaimItem_Service");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimItem)
                    .HasForeignKey(d => new { d.ClaimNumber, d.RecevingClaimPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimItem_Claim");
            });

            modelBuilder.Entity<ClaimMailTrip>(entity =>
            {
                entity.HasKey(e => e.ClaimResponseMailtripCode)
                    .HasName("PK__ClaimRes__496E48FD2982DB05");

                entity.Property(e => e.ClaimResponseMailtripCode).HasMaxLength(12);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DestinationCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailtripNumber).HasMaxLength(4);

                entity.Property(e => e.MailtripType).HasMaxLength(1);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.PostBagNumber).HasMaxLength(50);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.StartingCode).HasMaxLength(6);

                entity.Property(e => e.Year).HasMaxLength(8);
            });

            modelBuilder.Entity<ClaimPayCompensatePOS>(entity =>
            {
                entity.HasKey(e => new { e.PayCompensatePOSCode, e.ClaimResponseInvestigationCode, e.ClaimNumber, e.ReceivingClaimPOSCode, e.FromPOSCode, e.ToPOSCode, e.ClaimSendInvestigationCode })
                    .HasName("PK_PayCompensatePOS");

                entity.Property(e => e.PayCompensatePOSCode).HasMaxLength(12);

                entity.Property(e => e.ClaimResponseInvestigationCode).HasMaxLength(12);

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.ReceivingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.FromPOSCode)
                    .HasMaxLength(6)
                    .HasComment("Bưu cục gửi y/c điều tra");

                entity.Property(e => e.ToPOSCode)
                    .HasMaxLength(6)
                    .HasComment("Bưu cục điều tra và phản hồi");

                entity.Property(e => e.ClaimSendInvestigationCode).HasMaxLength(12);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClaimPriority>(entity =>
            {
                entity.HasKey(e => e.ClaimPriorityCode);

                entity.Property(e => e.ClaimPriorityCode).HasMaxLength(5);

                entity.Property(e => e.ClaimPriorityName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ClaimReply>(entity =>
            {
                entity.HasKey(e => new { e.ClaimReplyCode, e.ClaimNumber, e.ReceivingClaimPOSCode, e.ReplyPOSCode });

                entity.Property(e => e.ClaimReplyCode).HasMaxLength(12);

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.ReceivingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.ReplyPOSCode).HasMaxLength(6);

                entity.Property(e => e.ClaimCompensateCode).HasMaxLength(12);

                entity.Property(e => e.ClaimCompensateRuleCode).HasMaxLength(10);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyDateExpired).HasColumnType("datetime");

                entity.Property(e => e.ReplyUser).HasMaxLength(50);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimReply)
                    .HasForeignKey(d => new { d.ClaimNumber, d.ReceivingClaimPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimReply_Claim");
            });

            modelBuilder.Entity<ClaimResponse>(entity =>
            {
                entity.HasKey(e => new { e.ClaimResponseNumber, e.ReceivingClaimPOSCode, e.FromPOSCode, e.ToPOSCode, e.ClaimNumber });

                entity.Property(e => e.ClaimResponseNumber).HasMaxLength(12);

                entity.Property(e => e.ReceivingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.Answer).HasMaxLength(2000);

                entity.Property(e => e.AnswerAtRelatePos).HasMaxLength(2000);

                entity.Property(e => e.AnswerDate).HasColumnType("datetime");

                entity.Property(e => e.AnswerUser).HasMaxLength(50);

                entity.Property(e => e.AttachmentFile).HasMaxLength(500);

                entity.Property(e => e.ClaimConclusionContent).HasMaxLength(1000);

                entity.Property(e => e.ClaimResultContent).HasMaxLength(1000);

                entity.Property(e => e.ClaimTransportUnitOther).HasMaxLength(500);

                entity.Property(e => e.ClaimTypeErrorOther).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Question).HasMaxLength(2000);

                entity.Property(e => e.ReasonNotAccept).HasMaxLength(500);

                entity.Property(e => e.ReceivingTime).HasColumnType("datetime");

                entity.Property(e => e.ReceivingUser).HasMaxLength(50);

                entity.Property(e => e.ResponseDateExpired).HasColumnType("datetime");

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.SendingUser).HasMaxLength(50);

                entity.Property(e => e.SentBackTime).HasColumnType("datetime");

                entity.Property(e => e.TimeDue).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimResultCodeNavigation)
                    .WithMany(p => p.ClaimResponse)
                    .HasForeignKey(d => d.ClaimResultCode)
                    .HasConstraintName("FK_ClaimResponse_ClaimResult");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimResponse)
                    .HasForeignKey(d => new { d.ClaimNumber, d.ReceivingClaimPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimResponse_Claim");
            });

            modelBuilder.Entity<ClaimResponseMailtrip>(entity =>
            {
                entity.HasKey(e => new { e.ClaimResponseMailtripCode, e.ClaimResponseNumber, e.ReceivingClaimPOSCode, e.ClaimNumber, e.FromPOSCode, e.ToPOSCode });

                entity.Property(e => e.ClaimResponseMailtripCode).HasMaxLength(12);

                entity.Property(e => e.ClaimResponseNumber).HasMaxLength(12);

                entity.Property(e => e.ReceivingClaimPOSCode).HasMaxLength(6);

                entity.Property(e => e.ClaimNumber).HasMaxLength(12);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.HasOne(d => d.ClaimResponseMailtripCodeNavigation)
                    .WithMany(p => p.ClaimResponseMailtrip)
                    .HasForeignKey(d => d.ClaimResponseMailtripCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimResponseMailtrip_ClaimMailtrip");

                entity.HasOne(d => d.ClaimResponse)
                    .WithMany(p => p.ClaimResponseMailtrip)
                    .HasForeignKey(d => new { d.ClaimResponseNumber, d.ReceivingClaimPOSCode, d.FromPOSCode, d.ToPOSCode, d.ClaimNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimResponseMailtrip_ClaimResponse");
            });

            modelBuilder.Entity<ClaimResult>(entity =>
            {
                entity.HasKey(e => e.ClaimResultCode)
                    .HasName("PK__ClaimRes__228E05C225B24A21");

                entity.Property(e => e.ClaimResultCode).ValueGeneratedNever();

                entity.Property(e => e.ClaimResultDescription).HasMaxLength(500);

                entity.Property(e => e.ClaimResultName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ClaimStatus>(entity =>
            {
                entity.HasKey(e => e.ClaimStatusCode)
                    .HasName("PK__ClaimSta__3D39EC317BF1E1A7");

                entity.Property(e => e.ClaimStatusDescription).HasMaxLength(500);

                entity.Property(e => e.ClaimStatusName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ClaimTimeProcessRule>(entity =>
            {
                entity.HasKey(e => e.ClaimTimeProcessCode)
                    .HasName("PK_ClaimTimeProcess");

                entity.Property(e => e.ClaimTimeProcessCode).ValueGeneratedNever();

                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.Property(e => e.RuleNo).HasMaxLength(50);

                entity.Property(e => e.TimeRuleBigCustomer).HasMaxLength(10);

                entity.Property(e => e.TimeRuleNormalCustomer)
                    .HasMaxLength(10)
                    .HasComment("Số ngày chuẩn");

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClaimTransportUnit>(entity =>
            {
                entity.HasKey(e => e.ClaimTransportUnitCode)
                    .HasName("PK_ClaimTransportUnit_1");

                entity.Property(e => e.ClaimTransportUnitCode).ValueGeneratedNever();

                entity.Property(e => e.CanceledContractDate).HasColumnType("datetime");

                entity.Property(e => e.CanceledPerson).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.SignedContractDate).HasColumnType("datetime");

                entity.Property(e => e.SignedPerson).HasMaxLength(50);

                entity.Property(e => e.TransportUnitName).HasMaxLength(500);
            });

            modelBuilder.Entity<ClaimType>(entity =>
            {
                entity.HasKey(e => e.ClaimTypeCode);

                entity.Property(e => e.ClaimTypeCode).HasMaxLength(5);

                entity.Property(e => e.ClaimTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<ClaimTypeError>(entity =>
            {
                entity.HasKey(e => e.ClaimTypeErrorCode);

                entity.Property(e => e.ClaimTypeErrorCode).ValueGeneratedNever();

                entity.Property(e => e.ClaimTypeErrorName).HasMaxLength(300);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Enable).HasComment("Bưu cục gửi y/c điều tra");
            });

            modelBuilder.Entity<ClientReservation>(entity =>
            {
                entity.Property(e => e.ClientReservationId).ValueGeneratedNever();

                entity.Property(e => e.ReservationTime).HasColumnType("datetime");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CollectionFreightStep>(entity =>
            {
                entity.HasKey(e => new { e.CollectionFreightStepCode, e.ServiceCode });

                entity.Property(e => e.CollectionFreightStepCode).HasMaxLength(5);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.CollectionFreightStep)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_CollectionFreightStep_Service");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.HasKey(e => new { e.ColumnName, e.TableName })
                    .HasName("PK_Column_1");

                entity.Property(e => e.ColumnName).HasMaxLength(100);

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TableNameNavigation)
                    .WithMany(p => p.Column)
                    .HasForeignKey(d => d.TableName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Column_Table");
            });

            modelBuilder.Entity<CommodityType>(entity =>
            {
                entity.HasKey(e => e.CommodityTypeCode);

                entity.Property(e => e.CommodityTypeCode).HasMaxLength(6);

                entity.Property(e => e.CommodityTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);
            });

            modelBuilder.Entity<Commune>(entity =>
            {
                entity.HasKey(e => e.CommuneCode);

                entity.HasIndex(e => e.DistrictCode)
                    .HasName("idx_Commune_DistrictCode");

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.CommuneCombobox)
                    .IsRequired()
                    .HasMaxLength(59)
                    .HasComputedColumnSql("(([CommuneCode]+' - ')+[CommuneName])");

                entity.Property(e => e.CommuneName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CommuneNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([CommuneName])),(0)))");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.Commune)
                    .HasForeignKey(d => d.DistrictCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commune_District");
            });

            modelBuilder.Entity<CommuneFreightRegion>(entity =>
            {
                entity.Property(e => e.CommuneCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.CommuneCodeNavigation)
                    .WithMany(p => p.CommuneFreightRegion)
                    .HasForeignKey(d => d.CommuneCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommuneFreightRegion_Commune");

                entity.HasOne(d => d.FreightRegion)
                    .WithMany(p => p.CommuneFreightRegion)
                    .HasForeignKey(d => d.FreightRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommuneFreightRegion_FreightRegion");
            });

            modelBuilder.Entity<Commune_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CommuneCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CommuneName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<CommunicationConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigKey);

                entity.Property(e => e.ConfigKey).HasMaxLength(50);

                entity.Property(e => e.ConfigValue)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<CompensateCategory>(entity =>
            {
                entity.HasKey(e => e.CompensateCategoryCode);

                entity.Property(e => e.CompensateCategoryCode).HasMaxLength(10);

                entity.Property(e => e.CompensateCategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(300);
            });

            modelBuilder.Entity<CompensateRate>(entity =>
            {
                entity.HasKey(e => new { e.CompensateRateCode, e.ItemTypeCode, e.ServiceCode });

                entity.Property(e => e.CompensateRateCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceItemType)
                    .WithMany(p => p.CompensateRate)
                    .HasForeignKey(d => new { d.ServiceCode, d.ItemTypeCode })
                    .HasConstraintName("FK_CompensateRate_ServiceItemType");
            });

            modelBuilder.Entity<CompensateResult>(entity =>
            {
                entity.HasKey(e => e.CompensateResultCode);

                entity.Property(e => e.CompensateResultCode).HasMaxLength(1);

                entity.Property(e => e.CompensateResultName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.ConfigCode);

                entity.Property(e => e.ConfigCode).HasMaxLength(50);

                entity.Property(e => e.ConfigName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(50);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ContinentCode);

                entity.Property(e => e.ContinentCode).HasMaxLength(2);

                entity.Property(e => e.ContinentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Controls>(entity =>
            {
                entity.HasKey(e => new { e.ControlId, e.ObjectRefId });

                entity.Property(e => e.ControlName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ControlType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasKey(e => new { e.CounterCode, e.POSCode });

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.CounterName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Counter)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_Counter_POS");
            });

            modelBuilder.Entity<Counter1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "KT1");

                entity.HasIndex(e => e.Key)
                    .HasName("CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.ContinentCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ContinentCodeNavigation)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.ContinentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_Continent");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerCode)
                    .HasName("PK_Customer_1");

                entity.HasIndex(e => e.CustomerCode)
                    .HasName("idx_customer_code");

                entity.HasIndex(e => e.CustomerNameSearch)
                    .HasName("ix_customer_name_search");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(17)
                    .HasComment("Mã khách hàng");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasComment("Tên khách hàng");

                entity.Property(e => e.CustomerNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([CustomerName])),0))");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .HasComment("Email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .HasComment("Fax");

                entity.Property(e => e.IdentificationNumber)
                    .HasMaxLength(20)
                    .HasComment("Số định danh");

                entity.Property(e => e.IsReceive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSender)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasComment("Điện thoại DĐ");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasComment("Ghi chú");

                entity.Property(e => e.POSCode)
                    .HasMaxLength(6)
                    .HasComment("Mã bưu cục");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(20)
                    .HasComment("Mã số thuế");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .HasComment("Điện thoại CQ");
            });

            modelBuilder.Entity<CustomerBusinessDomain>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.CustomerCode, e.BusinessDomainCode });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.CustomerCode).HasMaxLength(14);

                entity.Property(e => e.BusinessDomainCode).HasMaxLength(5);

                entity.HasOne(d => d.BusinessDomainCodeNavigation)
                    .WithMany(p => p.CustomerBusinessDomain)
                    .HasForeignKey(d => d.BusinessDomainCode)
                    .HasConstraintName("FK_CustomerBusinessDomain_BusinessDomain");
            });

            modelBuilder.Entity<CustomerGroup>(entity =>
            {
                entity.HasKey(e => e.CustomerGroupCode);

                entity.Property(e => e.CustomerGroupCode)
                    .HasMaxLength(20)
                    .HasComment("Mã nhóm khách hàng");

                entity.Property(e => e.CustomerGroupContent)
                    .HasMaxLength(500)
                    .HasComment("Mô tả");

                entity.Property(e => e.CustomerGroupName)
                    .HasMaxLength(100)
                    .HasComment("Tên nhóm khách hàng");

                entity.Property(e => e.DeliveryRequirement)
                    .HasMaxLength(1000)
                    .HasComment("Yêu cầu khi phát");
            });

            modelBuilder.Entity<CustomerObject>(entity =>
            {
                entity.HasKey(e => e.ObjectID);

                entity.Property(e => e.ObjectID).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.ObjectCode).HasMaxLength(50);

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Tel).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.CustomerObject)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_CustomerObject_Customer");
            });

            modelBuilder.Entity<Dasboard_SANLUONGBUUGUIUUTIENDACBIET>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Dasboard_SANLUONGBUUGUIUUTIENDACBIET");

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.XValue).HasMaxLength(4000);

                entity.Property(e => e.ZValue)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.dateValue).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dasboard_SanLuongPhatALienTinh>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Dasboard_SanLuongPhatALienTinh");

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.XValue).HasMaxLength(4000);

                entity.Property(e => e.ZValue)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.dateValue).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dasboard_SanLuong_BCCP_BCCC_ChieuDen>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Dasboard_SanLuong_BCCP_BCCC_ChieuDen");

                entity.Property(e => e.ParentTag).HasMaxLength(300);

                entity.Property(e => e.XValue).HasMaxLength(4000);

                entity.Property(e => e.ZValue).HasMaxLength(4);

                entity.Property(e => e.dateValue).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dasboard_SanLuong_BCCP_BCCC_ChieuDi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Dasboard_SanLuong_BCCP_BCCC_ChieuDi");

                entity.Property(e => e.DestinationCode).HasMaxLength(6);

                entity.Property(e => e.StartingCode).HasMaxLength(6);

                entity.Property(e => e.XValue).HasMaxLength(4000);

                entity.Property(e => e.ZValue)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.dateValue).HasColumnType("datetime");
            });

            modelBuilder.Entity<DashboardDataset>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConnectString).HasMaxLength(50);

                entity.Property(e => e.DataType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.SourceType).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DashboardPermision>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PostCode).HasMaxLength(6);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.DashboardPermision)
                    .HasForeignKey(d => d.SettingId)
                    .HasConstraintName("FK__Dashboard__Setti__4CAF44DE");
            });

            modelBuilder.Entity<DashboardSetting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsPermissionAll)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Dataset)
                    .WithMany(p => p.DashboardSetting)
                    .HasForeignKey(d => d.DatasetId)
                    .HasConstraintName("FK__Dashboard__Datas__47EA8FC1");
            });

            modelBuilder.Entity<Dashboard_4VanPhong>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Dashboard_4VanPhong");

                entity.Property(e => e.XValue)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.ZValue).HasMaxLength(100);
            });

            modelBuilder.Entity<DbVersion>(entity =>
            {
                entity.HasKey(e => e.DbVersionNumber);

                entity.Property(e => e.DbVersionNumber).HasMaxLength(10);

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.DbChanges).HasMaxLength(500);

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Deduction>(entity =>
            {
                entity.HasKey(e => e.DeductionCode);

                entity.Property(e => e.DeductionCode).HasMaxLength(10);

                entity.Property(e => e.DeductionName).HasMaxLength(150);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.Deduction)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_Deduction_Service");
            });

            modelBuilder.Entity<DeductionDetail>(entity =>
            {
                entity.HasKey(e => e.DeductionDetailCode);

                entity.Property(e => e.DeductionDetailCode).HasMaxLength(10);

                entity.Property(e => e.DeductionCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ItemType).HasMaxLength(3);

                entity.HasOne(d => d.DeductionCodeNavigation)
                    .WithMany(p => p.DeductionDetail)
                    .HasForeignKey(d => d.DeductionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionDetail_Deduction");

                entity.HasOne(d => d.ItemTypeNavigation)
                    .WithMany(p => p.DeductionDetail)
                    .HasForeignKey(d => d.ItemType)
                    .HasConstraintName("FK_DeductionDetail_ItemType");
            });

            modelBuilder.Entity<DeductionPOS>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.DeductionCode });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.DeductionCode).HasMaxLength(10);

                entity.HasOne(d => d.DeductionCodeNavigation)
                    .WithMany(p => p.DeductionPOS)
                    .HasForeignKey(d => d.DeductionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionPOS_Deduction");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.DeductionPOS)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionPOS_POS");
            });

            modelBuilder.Entity<DeductionProvince>(entity =>
            {
                entity.HasKey(e => new { e.DeductionCode, e.ProvinceCode });

                entity.Property(e => e.DeductionCode).HasMaxLength(10);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.HasOne(d => d.DeductionCodeNavigation)
                    .WithMany(p => p.DeductionProvince)
                    .HasForeignKey(d => d.DeductionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionProvince_Deduction");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.DeductionProvince)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionProvince_Province");
            });

            modelBuilder.Entity<DeleteParameter>(entity =>
            {
                entity.HasKey(e => new { e.MessageTypeName, e.TableName, e.DeleteParameterName });

                entity.Property(e => e.MessageTypeName).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.DeleteParameterName).HasMaxLength(50);

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryIndex, e.ToPOSCode, e.ItemID })
                    .HasName("PK_Delivery_1");

                entity.HasIndex(e => e.IsDeliverable)
                    .HasName("idx_Delivery_IsDeliverable");

                entity.HasIndex(e => new { e.ItemID, e.IsFinal })
                    .HasName("idx_Delivery_ItemId_IsFinal");

                entity.HasIndex(e => new { e.ItemID, e.DeliveryDate, e.IsFirst })
                    .HasName("idx_Delivery_IsFirst");

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.CollectionMoneyDate).HasColumnType("datetime");

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.DeliveryCertificateDateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.DeliveryCertificateName).HasMaxLength(500);

                entity.Property(e => e.DeliveryCertificateNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryCertificateOtherName).HasMaxLength(500);

                entity.Property(e => e.DeliveryCertificatePlaceOfIssue).HasMaxLength(500);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryMachine).HasMaxLength(50);

                entity.Property(e => e.DeliveryNote).HasMaxLength(2000);

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryPointReceiverCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryRouteName).HasMaxLength(500);

                entity.Property(e => e.DeliveryUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(3000);

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.InputingUser).HasMaxLength(50);

                entity.Property(e => e.IsFinal).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsFirst).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLast)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.NextLast).HasMaxLength(100);

                entity.Property(e => e.ObjectTransfer).HasMaxLength(200);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PostmanCode).HasMaxLength(50);

                entity.Property(e => e.PostmanName).HasMaxLength(500);

                entity.Property(e => e.RealReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.RealReciverName).HasMaxLength(500);

                entity.Property(e => e.ReturningMoneyDate).HasColumnType("datetime");

                entity.Property(e => e.SendMailDate).HasColumnType("datetime");

                entity.Property(e => e.SendSMSDate).HasColumnType("datetime");

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Item1");
            });

            modelBuilder.Entity<DeliveryBCCP>(entity =>
            {
                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<DeliveryBCCP_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<DeliveryPoint>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryPointCode, e.CustomerCode })
                    .HasName("PK_DeliveryPoint_1");

                entity.HasIndex(e => e.DeliveryPointNameSearch)
                    .HasName("ix_delivery_point_name_search");

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.DeliveryPointAddress).HasMaxLength(250);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.DeliveryPointNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([DeliveryPointName])),0))");

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.Order).HasDefaultValueSql("((0))");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.VMapCode).HasMaxLength(100);

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.DeliveryPoint)
                    .HasForeignKey(d => d.CustomerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryPoint_Customer");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.DeliveryPoint)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("FK__DeliveryP__Objec__6CBCED14");
            });

            modelBuilder.Entity<DeliveryPointReceiver>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryPointReceiverCode, e.DeliveryPointCode, e.CustomerCode });

                entity.Property(e => e.DeliveryPointReceiverCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverDepartment).HasMaxLength(250);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(150);

                entity.Property(e => e.ReceiverPhone).HasMaxLength(150);

                entity.Property(e => e.ReceiverPosition).HasMaxLength(250);

                entity.Property(e => e.Validated).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.DeliveryPoint)
                    .WithMany(p => p.DeliveryPointReceiver)
                    .HasForeignKey(d => new { d.DeliveryPointCode, d.CustomerCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryPointReceiver_DeliveryPoint");
            });

            modelBuilder.Entity<DeliveryPointReceiver_Back>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.DeliveryPointCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DeliveryPointReceiverCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ReceiverDepartment).HasMaxLength(250);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(150);

                entity.Property(e => e.ReceiverPhone).HasMaxLength(150);

                entity.Property(e => e.ReceiverPosition).HasMaxLength(250);
            });

            modelBuilder.Entity<DeliveryRevenueSharing>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryRevenueSharingCode, e.RevenueSharingRuleCode, e.ServiceCode });

                entity.Property(e => e.DeliveryRevenueSharingCode).HasMaxLength(10);

                entity.Property(e => e.RevenueSharingRuleCode).HasMaxLength(5);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.RevenueSharingRule)
                    .WithMany(p => p.DeliveryRevenueSharing)
                    .HasForeignKey(d => new { d.RevenueSharingRuleCode, d.ServiceCode })
                    .HasConstraintName("FK_DeliveryRevenueSharing_RevenueSharingRule1");
            });

            modelBuilder.Entity<DeliveryRoute>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryRouteCode, e.FromPOSCode })
                    .HasName("PK_DeliveryRoute_1");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.DeliverRouteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeliverRouteNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([DeliverRouteName])),(0)))");

                entity.Property(e => e.DeliveryRouteName).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsHide).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScopeType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromPOSCodeNavigation)
                    .WithMany(p => p.DeliveryRoute)
                    .HasForeignKey(d => d.FromPOSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRoute_POS");
            });

            modelBuilder.Entity<DeliveryRoutePoint>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryRouteCode, e.FromPOSCode, e.DeliveryPointCode, e.CustomerCode });

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.HasOne(d => d.DeliveryPoint)
                    .WithMany(p => p.DeliveryRoutePoint)
                    .HasForeignKey(d => new { d.DeliveryPointCode, d.CustomerCode })
                    .HasConstraintName("FK_DeliveryRoutePoint_DeliveryPoint");

                entity.HasOne(d => d.DeliveryRoute)
                    .WithMany(p => p.DeliveryRoutePoint)
                    .HasForeignKey(d => new { d.DeliveryRouteCode, d.FromPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRoutePoint_DeliveryRoute");
            });

            modelBuilder.Entity<DeliveryRouteService>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryRouteCode, e.FromPOSCode, e.ServiceCode })
                    .HasName("PK_DeliveryRouteService_1");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.DeliveryRouteService)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRouteService_Service");

                entity.HasOne(d => d.DeliveryRoute)
                    .WithMany(p => p.DeliveryRouteService)
                    .HasForeignKey(d => new { d.DeliveryRouteCode, d.FromPOSCode })
                    .HasConstraintName("FK_DeliveryRouteService_DeliveryRoute");
            });

            modelBuilder.Entity<DeliveryRouteService_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeliveryRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<DeliveryRoute_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DelieveryRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DeliverRouteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryRouteName).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<DeliveryScoping>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryRouteCode, e.FromPOSCode, e.ServiceCode, e.CommuneCode });

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.HasOne(d => d.CommuneCodeNavigation)
                    .WithMany(p => p.DeliveryScoping)
                    .HasForeignKey(d => d.CommuneCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryScoping_Commune");

                entity.HasOne(d => d.DeliveryRouteService)
                    .WithMany(p => p.DeliveryScoping)
                    .HasForeignKey(d => new { d.DeliveryRouteCode, d.FromPOSCode, d.ServiceCode })
                    .HasConstraintName("FK_DeliveryScoping_DeliveryRouteService");
            });

            modelBuilder.Entity<Delivery_Log>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(50);
            });

            modelBuilder.Entity<Delivery_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.CollectionMoneyDate).HasColumnType("datetime");

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryCertificateDateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.DeliveryCertificateName).HasMaxLength(500);

                entity.Property(e => e.DeliveryCertificateNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryCertificateOtherName).HasMaxLength(500);

                entity.Property(e => e.DeliveryCertificatePlaceOfIssue).HasMaxLength(500);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryMachine).HasMaxLength(50);

                entity.Property(e => e.DeliveryNote).HasMaxLength(2000);

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryRouteName).HasMaxLength(500);

                entity.Property(e => e.DeliveryTransferID).HasMaxLength(50);

                entity.Property(e => e.DeliveryUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.InputingUser).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.ObjectTransfer).HasMaxLength(200);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PostmanCode).HasMaxLength(50);

                entity.Property(e => e.PostmanName).HasMaxLength(500);

                entity.Property(e => e.RealReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.RealReciverName).HasMaxLength(2000);

                entity.Property(e => e.RelateWithReceive).HasMaxLength(500);

                entity.Property(e => e.ReturningMoneyDate).HasColumnType("datetime");

                entity.Property(e => e.SendMailDate).HasColumnType("datetime");

                entity.Property(e => e.SendSMSDate).HasColumnType("datetime");

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailBlockFreight>(entity =>
            {
                entity.HasIndex(e => new { e.DomesticFreightBlockId, e.DomesticFreightStepId })
                    .HasName("IX_DetailBlockFreight")
                    .IsUnique();

                entity.HasOne(d => d.DomesticFreightBlock)
                    .WithMany(p => p.DetailBlockFreight)
                    .HasForeignKey(d => d.DomesticFreightBlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailBlockFreight_DomesticFreightBlock");

                entity.HasOne(d => d.DomesticFreightStep)
                    .WithMany(p => p.DetailBlockFreight)
                    .HasForeignKey(d => d.DomesticFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailBlockFreight_DomesticFreightStep");
            });

            modelBuilder.Entity<DetailItemAffairCOD>(entity =>
            {
                entity.HasKey(e => new { e.ItemIndex, e.ItemID })
                    .HasName("PK_DetailItemAffairCOD_1");

                entity.Property(e => e.ChemicalItemName).HasMaxLength(500);

                entity.Property(e => e.ChemicalName).HasMaxLength(500);

                entity.Property(e => e.ChemicalTypeCode).HasMaxLength(5);

                entity.Property(e => e.DetailItemName).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.OriginalCountryCode).HasMaxLength(3);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailItemChanged>(entity =>
            {
                entity.HasKey(e => new { e.ItemIndex, e.HandoverIndex, e.ChangePOSCode, e.ChangeIndex, e.ItemID });

                entity.Property(e => e.ChangePOSCode).HasMaxLength(6);

                entity.Property(e => e.ChemicalItemName).HasMaxLength(500);

                entity.Property(e => e.ChemicalName).HasMaxLength(500);

                entity.Property(e => e.ChemicalTypeCode).HasMaxLength(5);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DetailItemName).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OriginalCountryCode).HasMaxLength(3);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailItem_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ChemicalItemName).HasMaxLength(500);

                entity.Property(e => e.ChemicalName).HasMaxLength(500);

                entity.Property(e => e.ChemicalTypeCode).HasMaxLength(5);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DetailItemName).HasMaxLength(50);

                entity.Property(e => e.EnContent)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HsId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.OriginalCountryCode).HasMaxLength(3);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailProvinceFreight>(entity =>
            {
                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FromProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ToProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticFreightStep)
                    .WithMany(p => p.DetailProvinceFreight)
                    .HasForeignKey(d => d.DomesticFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailProvinceFreight_DomesticFreightStep");
            });

            modelBuilder.Entity<DetailRegionFreight>(entity =>
            {
                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FromFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.DomesticFreightStep)
                    .WithMany(p => p.DetailRegionFreight)
                    .HasForeignKey(d => d.DomesticFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailRegionFreight_DomesticFreightStep");
            });

            modelBuilder.Entity<DetailValueAddedServiceProvinceFreight>(entity =>
            {
                entity.Property(e => e.FromProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ToProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticValueAddedServiceFreightStep)
                    .WithMany(p => p.DetailValueAddedServiceProvinceFreight)
                    .HasForeignKey(d => d.DomesticValueAddedServiceFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailValueAddedServiceProvinceFreight_DomesticValueAddedServiceFreightStep");
            });

            modelBuilder.Entity<DetailValueAddedServiceRegionFreight>(entity =>
            {
                entity.Property(e => e.FromFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.DomesticValueAddedServiceFreightStep)
                    .WithMany(p => p.DetailValueAddedServiceRegionFreight)
                    .HasForeignKey(d => d.DomesticValueAddedServiceFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailValueAddedServiceRegionFreight_DomesticValueAddedServiceFreightStep1");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceID)
                    .HasComment("ID thiết bị")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Mã thiết bị");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("Tên thiết bị");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Mã bưu cục");

                entity.Property(e => e.Status).HasComment("Tình trạng sử dung: 0 - Đang sử dụng; 1 - Không còn sử dụng");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_POS");
            });

            modelBuilder.Entity<DirectionRoute>(entity =>
            {
                entity.HasKey(e => new { e.OnMailRoutePOSCode, e.ExchangePOSCode, e.ServiceCode, e.DestinationCode });

                entity.Property(e => e.OnMailRoutePOSCode).HasMaxLength(6);

                entity.Property(e => e.ExchangePOSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.DestinationCode).HasMaxLength(6);
            });

            modelBuilder.Entity<Dispatch>(entity =>
            {
                entity.HasComment("Bưu gửi trong túi");

                entity.HasIndex(e => e.PostBagID)
                    .HasName("idx_Dispatch_PostBagID");

                entity.Property(e => e.DispatchID)
                    .HasComment("ID bưu gửi trong túi")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(50)
                    .HasComment("Người xác nhận");

                entity.Property(e => e.ConfirmedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày xác nhận");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.IndexNumber).HasComment("Thứ tự bưu gửi trong túi");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(20)
                    .HasComment("Số hiệu bưu gửi")
                    .HasComputedColumnSql("([dbo].[Dispatch_ItemCode]([ItemID]))");

                entity.Property(e => e.ItemID).HasComment("ID bưu gửi");

                entity.Property(e => e.PostBagID).HasComment("ID túi");

                entity.Property(e => e.Sheet).HasComment("Tờ số");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Dispatch)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispatch_Item");

                entity.HasOne(d => d.PostBag)
                    .WithMany(p => p.Dispatch)
                    .HasForeignKey(d => d.PostBagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispatch_PostBag");
            });

            modelBuilder.Entity<DispatchBack_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PostmanCode).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Dispatch_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PostmanCode).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictCode);

                entity.HasIndex(e => e.ProvinceCode)
                    .HasName("idx_district_provincecode");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .HasComment("Mã quận huyện");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasComment("Mô tả");

                entity.Property(e => e.DistrictCombobox)
                    .IsRequired()
                    .HasMaxLength(107)
                    .HasComment("Tên hiển thị")
                    .HasComputedColumnSql("(([DistrictCode]+' - ')+[DistrictName])");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Tên quận huyện");

                entity.Property(e => e.DistrictNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([DistrictName])),(0)))");

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasComment("Mã tỉnh TP");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_ProvinceCode");
            });

            modelBuilder.Entity<DistrictFreightRegion>(entity =>
            {
                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.DistrictFreightRegion)
                    .HasForeignKey(d => d.DistrictCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistrictFreightRegion_District");

                entity.HasOne(d => d.FreightRegion)
                    .WithMany(p => p.DistrictFreightRegion)
                    .HasForeignKey(d => d.FreightRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistrictFreightRegion_FreightRegion");
            });

            modelBuilder.Entity<District_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<DnnModuleControl>(entity =>
            {
                entity.HasKey(e => e.DnnModuleControlName);

                entity.Property(e => e.DnnModuleControlName).HasMaxLength(100);

                entity.Property(e => e.DnnModuleControlFriendlyName).HasMaxLength(100);

                entity.Property(e => e.DnnModuleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DnnModuleControlPermission>(entity =>
            {
                entity.Property(e => e.DnnModuleControlName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleGroupName).HasMaxLength(100);

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.HasOne(d => d.DnnModuleControlNameNavigation)
                    .WithMany(p => p.DnnModuleControlPermission)
                    .HasForeignKey(d => d.DnnModuleControlName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DnnModuleControlPermission_DnnModuleControl");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(2500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.URL).HasMaxLength(500);
            });

            modelBuilder.Entity<DomessticFreightRuleVASUsing>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.DomesticFreightRuleCode, e.ValueAddedServiceCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.CalculationMethod).HasComment(@"1: Tính cước theo nấc khối lượng
2: Tính cước theo số lượng Item trong lô
3: Tính cước theo khối lượng Item trong lô
4: Tính cước theo phần trăm tiền gửi
5: Tính cước theo 1 bưu gửi
6: Tính cước theo ngày lưu kho
7: Tính theo công thức");
            });

            modelBuilder.Entity<DomesticCollectionFreight>(entity =>
            {
                entity.HasKey(e => new { e.CollectionCode, e.DomesticFreighRuleCode, e.ServiceCode });

                entity.Property(e => e.CollectionCode)
                    .HasMaxLength(10)
                    .HasComment("Mã thu hộ");

                entity.Property(e => e.DomesticFreighRuleCode)
                    .HasMaxLength(10)
                    .HasComment("Mã quy định tính cước");

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(2)
                    .HasComment("Mã dịch vụ");

                entity.Property(e => e.CalculateMethod).HasComment(@"0: Tính theo nấc tiền
1: Tính theo bước tiền
");

                entity.Property(e => e.CollectionFreight).HasComment("Mức cước thu hộ tối thiểu theo từng mức tiền");

                entity.Property(e => e.CollectionFreightPercent).HasComment("Mức cước thu hộ theo tỉ lệ phần trăm");

                entity.Property(e => e.FromMoney).HasComment("Giá trị tiền thu hộ đầu step");

                entity.Property(e => e.ToMoney).HasComment("Giá trị tiền thu hộ cuối step");
            });

            modelBuilder.Entity<DomesticCommodityType>(entity =>
            {
                entity.HasKey(e => new { e.CommodityTypeCode, e.ServiceCode, e.DomesticFreightRuleCode });

                entity.Property(e => e.CommodityTypeCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.HasOne(d => d.CommodityTypeCodeNavigation)
                    .WithMany(p => p.DomesticCommodityType)
                    .HasForeignKey(d => d.CommodityTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticCommodityType_CommodityType");
            });

            modelBuilder.Entity<DomesticCompensateRule>(entity =>
            {
                entity.HasKey(e => new { e.DomesitcCompensateRuleCode, e.ServiceCode });

                entity.Property(e => e.DomesitcCompensateRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNumber).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.DomesticCompensateRule)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticCompensateRule_Service");
            });

            modelBuilder.Entity<DomesticFarRegion>(entity =>
            {
                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.DomesticFarRegion)
                    .HasForeignKey(d => d.DistrictCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFarRegion_District");

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticFarRegion)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFarRegion_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticFarRegionCommune>(entity =>
            {
                entity.Property(e => e.CommuneCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.HasOne(d => d.CommuneCodeNavigation)
                    .WithMany(p => p.DomesticFarRegionCommune)
                    .HasForeignKey(d => d.CommuneCode)
                    .HasConstraintName("FK_DomesticFarRegionCommune_Commune");

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticFarRegionCommune)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFarRegionCommune_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticFarRegionFreightStep>(entity =>
            {
                entity.Property(e => e.CalculationMethod).HasComment(@"0: Tính theo nấc khối lượng
1: Tính theo bước cước");

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticFarRegionFreightStep)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFarRegionFreightStep_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticFreightBlock>(entity =>
            {
                entity.Property(e => e.BlockCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BlockName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticFreightBlock)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightBlock_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticFreightObject>(entity =>
            {
                entity.HasKey(e => e.DomesticFreightObjectCode)
                    .HasName("PK_DomesticFreightObject_1");

                entity.Property(e => e.DomesticFreightObjectCode).HasMaxLength(50);

                entity.Property(e => e.DomesticFreightObjectName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<DomesticFreightObjectFreight>(entity =>
            {
                entity.Property(e => e.DomesticFreightObjectCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DomesticFreightObjectCodeNavigation)
                    .WithMany(p => p.DomesticFreightObjectFreight)
                    .HasForeignKey(d => d.DomesticFreightObjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightObjectFreight_DomesticFreightObject");
            });

            modelBuilder.Entity<DomesticFreightProperty>(entity =>
            {
                entity.HasKey(e => e.DomesticFreightPropertyCode);

                entity.Property(e => e.DomesticFreightPropertyCode).HasMaxLength(50);

                entity.Property(e => e.DomesticFreightObjectCode).HasMaxLength(50);

                entity.Property(e => e.DomesticFreightPropertyName).HasMaxLength(150);

                entity.HasOne(d => d.DomesticFreightObjectCodeNavigation)
                    .WithMany(p => p.DomesticFreightProperty)
                    .HasForeignKey(d => d.DomesticFreightObjectCode)
                    .HasConstraintName("FK_DomesticFreightProperty_DomesticFreightObject");
            });

            modelBuilder.Entity<DomesticFreightPropertyValue>(entity =>
            {
                entity.Property(e => e.DomesticFreightPropertyCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.DomesticFreightObjectFreight)
                    .WithMany(p => p.DomesticFreightPropertyValue)
                    .HasForeignKey(d => d.DomesticFreightObjectFreightID)
                    .HasConstraintName("FK_DomesticFreightPropertyValue_DomesticFreightObjectFreight");

                entity.HasOne(d => d.DomesticFreightPropertyCodeNavigation)
                    .WithMany(p => p.DomesticFreightPropertyValue)
                    .HasForeignKey(d => d.DomesticFreightPropertyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightPropertyValue_DomesticFreightProperty");
            });

            modelBuilder.Entity<DomesticFreightRule>(entity =>
            {
                entity.Property(e => e.CommodityCalculationMethod).HasComment("0: Tính tổng, 1 tính Max, 2 Tính Min, 3 Tính Avg");

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNo).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DomesticFreightRuleItemTypeUsing>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.DomesticFreightRuleCode, e.ItemTypeCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.DomesticFreightRuleItemTypeUsing)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightRuleItemTypeUsing_ItemType");
            });

            modelBuilder.Entity<DomesticFreightRuleLastUpdate>(entity =>
            {
                entity.HasKey(e => new { e.DomesticFreightRuleCode, e.ServiceCode });

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DomesticFreightStep>(entity =>
            {
                entity.HasIndex(e => new { e.ServiceCode, e.ItemTypeCode, e.DomesticFreightRuleCode, e.DomesticFreightStepCode })
                    .HasName("IX_DomesticFreightStep")
                    .IsUnique();

                entity.Property(e => e.CalculationMethod).HasComment(@"0: Tính theo nấc khối lượng
1: Tính theo bước cước");

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DomesticFreightStepCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransportType).HasComment("0: Tất cả, 1: Bộ, 2 Bay");

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticFreightStep)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightStep_DomesticFreightRule");

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.DomesticFreightStep)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticFreightStep_ItemType");
            });

            modelBuilder.Entity<DomesticServiceSurchange>(entity =>
            {
                entity.HasKey(e => new { e.DomesticServiceSurchangeCode, e.ServiceCode, e.ValueDate });

                entity.Property(e => e.DomesticServiceSurchangeCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.DomesticServiceSurchange)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticServiceSurchange_Service");
            });

            modelBuilder.Entity<DomesticSurchangeValueAddedServicePercent>(entity =>
            {
                entity.HasKey(e => new { e.DomesticFreightRuleCode, e.ServiceCode, e.ValueAddedServiceCode, e.ValueDate })
                    .HasName("PK_DomesticSurchangeValueAddedServicePercent_1");

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticSurchangeValueAddedServicePercent)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticSurchangeValueAddedServicePercent_VASUsing");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPerItem>(entity =>
            {
                entity.HasKey(e => e.DomesticValueAddedServiceFreightPerItemCode)
                    .HasName("PK_DomesticValueAddedServiceFreightPerItem_1");

                entity.Property(e => e.ValueAddedServiceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPerItem)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPerItem_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPerMoney>(entity =>
            {
                entity.HasKey(e => new { e.DomesticValueAddedServiceFreightPerMoneyCode, e.ServiceCode, e.ValueAddedServiceCode, e.DomesticFreightRuleCode });

                entity.Property(e => e.DomesticValueAddedServiceFreightPerMoneyCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPerMoney)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPerMoney_VASUsing");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPerStockDay>(entity =>
            {
                entity.HasKey(e => new { e.DomesticValueAddedServiceFreightPerStockDayCode, e.ServiceCode, e.ValueAddedServiceCode, e.DomesticFreightRuleCode });

                entity.Property(e => e.DomesticValueAddedServiceFreightPerStockDayCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPerStockDay)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPerStockDay_VASUsing");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPerTotalItem>(entity =>
            {
                entity.HasKey(e => new { e.DomesticValueAddedServiceFreightPerTotalItemCode, e.ServiceCode, e.ValueAddedServiceCode, e.DomesticFreightRuleCode });

                entity.Property(e => e.DomesticValueAddedServiceFreightPerTotalItemCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPerTotalItem)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPerTotalItem_VASUsing");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPerTotalItemInBatch>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ValueAddedServiceCode, e.DomesticFreightRuleCode, e.DomesticValueAddedServiceFreightPerTotalItemInBatchCode })
                    .HasName("PK_DomesticValueAddedServiceFreightPerTotalItemInBatch_1");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.DomesticValueAddedServiceFreightPerTotalItemInBatchCode).HasMaxLength(10);

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPerTotalItemInBatch)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPerTotalItemInBatch_VASUsing");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightPercentMainFreight>(entity =>
            {
                entity.Property(e => e.ValueAddedServiceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.DomesticValueAddedServiceFreightPercentMainFreight)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightPercentMainFreight_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightStep>(entity =>
            {
                entity.Property(e => e.DomesticValueAddedServiceFreightStepId).ValueGeneratedOnAdd();

                entity.Property(e => e.CalculationMethod).HasComment(@"0: Tính theo nấc khối lượng
1: Tính theo bước cước");

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.HasOne(d => d.DomesticValueAddedServiceFreightStepNavigation)
                    .WithOne(p => p.DomesticValueAddedServiceFreightStep)
                    .HasForeignKey<DomesticValueAddedServiceFreightStep>(d => d.DomesticValueAddedServiceFreightStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightStep_DomesticFreightRule");
            });

            modelBuilder.Entity<DomesticValueAddedServiceFreightTotalWeight>(entity =>
            {
                entity.HasKey(e => new { e.DomesticValueAddedServiceFreightPerTotalWeightCode, e.ValueAddedServiceCode, e.ServiceCode, e.DomesticFreightRuleCode, e.DomesticValueAddedServiceFreightStepCode });

                entity.Property(e => e.DomesticValueAddedServiceFreightPerTotalWeightCode).HasMaxLength(10);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.DomesticValueAddedServiceFreightStepCode).HasMaxLength(5);

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.DomesticValueAddedServiceFreightTotalWeight)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomesticValueAddedServiceFreightTotalWeight_VASUsing");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => new { e.DriverCode, e.POSCode });

                entity.Property(e => e.DriverCode).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_POS");
            });

            modelBuilder.Entity<EmailAccount>(entity =>
            {
                entity.HasKey(e => e.EmailID);

                entity.Property(e => e.DisplayName).HasMaxLength(100);

                entity.Property(e => e.From).HasMaxLength(100);

                entity.Property(e => e.Host).HasMaxLength(100);

                entity.Property(e => e.MailAccount).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Subject).HasMaxLength(200);

                entity.Property(e => e.To).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Example>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ColDate).HasColumnType("date");

                entity.Property(e => e.ColDateString)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ColDateTime).HasColumnType("datetime");

                entity.Property(e => e.ColText).HasMaxLength(255);

                entity.Property(e => e.ColTextArea).HasColumnType("text");
            });

            modelBuilder.Entity<Example1>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Example2>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.cretae)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.descript).HasMaxLength(2000);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ExampleFile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OneFile).HasMaxLength(300);
            });

            modelBuilder.Entity<ExampleMultiKey>(entity =>
            {
                entity.HasKey(e => new { e.Id1, e.Id2 });

                entity.Property(e => e.Id1).HasMaxLength(10);

                entity.Property(e => e.Id2).HasMaxLength(10);

                entity.Property(e => e.ColDate).HasColumnType("date");

                entity.Property(e => e.ColDateString)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ColDateTime).HasColumnType("datetime");

                entity.Property(e => e.ColText).HasMaxLength(255);

                entity.Property(e => e.ColTextArea).HasColumnType("text");
            });

            modelBuilder.Entity<ExchangeRelationship>(entity =>
            {
                entity.HasKey(e => new { e.OnMailRoutePOSCode, e.ExchangePOSCode, e.ServiceCode });

                entity.Property(e => e.OnMailRoutePOSCode).HasMaxLength(6);

                entity.Property(e => e.ExchangePOSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ExchangeID)
                    .HasMaxLength(14)
                    .HasComputedColumnSql("([dbo].[ExchangeRelationship_ID]([OnMailRoutePOSCode],[ExchangePOSCode],[ServiceCode]))");

                entity.Property(e => e.ExchangePOSName)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("([dbo].[ExchangeRelationship_POSName]([ExchangePOSCode]))");

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.IsDiscreteMailRoute).HasComment("True: Giao roi, False: Dong tui");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(5);

                entity.Property(e => e.OnMailRoutePOSName)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("([dbo].[ExchangeRelationship_POSName]([OnMailRoutePOSCode]))");

                entity.Property(e => e.ResetType).HasComment("reset ngay chuyen thu 0:ngay , 1: thang, 2:nam");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ExchangeRelationship)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeRelationship_Service");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.FeedBackId).ValueGeneratedNever();

                entity.Property(e => e.Attchment)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.FeedBackName).HasMaxLength(500);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AttackFile)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Version).HasMaxLength(256);
            });

            modelBuilder.Entity<FreightRegion>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FreightRegionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.DomesticFreightRule)
                    .WithMany(p => p.FreightRegion)
                    .HasForeignKey(d => d.DomesticFreightRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FreightRegion_DomesticFreightRule");
            });

            modelBuilder.Entity<GetDependOn>(entity =>
            {
                entity.HasKey(e => new { e.MessageTypeName, e.TableName, e.ColumnName, e.GetDependOnTableName, e.GetDependOnColumnName })
                    .HasName("PK_GetDependOn_1");

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.ColumnName).HasMaxLength(50);

                entity.Property(e => e.GetDependOnTableName).HasMaxLength(50);

                entity.Property(e => e.GetDependOnColumnName).HasMaxLength(50);

                entity.HasOne(d => d.MessageTypeTable)
                    .WithMany(p => p.GetDependOn)
                    .HasForeignKey(d => new { d.MessageTypeName, d.TableName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GetDependOn_MessageTypeTable");
            });

            modelBuilder.Entity<GetParameter>(entity =>
            {
                entity.HasKey(e => new { e.MessageTypeName, e.TableName, e.GetParameterName })
                    .HasName("PK_GetParameter_1");

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.GetParameterName).HasMaxLength(50);

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MessageTypeTable)
                    .WithMany(p => p.GetParameter)
                    .HasForeignKey(d => new { d.MessageTypeName, d.TableName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GetParameter_MessageTypeTable");
            });

            modelBuilder.Entity<GetType>(entity =>
            {
                entity.Property(e => e.GetTypeId).ValueGeneratedNever();

                entity.Property(e => e.GetTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupCode);

                entity.Property(e => e.GroupCode).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GroupMenu>(entity =>
            {
                entity.HasKey(e => new { e.GroupCode, e.MenuCode });

                entity.Property(e => e.GroupCode).HasMaxLength(10);

                entity.Property(e => e.MenuCode).HasMaxLength(10);

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.GroupMenu)
                    .HasForeignKey(d => d.GroupCode)
                    .HasConstraintName("FK_GroupMenu_Group");

                entity.HasOne(d => d.MenuCodeNavigation)
                    .WithMany(p => p.GroupMenu)
                    .HasForeignKey(d => d.MenuCode)
                    .HasConstraintName("FK_GroupMenu_Menu");
            });

            modelBuilder.Entity<GroupProperty>(entity =>
            {
                entity.HasKey(e => e.GroupPropertyCode);

                entity.Property(e => e.GroupPropertyCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupPropertyName).HasMaxLength(500);
            });

            modelBuilder.Entity<GroupReceiverObject>(entity =>
            {
                entity.HasKey(e => e.GroupObjectID);

                entity.Property(e => e.GroupObjectID).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupObjectCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupObjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.GroupReceiverObject)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupReceiverObject_POS");
            });

            modelBuilder.Entity<GroupReceiverObjectDetail>(entity =>
            {
                entity.HasKey(e => e.ObjectDetailID);

                entity.Property(e => e.ObjectDetailID).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerTel).HasMaxLength(15);

                entity.Property(e => e.ReceiverDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.ReceiverDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.HasOne(d => d.GroupObject)
                    .WithMany(p => p.GroupReceiverObjectDetail)
                    .HasForeignKey(d => d.GroupObjectID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupReceiverObjectDetail_GroupReceiverObject");

                entity.HasOne(d => d.ReceiverCommuneCodeNavigation)
                    .WithMany(p => p.GroupReceiverObjectDetail)
                    .HasForeignKey(d => d.ReceiverCommuneCode)
                    .HasConstraintName("FK_GroupReceiverObjectDetail_Commune");

                entity.HasOne(d => d.ReceiverDistrictCodeNavigation)
                    .WithMany(p => p.GroupReceiverObjectDetail)
                    .HasForeignKey(d => d.ReceiverDistrictCode)
                    .HasConstraintName("FK_GroupReceiverObjectDetail_District");

                entity.HasOne(d => d.ReceiverProvinceCodeNavigation)
                    .WithMany(p => p.GroupReceiverObjectDetail)
                    .HasForeignKey(d => d.ReceiverProvinceCode)
                    .HasConstraintName("FK_GroupReceiverObjectDetail_Province");
            });

            modelBuilder.Entity<GroupRole>(entity =>
            {
                entity.HasKey(e => new { e.GroupCode, e.RoleCode });

                entity.Property(e => e.GroupCode).HasMaxLength(10);

                entity.Property(e => e.RoleCode).HasMaxLength(50);

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.GroupRole)
                    .HasForeignKey(d => d.GroupCode)
                    .HasConstraintName("FK_GroupRole_Group");

                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.GroupRole)
                    .HasForeignKey(d => d.RoleCode)
                    .HasConstraintName("FK_GroupRole_Role");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "KT1");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.HolidayCode)
                    .HasName("PK__Holidays__2B803210");

                entity.Property(e => e.HolidayCode).ValueGeneratedNever();

                entity.Property(e => e.HolidayDate).HasColumnType("datetime");

                entity.Property(e => e.HolidayDateText)
                    .HasMaxLength(4000)
                    .HasComputedColumnSql("(format([HolidayDate],'dd/MM'))");

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HolidayYear)
                    .HasMaxLength(4000)
                    .HasComputedColumnSql("(format([HolidayDate],'yyyy'))");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Reason).HasMaxLength(200);
            });

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.Property(e => e.IncidentID).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.FromPOSCode)
                    .HasMaxLength(6)
                    .HasComment("Bưu cục phát sinh sự vụ");

                entity.Property(e => e.IncidentCataloge).HasComment("Nhóm sự vụ: Giao dịch, khai thác");

                entity.Property(e => e.IncidentCode)
                    .HasMaxLength(20)
                    .HasComment("Mã sự vụ");

                entity.Property(e => e.IncidentContent)
                    .HasMaxLength(4000)
                    .HasComment("Nội dung sự vụ");

                entity.Property(e => e.IncidentDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày sự vụ");

                entity.Property(e => e.IncidentStatus).HasComment("Trạng thái sự vụ: 0 khơi tạo, 1 đã gửi, 2 đã xử lý");

                entity.Property(e => e.IncidentType).HasComment("LOại sự vụ");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.ResponseContent)
                    .HasMaxLength(4000)
                    .HasComment("Nội dung phản hồi");

                entity.Property(e => e.ResponseDate)
                    .HasColumnType("date")
                    .HasComment("Ngày phản hồi");

                entity.Property(e => e.ResponseType).HasComment("Loại phản hồi");

                entity.Property(e => e.ToPOSCode)
                    .HasMaxLength(6)
                    .HasComment("Bưu cục nhận sự vụ");

                entity.Property(e => e.URLFile)
                    .HasMaxLength(4000)
                    .HasComment("file đính kèm");

                entity.Property(e => e.UsernameCreated)
                    .HasMaxLength(50)
                    .HasComment("Người tạo sự vụ");

                entity.Property(e => e.UsernameResponse)
                    .HasMaxLength(50)
                    .HasComment("Người phản hồi");

                entity.HasOne(d => d.IncidentCatalogeNavigation)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.IncidentCataloge)
                    .HasConstraintName("FK_Incident_IncidentCategory");

                entity.HasOne(d => d.IncidentTypeNavigation)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.IncidentType)
                    .HasConstraintName("FK_Incident_IncidentType");

                entity.HasOne(d => d.ResponseTypeNavigation)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.ResponseType)
                    .HasConstraintName("FK_Incident_IncidentResponseType");
            });

            modelBuilder.Entity<IncidentCategory>(entity =>
            {
                entity.Property(e => e.IncidentCategoryName).HasMaxLength(250);
            });

            modelBuilder.Entity<IncidentCategoryType>(entity =>
            {
                entity.HasKey(e => new { e.IncidentCategoryID, e.IncidentTypeID });

                entity.HasOne(d => d.IncidentCategory)
                    .WithMany(p => p.IncidentCategoryType)
                    .HasForeignKey(d => d.IncidentCategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IncidentCategoryType_IncidentCategory");

                entity.HasOne(d => d.IncidentType)
                    .WithMany(p => p.IncidentCategoryType)
                    .HasForeignKey(d => d.IncidentTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IncidentCategoryType_IncidentType");
            });

            modelBuilder.Entity<IncidentItem>(entity =>
            {
                entity.HasKey(e => new { e.IncidentID, e.ItemID });

                entity.Property(e => e.NewReceiverAddress).HasMaxLength(250);

                entity.Property(e => e.NewReceiverCommuneCode).HasMaxLength(50);

                entity.Property(e => e.NewReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.NewReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.NewReceiverDistrictCode).HasMaxLength(50);

                entity.Property(e => e.NewReceiverFullName).HasMaxLength(250);

                entity.Property(e => e.NewReceiverProvinceCode).HasMaxLength(50);

                entity.Property(e => e.NewSenderAddress).HasMaxLength(250);

                entity.Property(e => e.NewSenderCommuneCode).HasMaxLength(50);

                entity.Property(e => e.NewSenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.NewSenderCustomerName).HasMaxLength(500);

                entity.Property(e => e.NewSenderDistrictCode).HasMaxLength(50);

                entity.Property(e => e.NewSenderFullName).HasMaxLength(250);

                entity.Property(e => e.NewSenderProvinceCode).HasMaxLength(50);

                entity.Property(e => e.OldReceiverAddress).HasMaxLength(250);

                entity.Property(e => e.OldReceiverCommuneCode).HasMaxLength(50);

                entity.Property(e => e.OldReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.OldReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.OldReceiverDistrictCode).HasMaxLength(50);

                entity.Property(e => e.OldReceiverFullname).HasMaxLength(250);

                entity.Property(e => e.OldReceiverProvinceCode).HasMaxLength(50);

                entity.Property(e => e.OldSenderAddress).HasMaxLength(250);

                entity.Property(e => e.OldSenderCommuneCode).HasMaxLength(50);

                entity.Property(e => e.OldSenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.OldSenderCustomerName).HasMaxLength(500);

                entity.Property(e => e.OldSenderDistrictCode).HasMaxLength(50);

                entity.Property(e => e.OldSenderFullname).HasMaxLength(250);

                entity.Property(e => e.OldSenderProvinceCode).HasMaxLength(50);

                entity.HasOne(d => d.Incident)
                    .WithMany(p => p.IncidentItem)
                    .HasForeignKey(d => d.IncidentID)
                    .HasConstraintName("FK_IncidentItem_Incident");
            });

            modelBuilder.Entity<IncidentPostbag>(entity =>
            {
                entity.HasKey(e => new { e.IncidentID, e.PostbagID });

                entity.HasOne(d => d.Incident)
                    .WithMany(p => p.IncidentPostbag)
                    .HasForeignKey(d => d.IncidentID)
                    .HasConstraintName("FK_IncidentPostbag_Incident");
            });

            modelBuilder.Entity<IncidentResponseType>(entity =>
            {
                entity.Property(e => e.ResponseType).HasMaxLength(250);
            });

            modelBuilder.Entity<IncidentType>(entity =>
            {
                entity.Property(e => e.IncidentTypeName).HasMaxLength(250);
            });

            modelBuilder.Entity<IntercityJourneysTarget>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FromRegionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ServiceType).HasDefaultValueSql("((1))");

                entity.Property(e => e.ToRegionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Type).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<IntercityJourneysTarget_District>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IntercityJourneysTarget_District");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.District).HasMaxLength(10);
            });

            modelBuilder.Entity<IntercityJourneysTarget_KhuVuc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IntercityJourneysTarget_KhuVuc");

                entity.Property(e => e.FromRegionGroupCode).HasMaxLength(10);

                entity.Property(e => e.ToRegionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<IntercityJourneysTarget_Provice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IntercityJourneysTarget_Provice");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Provice).HasMaxLength(10);
            });

            modelBuilder.Entity<IntercityJourneysTarget_View>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IntercityJourneysTarget_View");

                entity.Property(e => e.District).HasMaxLength(10);

                entity.Property(e => e.FromRegionGroupCode).HasMaxLength(10);

                entity.Property(e => e.Provice).HasMaxLength(10);

                entity.Property(e => e.ToRegionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.InvitationDate });

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.InvitationDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasIndex(e => e.ItemCode)
                    .HasName("idx_Item_ItemCode");

                entity.HasIndex(e => e.ItemTypeCode)
                    .HasName("idx_item_itemtypecode");

                entity.HasIndex(e => e.ReceiverProvinceCode)
                    .HasName("idx_traceitem_receiverProvinceCode");

                entity.HasIndex(e => e.SenderCustomerCode)
                    .HasName("idx_item_SenderCustomerCode");

                entity.HasIndex(e => e.SendingDate)
                    .HasName("idx_Item_SendingDate");

                entity.HasIndex(e => new { e.ItemID, e.SendingDate, e.ThoiGianToanTrinh })
                    .HasName("idx_Delivery_SendingDate_ThoiGianToanTrinh");

                entity.HasIndex(e => new { e.ReceiverCustomerCode, e.SendingDate, e.ItemTypeCode })
                    .HasName("idx_Item_ReceiverCustomerCode_SendingDate_ItemTypeCode");

                entity.HasIndex(e => new { e.SenderCustomerCode, e.SendingDate, e.ItemTypeCode })
                    .HasName("idx_SenderCustomerCode_SendingDate_ItemTypeCode");

                entity.HasIndex(e => new { e.ItemCode, e.AcceptancePOSCode, e.ItemCodeCustomer, e.SenderCustomerCode, e.SenderFullName, e.SenderAddress, e.SenderTel, e.ReceiverCustomerName, e.ReceiverFullName, e.ReceiverProvinceCode, e.ReceiverDistrictCode, e.ReceiverAddress, e.ReceiverTel, e.Weight, e.ItemTypeCode, e.SendingTime })
                    .HasName("IDX_Item_sendingtime");

                entity.Property(e => e.ItemID)
                    .HasComment("ID bưu gửi")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptanceCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Mã  chấp nhận");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục chấp nhận");

                entity.Property(e => e.AcceptedIndex).HasComment("Thứ tự bưu gửi");

                entity.Property(e => e.AcceptedType).HasComment("Loại chấp nhận (lẻ, lô, sll)");

                entity.Property(e => e.AdditionalDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.AdditionalDeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.AdditionalDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.AirSurchargeFreight).HasComment("Cước máy bay");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.AttachFile).HasComment("File đính kèm");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo yêu cầu");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo yêu cầu");

                entity.Property(e => e.CustomerGroupCode)
                    .HasMaxLength(20)
                    .HasComment("Nhóm khách hàng");

                entity.Property(e => e.DeliveryNote)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú khi phát");

                entity.Property(e => e.DeliveryPointCode)
                    .HasMaxLength(10)
                    .HasComment("Điểm phát");

                entity.Property(e => e.DeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.DeliveryRateDesc).HasMaxLength(3000);

                entity.Property(e => e.DeliveryRateTime).HasColumnType("datetime");

                entity.Property(e => e.DestinationPOSCode)
                    .HasMaxLength(6)
                    .HasComment("bưu cục nhận chuyến thư");

                entity.Property(e => e.DiscountAmount).HasComment("Số tiền giảm giá");

                entity.Property(e => e.DiscountPercentage).HasComment("% giảm giá");

                entity.Property(e => e.FarRegionFreight).HasComment("Cước vùng xa");

                entity.Property(e => e.FuelSurchargeFreight).HasComment("Cước xăng dầu");

                entity.Property(e => e.Height).HasComment("Cao");

                entity.Property(e => e.Internal).HasComment("Bưu gửi nội bộ");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasComment("Số hiệu bưu gửi");

                entity.Property(e => e.ItemCodeCustomer)
                    .HasMaxLength(500)
                    .HasComment("Số hiệu khách hàng / số công văn");

                entity.Property(e => e.ItemIDOriginal).HasComment("ID gốc");

                entity.Property(e => e.ItemNumberAcceptance).HasComment("Số lượng");

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(3)
                    .HasComment("Loại bưu gửi");

                entity.Property(e => e.Length).HasComment("Dài");

                entity.Property(e => e.MainFreight).HasComment("Cước chính");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người chỉnh sửa yêu cầu");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày chỉnh sửa yêu cầu");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú");

                entity.Property(e => e.OtherFreight).HasComment("Cước khác");

                entity.Property(e => e.PaymentFreight).HasComment("Cước đã trả");

                entity.Property(e => e.PaymentFreightDiscount).HasComment("Cước đã trả sau giảm giá");

                entity.Property(e => e.PaymentFreightDiscountVAT).HasComment("cước đã trả sau giảm giá có VAT");

                entity.Property(e => e.PaymentFreightVAT).HasComment("cước đã trả có VAT");

                entity.Property(e => e.ReasonModified)
                    .HasMaxLength(500)
                    .HasComment("Lý do điều chỉnh");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ nhận");

                entity.Property(e => e.ReceiverCommuneCode)
                    .HasMaxLength(6)
                    .HasComment("Địa chỉ nhận: phường /xã");

                entity.Property(e => e.ReceiverContact)
                    .HasMaxLength(500)
                    .HasComment("Người liên hệ khi phát");

                entity.Property(e => e.ReceiverCustomerAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ khách hàng nhận");

                entity.Property(e => e.ReceiverCustomerCode)
                    .HasMaxLength(17)
                    .HasComment("Mã khách hàng nhận");

                entity.Property(e => e.ReceiverCustomerName)
                    .HasMaxLength(500)
                    .HasComment("Tên khách hàng nhận");

                entity.Property(e => e.ReceiverCustomerTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại khách hàng nhận");

                entity.Property(e => e.ReceiverDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.ReceiverDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ReceiverDistrictCenter).HasComment("Nhận tại trung tâm quận huyện");

                entity.Property(e => e.ReceiverDistrictCode)
                    .HasMaxLength(4)
                    .HasComment("Địa chỉ nhận: quận / huyện");

                entity.Property(e => e.ReceiverEmail)
                    .HasMaxLength(50)
                    .HasComment("Email người nhận");

                entity.Property(e => e.ReceiverFax)
                    .HasMaxLength(15)
                    .HasComment("Fax người nhận");

                entity.Property(e => e.ReceiverFullName)
                    .HasMaxLength(500)
                    .HasComment("Tên khách hàng nhận");

                entity.Property(e => e.ReceiverIdentifyNumber)
                    .HasMaxLength(20)
                    .HasComment("Số CMND/ CCCD");

                entity.Property(e => e.ReceiverProvinceCenter).HasComment("Nhận tại trung tâm tỉnh TP");

                entity.Property(e => e.ReceiverProvinceCode)
                    .HasMaxLength(3)
                    .HasComment("Địa chỉ nhận: tỉnh / tp");

                entity.Property(e => e.ReceiverTaxCode)
                    .HasMaxLength(50)
                    .HasComment("Mã số thuế người nhận");

                entity.Property(e => e.ReceiverTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại người nhận");

                entity.Property(e => e.RegionFreight)
                    .HasMaxLength(50)
                    .HasComment("Vùng cước");

                entity.Property(e => e.RequestID).HasComment("ID yêu cầu");

                entity.Property(e => e.SenderAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ gửi");

                entity.Property(e => e.SenderCommuneCode)
                    .HasMaxLength(6)
                    .HasComment("Địa chỉ gửi: Phường /xã");

                entity.Property(e => e.SenderCustomerCode)
                    .HasMaxLength(17)
                    .HasComment("Mã khách hàng gửi");

                entity.Property(e => e.SenderDistrictCode)
                    .HasMaxLength(4)
                    .HasComment("Địa chỉ gửi: quận / huyện");

                entity.Property(e => e.SenderEmail)
                    .HasMaxLength(50)
                    .HasComment("Email người gửi");

                entity.Property(e => e.SenderFax)
                    .HasMaxLength(15)
                    .HasComment("Fax người gửi");

                entity.Property(e => e.SenderFullName)
                    .HasMaxLength(500)
                    .HasComment("Tên khách hàng gửi");

                entity.Property(e => e.SenderIdentifyNumber)
                    .HasMaxLength(20)
                    .HasComment("Số CMND/ CCCD");

                entity.Property(e => e.SenderProvinceCode)
                    .HasMaxLength(3)
                    .HasComment("Địa chỉ gửi: tỉnh / tp");

                entity.Property(e => e.SenderTaxCode)
                    .HasMaxLength(50)
                    .HasComment("Mã số thuế người gửi");

                entity.Property(e => e.SenderTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại người gửi");

                entity.Property(e => e.SendingDate)
                    .HasMaxLength(8)
                    .HasComputedColumnSql("([dbo].[CP_FORMAT_DATE]([SendingTime]))");

                entity.Property(e => e.SendingTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian nhận gửi");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("Dịch vụ");

                entity.Property(e => e.Status).HasComment("Trạng thái yêu cầu: 1 - Đang khởi tạo; 2 - Chờ phê duyệt; 3 - Đã duyệt; 4 - Từ chối duyệt; 5 - Đã nhận gửi");

                entity.Property(e => e.SubFreight).HasComment("Cước GTGT");

                entity.Property(e => e.ThoiGianToanTrinh).HasColumnType("datetime");

                entity.Property(e => e.TimerDelivery)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian hẹn phát");

                entity.Property(e => e.TotalFreightDiscount).HasComment("Tổng cước giảm giá");

                entity.Property(e => e.TotalFreightDiscountVAT).HasComment("Tổng cước giảm giá có VAT");

                entity.Property(e => e.TotalFreightVAT).HasComment("Tổng cước VAT");

                entity.Property(e => e.TracePOSCode).HasMaxLength(6);

                entity.Property(e => e.UndeliveryGuideCode).HasComment("0: Chuyển hoàn ngay, 1: Chuyển hoàn khi hết hạn lưu giữ, 2: Hủy");

                entity.Property(e => e.VATFreight).HasComment("Cước VAT");

                entity.Property(e => e.VATPercentage).HasComment("% VAT");

                entity.Property(e => e.VPostCode).HasMaxLength(100);

                entity.Property(e => e.Weight).HasComment("Khối lượng");

                entity.Property(e => e.WeightConvert).HasComment("Khối lượng quy đổi");

                entity.Property(e => e.Width).HasComment("Rộng");

                entity.HasOne(d => d.AcceptancePOSCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.AcceptancePOSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_POS1");

                entity.HasOne(d => d.CustomerGroupCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CustomerGroupCode)
                    .HasConstraintName("FK_Item_CustomerGroup");

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .HasConstraintName("FK_Item_ItemType1");

                entity.HasOne(d => d.ReceiverCommuneCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ReceiverCommuneCode)
                    .HasConstraintName("FK_Item_Commune");

                entity.HasOne(d => d.ReceiverCustomerCodeNavigation)
                    .WithMany(p => p.ItemReceiverCustomerCodeNavigation)
                    .HasForeignKey(d => d.ReceiverCustomerCode)
                    .HasConstraintName("FK_Item_Customer1");

                entity.HasOne(d => d.ReceiverDistrictCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ReceiverDistrictCode)
                    .HasConstraintName("FK_Item_District1");

                entity.HasOne(d => d.ReceiverProvinceCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ReceiverProvinceCode)
                    .HasConstraintName("FK_Item_Province1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.RequestID)
                    .HasConstraintName("FK_Item_RequestAccepted");

                entity.HasOne(d => d.SenderCustomerCodeNavigation)
                    .WithMany(p => p.ItemSenderCustomerCodeNavigation)
                    .HasForeignKey(d => d.SenderCustomerCode)
                    .HasConstraintName("FK_Item_Customer");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Service1");

                entity.HasOne(d => d.UndeliveryGuideCodeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.UndeliveryGuideCode)
                    .HasConstraintName("FK_Item_UndeliveryGuide");
            });

            modelBuilder.Entity<ItemAdviceOfReceipt>(entity =>
            {
                entity.HasKey(e => new { e.AdviceOfReceiptCode, e.ItemID })
                    .HasName("PK_ItemAdviceOfReceipt_1");

                entity.Property(e => e.AdviceOfReceiptCode).HasMaxLength(13);

                entity.Property(e => e.CheckContentOnDeliveryCode).HasMaxLength(13);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemAdviceOfReceipt)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemAdviceOfReceipt_ItemReturn");
            });

            modelBuilder.Entity<ItemBack_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AdviceOfReceiptCode).HasMaxLength(13);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CODAddress).HasMaxLength(200);

                entity.Property(e => e.CertificateNumber).HasMaxLength(50);

                entity.Property(e => e.CheckContentOnDeliveryCode).HasMaxLength(13);

                entity.Property(e => e.CheckSum).HasMaxLength(1);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerAccountNo).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.CustomerGroupCode).HasMaxLength(20);

                entity.Property(e => e.DataCode).HasMaxLength(50);

                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.DecisionNo).HasMaxLength(500);

                entity.Property(e => e.DeliveryNote).HasMaxLength(500);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.ExchangeRateCode).HasMaxLength(50);

                entity.Property(e => e.ExecuteOrder).HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemNumber).HasMaxLength(50);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.MachineName).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.OtherAttachedInfor).HasMaxLength(100);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(7);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(100);

                entity.Property(e => e.ReceiverCustomReference).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverJob).HasMaxLength(500);

                entity.Property(e => e.ReceiverMobile).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.ReturnBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.SectionCode).HasMaxLength(3);

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderAddressCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomReference).HasMaxLength(500);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SenderIdentification).HasMaxLength(50);

                entity.Property(e => e.SenderIssueCountry).HasMaxLength(50);

                entity.Property(e => e.SenderIssueDate).HasColumnType("datetime");

                entity.Property(e => e.SenderJob).HasMaxLength(500);

                entity.Property(e => e.SenderMobile).HasMaxLength(15);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(20);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.UndeliverableReason).HasMaxLength(500);
            });

            modelBuilder.Entity<ItemCallHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(256);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<ItemCommodityType>(entity =>
            {
                entity.HasKey(e => e.ItemID)
                    .HasName("PK_ItemCommodityType_1");

                entity.Property(e => e.ItemID).ValueGeneratedNever();

                entity.Property(e => e.CommodityTypeCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.CommodityTypeCodeNavigation)
                    .WithMany(p => p.ItemCommodityType)
                    .HasForeignKey(d => d.CommodityTypeCode)
                    .HasConstraintName("FK_ItemCommodityType_CommodityType");
            });

            modelBuilder.Entity<ItemCommodityType_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CommodityTypeCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemCompensate>(entity =>
            {
                entity.HasKey(e => e.ItemID)
                    .HasName("PK_ItemCompensate_1");

                entity.Property(e => e.ItemID).ValueGeneratedNever();

                entity.Property(e => e.CompensateDate).HasColumnType("datetime");

                entity.Property(e => e.CompensatePOSCode).HasMaxLength(6);

                entity.Property(e => e.CompensateReason).HasMaxLength(2000);

                entity.Property(e => e.CompensateUsername).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemCompensate_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CompensateDate).HasColumnType("datetime");

                entity.Property(e => e.CompensatePOSCode).HasMaxLength(6);

                entity.Property(e => e.CompensateReason).HasMaxLength(2000);

                entity.Property(e => e.CompensateUsername).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemDeliveryTransfered>(entity =>
            {
                entity.HasKey(e => new { e.Direct, e.ToPOSCode, e.DeliveryIndex, e.ItemID });

                entity.Property(e => e.Direct).HasMaxLength(50);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemExclude>(entity =>
            {
                entity.HasKey(e => e.ExcludeID);

                entity.Property(e => e.ExcludeID).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(20)
                    .HasComputedColumnSql("([dbo].[Dispatch_ItemCode]([ItemID]))");

                entity.Property(e => e.ItemID).HasComment("Id bưu gửi");

                entity.Property(e => e.PostBagID).HasComment("Id túi thư");

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemExclude)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemExclude_Item");

                entity.HasOne(d => d.PostBag)
                    .WithMany(p => p.ItemExclude)
                    .HasForeignKey(d => d.PostBagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemExclude_PostBag");
            });

            modelBuilder.Entity<ItemForward>(entity =>
            {
                entity.HasKey(e => new { e.ForwardDate, e.ItemID })
                    .HasName("PK_ItemForward_1");

                entity.Property(e => e.ForwardDate).HasColumnType("datetime");

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.CommuneCodeOld).HasMaxLength(6);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CountryCodeOld).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.DistrictCodeOld).HasMaxLength(4);

                entity.Property(e => e.ForwardPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.POSCodeOld).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.Property(e => e.ProvinceCodeOld).HasMaxLength(2);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCodeOld).HasMaxLength(6);

                entity.Property(e => e.ReceiverAddressOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverContactOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(100);

                entity.Property(e => e.ReceiverEmailOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverFaxOld).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(500);

                entity.Property(e => e.ReceiverFullnameOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentificationOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverMobileOld).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCodeOld).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(50);

                entity.Property(e => e.ReceiverTelOld).HasMaxLength(15);
            });

            modelBuilder.Entity<ItemForward_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.CommuneCodeOld).HasMaxLength(6);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CountryCodeOld).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.DistrictCodeOld).HasMaxLength(4);

                entity.Property(e => e.ForwardDate).HasColumnType("datetime");

                entity.Property(e => e.ForwardPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.POSCodeOld).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.Property(e => e.ProvinceCodeOld).HasMaxLength(2);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCodeOld).HasMaxLength(7);

                entity.Property(e => e.ReceiverAddressOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverContactOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(100);

                entity.Property(e => e.ReceiverEmailOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverFaxOld).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(500);

                entity.Property(e => e.ReceiverFullnameOld).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentificationOld).HasMaxLength(50);

                entity.Property(e => e.ReceiverMobileOld).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCodeOld).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(50);

                entity.Property(e => e.ReceiverTelOld).HasMaxLength(15);
            });

            modelBuilder.Entity<ItemInventory>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.ItemID });

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemInventory_Item");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemInventory_ShiftHandover");
            });

            modelBuilder.Entity<ItemPropertyValue_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.PropertyCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(500);
            });

            modelBuilder.Entity<ItemReturn>(entity =>
            {
                entity.HasKey(e => e.ItemID)
                    .HasName("PK_ItemReturn_1");

                entity.Property(e => e.ItemID).ValueGeneratedNever();

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(500);

                entity.Property(e => e.ReceiverTel).HasMaxLength(50);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnPosCode).HasMaxLength(6);

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.ItemReturn)
                    .HasForeignKey<ItemReturn>(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReturn_Item1");
            });

            modelBuilder.Entity<ItemReturn_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(500);

                entity.Property(e => e.ReceiverTel).HasMaxLength(50);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.ItemTypeCode);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ItemTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([ItemTypeName])))");

                entity.Property(e => e.ShortName).HasMaxLength(30);
            });

            modelBuilder.Entity<ItemTypeNotUsedValueAddedService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ItemTypeCode, e.ValueAddedServiceCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(6);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(6);
            });

            modelBuilder.Entity<ItemTypeUsedValueAddedService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ItemTypeCode, e.ValueAddedServiceCode })
                    .HasName("PK_ItemTypeUsingValueAddedService");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(6);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(6);
            });

            modelBuilder.Entity<ItemType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ItemVASFreight>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemVASFreight)
                    .HasForeignKey(d => d.ItemID)
                    .HasConstraintName("FK_ItemVASFreight_Item");
            });

            modelBuilder.Entity<ItemVASPropertyValue>(entity =>
            {
                entity.HasKey(e => new { e.PropertyCode, e.ValueAddedServiceCode, e.ItemID })
                    .HasName("PK_ItemVASPropertyValue_1");

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.VASProperty)
                    .WithMany(p => p.ItemVASPropertyValue)
                    .HasForeignKey(d => new { d.PropertyCode, d.ValueAddedServiceCode })
                    .HasConstraintName("FK_ItemVASPropertyValue_VASProperty");
            });

            modelBuilder.Entity<ItemVASPropertyValueChanged>(entity =>
            {
                entity.HasKey(e => new { e.ChangeIndex, e.HandoverIndex, e.ChangePOSCode, e.ItemID })
                    .HasName("PK_ItemVASPropertyValueChanged_1");

                entity.Property(e => e.ChangePOSCode).HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.PropertyCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.Property(e => e.ValueAddedServiceCode)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<ItemVASPropertyValueLog>(entity =>
            {
                entity.HasKey(e => new { e.ItemLogId, e.PropertyCode, e.ValueAddedServiceCode, e.ItemID });

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Value).HasMaxLength(500);
            });

            modelBuilder.Entity<ItemVASPropertyValue_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.PropertyCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.Property(e => e.ValueAddedServiceCode)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Item_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AdviceOfReceiptCode).HasMaxLength(13);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CODAddress).HasMaxLength(200);

                entity.Property(e => e.CertificateNumber).HasMaxLength(50);

                entity.Property(e => e.CheckContentOnDeliveryCode).HasMaxLength(13);

                entity.Property(e => e.CheckSum).HasMaxLength(1);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerAccountNo).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.CustomerGroupCode).HasMaxLength(20);

                entity.Property(e => e.DataCode).HasMaxLength(50);

                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.DecisionNo).HasMaxLength(500);

                entity.Property(e => e.DeliveryNote).HasMaxLength(500);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.ExchangeRateCode).HasMaxLength(50);

                entity.Property(e => e.ExecuteOrder).HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemNumber).HasMaxLength(50);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.MachineName).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.OtherAttachedInfor).HasMaxLength(100);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReceiverAddressCode).HasMaxLength(7);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(100);

                entity.Property(e => e.ReceiverCustomReference).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverJob).HasMaxLength(500);

                entity.Property(e => e.ReceiverMobile).HasMaxLength(15);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(20);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.ReturnBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.SectionCode).HasMaxLength(3);

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderAddressCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomReference).HasMaxLength(500);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SenderIdentification).HasMaxLength(50);

                entity.Property(e => e.SenderIssueCountry).HasMaxLength(50);

                entity.Property(e => e.SenderIssueDate).HasColumnType("datetime");

                entity.Property(e => e.SenderJob).HasMaxLength(500);

                entity.Property(e => e.SenderMobile).HasMaxLength(15);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(20);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.UndeliverableReason).HasMaxLength(500);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "KT1");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.HasIndex(e => new { e.StateName, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "KT1");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "KT1");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<LetterMoneyOrder>(entity =>
            {
                entity.HasKey(e => new { e.LetterMoneyOrderCode, e.LetterMoneyOrderRuleCode, e.ServiceCode });

                entity.Property(e => e.LetterMoneyOrderCode).HasMaxLength(10);

                entity.Property(e => e.LetterMoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.LetterMoneyOrderRule)
                    .WithMany(p => p.LetterMoneyOrder)
                    .HasForeignKey(d => new { d.LetterMoneyOrderRuleCode, d.ServiceCode })
                    .HasConstraintName("FK_LetterMoneyOrder_LetterMoneyOrderRule1");
            });

            modelBuilder.Entity<LetterMoneyOrderRule>(entity =>
            {
                entity.HasKey(e => new { e.LetterMoneyOrderRuleCode, e.ServiceCode });

                entity.Property(e => e.LetterMoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RuleNo).HasMaxLength(100);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.LetterMoneyOrderRule)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_LetterMoneyOrderRule_Service");
            });

            modelBuilder.Entity<LicenseInformation>(entity =>
            {
                entity.HasKey(e => e.LicenseId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MachineName).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PublicKey)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LicenseStorage>(entity =>
            {
                entity.HasKey(e => e.ApplicationId);

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.POSName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PrivateKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublicKey)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LimitWeight>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.ServiceCode });

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.LimitWeight)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_LimitWeight_Country");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.LimitWeight)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_LimitWeight_Service");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "KT1");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => new { e.MachineCode, e.CounterCode, e.POSCode });

                entity.Property(e => e.MachineCode).HasMaxLength(3);

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MachineIP).HasMaxLength(50);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.Machine)
                    .HasForeignKey(d => new { d.CounterCode, d.POSCode })
                    .HasConstraintName("FK_Machine_Counter");
            });

            modelBuilder.Entity<MailRoute>(entity =>
            {
                entity.HasKey(e => new { e.MailRouteCode, e.FromPOSCode });

                entity.HasIndex(e => e.MailRouteNameSearch)
                    .HasName("ix_mailroute_name_search");

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MailRouteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MailRouteNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([MailRouteName])),0))");

                entity.Property(e => e.MailRouteTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);

                entity.HasOne(d => d.FromPOSCodeNavigation)
                    .WithMany(p => p.MailRoute)
                    .HasForeignKey(d => d.FromPOSCode)
                    .HasConstraintName("FK_MailRoute_POS");

                entity.HasOne(d => d.MailRouteTypeCodeNavigation)
                    .WithMany(p => p.MailRoute)
                    .HasForeignKey(d => d.MailRouteTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailRoute_MailRouteType");

                entity.HasOne(d => d.TransportTypeCodeNavigation)
                    .WithMany(p => p.MailRoute)
                    .HasForeignKey(d => d.TransportTypeCode)
                    .HasConstraintName("FK_MailRoute_TransportType");
            });

            modelBuilder.Entity<MailRoutePOS>(entity =>
            {
                entity.HasKey(e => new { e.MailRouteCode, e.FromPOSCode, e.OnMailRoutePOSCode, e.MailRouteScheduleCode, e.Type });

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.OnMailRoutePOSCode).HasMaxLength(6);

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(5);

                entity.Property(e => e.IncomingTime).HasColumnType("datetime");

                entity.Property(e => e.OutgoingTime).HasColumnType("datetime");

                entity.HasOne(d => d.OnMailRoutePOSCodeNavigation)
                    .WithMany(p => p.MailRoutePOS)
                    .HasForeignKey(d => d.OnMailRoutePOSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailRoutePOS_POS1");

                entity.HasOne(d => d.MailRouteSchedule)
                    .WithMany(p => p.MailRoutePOS)
                    .HasForeignKey(d => new { d.MailRouteScheduleCode, d.MailRouteCode, d.FromPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailRoutePOS_MailRouteSchedule");
            });

            modelBuilder.Entity<MailRoutePOS_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.IncomingTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MailRouteScheduleCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.OnMailRoutePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.OutgoingTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MailRouteSchedule>(entity =>
            {
                entity.HasKey(e => new { e.MailRouteScheduleCode, e.MailRouteCode, e.FromPOSCode });

                entity.Property(e => e.MailRouteScheduleCode).HasMaxLength(5);

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MailRouteScheduleName).HasMaxLength(500);

                entity.HasOne(d => d.MailRoute)
                    .WithMany(p => p.MailRouteSchedule)
                    .HasForeignKey(d => new { d.MailRouteCode, d.FromPOSCode })
                    .HasConstraintName("FK_MailRouteSchedule_MailRoute");
            });

            modelBuilder.Entity<MailRouteSchedule_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MailRouteScheduleCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.MailRouteScheduleName).HasMaxLength(500);
            });

            modelBuilder.Entity<MailRouteService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.MailRouteCode, e.FromPOSCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.MailRouteService)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_MailRouteService_Service");

                entity.HasOne(d => d.MailRoute)
                    .WithMany(p => p.MailRouteService)
                    .HasForeignKey(d => new { d.MailRouteCode, d.FromPOSCode })
                    .HasConstraintName("FK_MailRouteService_MailRoute");
            });

            modelBuilder.Entity<MailRouteType>(entity =>
            {
                entity.HasKey(e => e.MailRouteTypeCode);

                entity.HasIndex(e => e.MailRouteTypeNameSearch)
                    .HasName("ix_mailroutetype_name_search");

                entity.Property(e => e.MailRouteTypeCode).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MailRouteTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MailRouteTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([MailRouteTypeName])),0))");
            });

            modelBuilder.Entity<MailRouteType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MailRouteTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.MailRouteTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MailRoute_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MailRouteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MailRouteTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);
            });

            modelBuilder.Entity<MailTripBCCP>(entity =>
            {
                entity.HasKey(e => new { e.StartingCode, e.DestinationCode, e.MailtripType, e.ServiceCode, e.Year, e.MailtripNumber });

                entity.Property(e => e.StartingCode).HasMaxLength(6);

                entity.Property(e => e.DestinationCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.Year).HasMaxLength(8);
            });

            modelBuilder.Entity<Mailtrip>(entity =>
            {
                entity.HasComment("Chuyến thư");

                entity.HasIndex(e => e.OpeningDateOnly)
                    .HasName("idx_Mailtrip_OpeningDateOnly");

                entity.Property(e => e.MailtripID)
                    .HasComment("ID chuyến thư")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .HasComment("Người phê duyệt");

                entity.Property(e => e.ApprovedContent)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú phê duyệt");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày phê duyệt");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục nhận");

                entity.Property(e => e.InitialBy)
                    .HasMaxLength(50)
                    .HasComment("Người khởi tạo");

                entity.Property(e => e.InitialDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày khởi tạo chuyến thư");

                entity.Property(e => e.InitialMachine)
                    .HasMaxLength(50)
                    .HasComment("Máy tính thực hiện");

                entity.Property(e => e.InitialType).HasDefaultValueSql("((1))");

                entity.Property(e => e.MailtripNumber).HasComment("Số chuyến thư");

                entity.Property(e => e.MailtripType).HasComment("Loại chuyến thư");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.OpeningBy)
                    .HasMaxLength(50)
                    .HasComment("Người mở");

                entity.Property(e => e.OpeningDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày mở");

                entity.Property(e => e.OpeningDateOnly)
                    .HasMaxLength(8)
                    .HasComputedColumnSql("([dbo].[CP_FORMAT_DATE]([OpeningDate]))");

                entity.Property(e => e.OpeningMachine)
                    .HasMaxLength(50)
                    .HasComment("Máy tính thực hiện");

                entity.Property(e => e.PackagingBy)
                    .HasMaxLength(50)
                    .HasComment("Người đóng");

                entity.Property(e => e.PackagingDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày đóng");

                entity.Property(e => e.PackagingDateOnly)
                    .HasMaxLength(8)
                    .HasComputedColumnSql("([dbo].[CP_FORMAT_DATE]([PackagingDate]))");

                entity.Property(e => e.PackagingMachine)
                    .HasMaxLength(50)
                    .HasComment("Máy tính thực hiện");

                entity.Property(e => e.Quantity).HasComment("Số lượng");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("Dịch vụ");

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục đóng");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.TransferStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type).HasComment(@"0: Đóng cho nội bộ
1: Đóng cho đối tác
2: Đóng cho các nước
3: Đóng cho bưu tá");

                entity.Property(e => e.Weight).HasComment("Khối lượng");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasComment("Ngày chuyến thư");

                entity.HasOne(d => d.DestinationCodeNavigation)
                    .WithMany(p => p.MailtripDestinationCodeNavigation)
                    .HasForeignKey(d => d.DestinationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mailtrip_POS1");

                entity.HasOne(d => d.MailtripTypeNavigation)
                    .WithMany(p => p.Mailtrip)
                    .HasForeignKey(d => d.MailtripType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mailtrip_MailtripType");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.Mailtrip)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mailtrip_Service");

                entity.HasOne(d => d.StartingCodeNavigation)
                    .WithMany(p => p.MailtripStartingCodeNavigation)
                    .HasForeignKey(d => d.StartingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mailtrip_POS");
            });

            modelBuilder.Entity<MailtripDelivery>(entity =>
            {
                entity.HasKey(e => e.MailtripID);

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("idx_MailtripDelivery_CreatedBy");

                entity.HasIndex(e => e.CreatedDateOnly)
                    .HasName("idx_MailtripDelivery_CreatedDateOnly");

                entity.HasIndex(e => e.DeliveryRouteCode)
                    .HasName("idx_MailtripDelivery_DeliveryRouteCode");

                entity.HasIndex(e => e.POSCode)
                    .HasName("idx_MailtripDelivery_POSCode");

                entity.Property(e => e.MailtripID).ValueGeneratedNever();

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmBy).HasMaxLength(50);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDateOnly)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](8),[CreatedDate],(112)))");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.InitialBy).HasMaxLength(50);

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachine).HasMaxLength(50);

                entity.Property(e => e.MailtripDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBy).HasMaxLength(50);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackagingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransportCode).HasMaxLength(10);

                entity.Property(e => e.URLFile).HasMaxLength(4000);
            });

            modelBuilder.Entity<MailtripItem>(entity =>
            {
                entity.HasKey(e => new { e.MailtripID, e.ItemID });

                entity.Property(e => e.ExtendServiceCode).HasMaxLength(1);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.MailtripNumber).HasMaxLength(4);

                entity.Property(e => e.MailtripType).HasMaxLength(1);

                entity.Property(e => e.ServiceCode).HasMaxLength(1);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.Year).HasMaxLength(1);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.MailtripItem)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripItem_Item1");

                entity.HasOne(d => d.Mailtrip)
                    .WithMany(p => p.MailtripItem)
                    .HasForeignKey(d => d.MailtripID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripItem_MailtripDelivery");
            });

            modelBuilder.Entity<MailtripPostBagEmpty>(entity =>
            {
                entity.HasKey(e => new { e.MailtripID, e.PostBagTypeCode });

                entity.Property(e => e.PostBagTypeCode).HasMaxLength(2);

                entity.HasOne(d => d.Mailtrip)
                    .WithMany(p => p.MailtripPostBagEmpty)
                    .HasForeignKey(d => d.MailtripID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripPostBagEmpty_Mailtrip");

                entity.HasOne(d => d.PostBagTypeCodeNavigation)
                    .WithMany(p => p.MailtripPostBagEmpty)
                    .HasForeignKey(d => d.PostBagTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripPostBagEmpty_PostBagType");
            });

            modelBuilder.Entity<MailtripTransport>(entity =>
            {
                entity.Property(e => e.MailtripTransportID).ValueGeneratedNever();

                entity.Property(e => e.CommandContent).HasMaxLength(500);

                entity.Property(e => e.CommandDate).HasColumnType("datetime");

                entity.Property(e => e.CommandNumber).HasMaxLength(50);

                entity.Property(e => e.ConfirmUsser).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DestinationCode).HasMaxLength(10);

                entity.Property(e => e.DriverCode).HasMaxLength(50);

                entity.Property(e => e.EcortCode).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.GoingDate).HasColumnType("datetime");

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MailRouteScheduleCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StartingCode).HasMaxLength(10);

                entity.Property(e => e.Status).HasComment("0:Khởi tạo;1:Đã đóng;2:Đang đi;3:Đã hoàn thành");

                entity.Property(e => e.TransportAffairCode).HasMaxLength(50);

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransportDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.TransportCodeNavigation)
                    .WithMany(p => p.MailtripTransport)
                    .HasForeignKey(d => d.TransportCode)
                    .HasConstraintName("FK_MailtripTransport_Transport");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.MailtripTransport)
                    .HasForeignKey(d => new { d.DriverCode, d.FromPOSCode })
                    .HasConstraintName("FK_MailtripTransport_Driver");

                entity.HasOne(d => d.MailRouteSchedule)
                    .WithMany(p => p.MailtripTransport)
                    .HasForeignKey(d => new { d.MailRouteScheduleCode, d.MailRouteCode, d.FromPOSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransport_MailRouteSchedule");
            });

            modelBuilder.Entity<MailtripTransportBC37>(entity =>
            {
                entity.HasKey(e => new { e.BC37ID, e.MailtripTransportID })
                    .HasName("PK_MailtripTransportBC37_1");

                entity.Property(e => e.BC37Date).HasMaxLength(8);

                entity.Property(e => e.BC37FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.BC37ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailtripTransportFromPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransportCode).HasMaxLength(10);

                entity.Property(e => e.TransportDate).HasMaxLength(8);

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);

                entity.HasOne(d => d.BC37)
                    .WithMany(p => p.MailtripTransportBC37)
                    .HasForeignKey(d => d.BC37ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransportBC37_BC37");

                entity.HasOne(d => d.MailtripTransport)
                    .WithMany(p => p.MailtripTransportBC37)
                    .HasForeignKey(d => d.MailtripTransportID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransportBC37_MailtripTransport");
            });

            modelBuilder.Entity<MailtripTransportPostBag>(entity =>
            {
                entity.HasKey(e => new { e.PostbagID, e.BC37ID })
                    .HasName("PK_MailtripTransportPostBag_1");

                entity.Property(e => e.BC37Date).HasMaxLength(8);

                entity.Property(e => e.BC37FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.BC37ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber).HasMaxLength(4);

                entity.Property(e => e.MailtripType).HasMaxLength(1);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.Status).HasComment("0:Khởi tạo;1;Đã đóng CX;2:Đã đi khỏi BC;3:Đã xác nhận đến BC;");

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);

                entity.Property(e => e.Year).HasMaxLength(8);

                entity.HasOne(d => d.BC37)
                    .WithMany(p => p.MailtripTransportPostBag)
                    .HasForeignKey(d => d.BC37ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransportPostBag_BC37");

                entity.HasOne(d => d.Postbag)
                    .WithMany(p => p.MailtripTransportPostBag)
                    .HasForeignKey(d => d.PostbagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransportPostBag_PostBag");
            });

            modelBuilder.Entity<MailtripTransportPostBagLog>(entity =>
            {
                entity.HasKey(e => e.MailtripTransportPostBagLogCode);

                entity.Property(e => e.MailtripTransportPostBagLogCode).HasMaxLength(12);

                entity.Property(e => e.BC37Date)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.BC37FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.BC37ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LogContent).HasMaxLength(500);

                entity.Property(e => e.LogCreator).HasMaxLength(100);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailtripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<MailtripTransportPostBag_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BC37Date).HasMaxLength(8);

                entity.Property(e => e.BC37FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.BC37ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.ConfirmDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPOSCode).HasMaxLength(50);

                entity.Property(e => e.ConfirmUser).HasMaxLength(50);

                entity.Property(e => e.CreatePOSCode).HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode).HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber).HasMaxLength(4);

                entity.Property(e => e.MailtripType).HasMaxLength(1);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);

                entity.Property(e => e.Year).HasMaxLength(8);
            });

            modelBuilder.Entity<MailtripTransportTrace>(entity =>
            {
                entity.HasKey(e => e.MailtripTransportTraceIndex)
                    .HasName("PK_MailtripTransportTrace_1");

                entity.Property(e => e.MailtripTransportTraceIndex).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TraceDate).HasColumnType("datetime");

                entity.Property(e => e.TraceDescription)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransportDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.MailtripTransport)
                    .WithMany(p => p.MailtripTransportTrace)
                    .HasForeignKey(d => d.MailtripTransportID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MailtripTransportTrace_MailtripTransport1");
            });

            modelBuilder.Entity<MailtripType>(entity =>
            {
                entity.HasKey(e => e.MailtripTypeCode);

                entity.Property(e => e.MailtripTypeCode).ValueGeneratedNever();

                entity.Property(e => e.MailtripTypeName).HasMaxLength(50);

                entity.Property(e => e.ShortName).HasMaxLength(10);
            });

            modelBuilder.Entity<Mailtrip_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AirCode).HasMaxLength(50);

                entity.Property(e => e.AirportGoCode).HasMaxLength(20);

                entity.Property(e => e.AirportToCode).HasMaxLength(20);

                entity.Property(e => e.BC37Number).HasMaxLength(4);

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryRoute).HasMaxLength(10);

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.IncomingDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachineName).HasMaxLength(50);

                entity.Property(e => e.InitialTime).HasColumnType("datetime");

                entity.Property(e => e.InitialUser).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailRouteCode).HasMaxLength(10);

                entity.Property(e => e.MailtripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailtripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.OpeningMachineName).HasMaxLength(50);

                entity.Property(e => e.OpeningTime).HasColumnType("datetime");

                entity.Property(e => e.OpeningUser).HasMaxLength(50);

                entity.Property(e => e.OriginalTransportPOSCode).HasMaxLength(6);

                entity.Property(e => e.OutgoingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingMachineName).HasMaxLength(50);

                entity.Property(e => e.PackagingTime).HasMaxLength(50);

                entity.Property(e => e.PackagingUser).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferID).HasMaxLength(50);

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.TransportCode).HasMaxLength(10);

                entity.Property(e => e.TransportDate).HasMaxLength(8);

                entity.Property(e => e.TransportNumber).HasMaxLength(3);

                entity.Property(e => e.TrasferTime).HasColumnType("datetime");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuCode);

                entity.Property(e => e.MenuCode).HasMaxLength(10);

                entity.Property(e => e.DllName).HasMaxLength(200);

                entity.Property(e => e.FormName).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.MenuName).HasMaxLength(200);

                entity.Property(e => e.NameSpace).HasMaxLength(200);

                entity.Property(e => e.ParentMenuCode).HasMaxLength(10);

                entity.Property(e => e.Script).HasColumnType("ntext");

                entity.Property(e => e.ShortcutKey).HasMaxLength(2);

                entity.HasOne(d => d.ParentMenuCodeNavigation)
                    .WithMany(p => p.InverseParentMenuCodeNavigation)
                    .HasForeignKey(d => d.ParentMenuCode)
                    .HasConstraintName("FK_Menu_Menu");
            });

            modelBuilder.Entity<MenuParameter>(entity =>
            {
                entity.HasKey(e => e.ParameterCode);

                entity.Property(e => e.ParameterCode).HasMaxLength(10);

                entity.Property(e => e.MenuCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParameterValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MenuCodeNavigation)
                    .WithMany(p => p.MenuParameter)
                    .HasForeignKey(d => d.MenuCode)
                    .HasConstraintName("FK_MenuParameter_Menu");
            });

            modelBuilder.Entity<MenuService>(entity =>
            {
                entity.HasKey(e => new { e.MenuCode, e.ServiceCode });

                entity.Property(e => e.MenuCode).HasMaxLength(10);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.MenuCodeNavigation)
                    .WithMany(p => p.MenuService)
                    .HasForeignKey(d => d.MenuCode)
                    .HasConstraintName("FK_MenuService_Menu");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.MenuService)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_MenuService_Service");
            });

            modelBuilder.Entity<MenuVersion>(entity =>
            {
                entity.HasKey(e => new { e.MenuCode, e.VersionCode });

                entity.Property(e => e.MenuCode).HasMaxLength(10);

                entity.Property(e => e.VersionCode).HasMaxLength(10);

                entity.HasOne(d => d.MenuCodeNavigation)
                    .WithMany(p => p.MenuVersion)
                    .HasForeignKey(d => d.MenuCode)
                    .HasConstraintName("FK_MenuVersion_Menu");

                entity.HasOne(d => d.VersionCodeNavigation)
                    .WithMany(p => p.MenuVersion)
                    .HasForeignKey(d => d.VersionCode)
                    .HasConstraintName("FK_MenuVersion_Version");
            });

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.HasKey(e => e.MessageTypeName)
                    .HasName("PK_MessageType_1");

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<MessageTypeLastCall>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.MessageTypeName })
                    .HasName("PK_DomesticFreightRuleLastCall");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.MessageTypeName).HasMaxLength(50);

                entity.Property(e => e.LastCall).HasColumnType("datetime");
            });

            modelBuilder.Entity<MessageTypeTable>(entity =>
            {
                entity.HasKey(e => new { e.MessageTypeName, e.TableName });

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.ClientUpdateSql).HasMaxLength(100);

                entity.HasOne(d => d.GetType)
                    .WithMany(p => p.MessageTypeTable)
                    .HasForeignKey(d => d.GetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTypeTable_GetType");

                entity.HasOne(d => d.MessageTypeNameNavigation)
                    .WithMany(p => p.MessageTypeTable)
                    .HasForeignKey(d => d.MessageTypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTypeTable_MessageType");

                entity.HasOne(d => d.StoreBehavior)
                    .WithMany(p => p.MessageTypeTable)
                    .HasForeignKey(d => d.StoreBehaviorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTypeTable_StoreBehavior");

                entity.HasOne(d => d.StoreType)
                    .WithMany(p => p.MessageTypeTable)
                    .HasForeignKey(d => d.StoreTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTypeTable_StoreType");

                entity.HasOne(d => d.TableNameNavigation)
                    .WithMany(p => p.MessageTypeTable)
                    .HasForeignKey(d => d.TableName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTypeTable_Table");
            });

            modelBuilder.Entity<Mobile_View_DuongThu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Mobile_View_DuongThu");

                entity.Property(e => e.DeliveryRouteCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryRouteName).HasMaxLength(500);

                entity.Property(e => e.MailtripDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<MoneyOrderRule>(entity =>
            {
                entity.HasKey(e => new { e.MoneyOrderRuleCode, e.DomesticFreightRuleCode, e.ItemTypeCode, e.ServiceCode });

                entity.Property(e => e.MoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(2);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNo).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MoneyOrderStep>(entity =>
            {
                entity.HasKey(e => new { e.MoneyOrderRuleCode, e.MoneyOrderStepCode, e.DomesticFreightRuleCode, e.ItemTypeCode, e.ServiceCode });

                entity.Property(e => e.MoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.MoneyOrderStepCode).HasMaxLength(10);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(2);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CalculationMethod).HasComment(@"0: Tính theo nấc khối lượng
1: Tính theo bước cước");

                entity.HasOne(d => d.MoneyOrderRule)
                    .WithMany(p => p.MoneyOrderStep)
                    .HasForeignKey(d => new { d.MoneyOrderRuleCode, d.DomesticFreightRuleCode, d.ItemTypeCode, d.ServiceCode })
                    .HasConstraintName("FK_MoneyOrderStep_MoneyOrderRule");
            });

            modelBuilder.Entity<MoneyOrderValueAddedService>(entity =>
            {
                entity.HasKey(e => new { e.ValueAddedServiceCode, e.MoneyOrderRuleCode, e.DomesticFreightRuleCode, e.ItemTypeCode, e.ServiceCode });

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.MoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(2);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CalculationMethod).HasComment(@"0: Tính theo nấc khối lượng
1: Tính theo bước cước");

                entity.HasOne(d => d.ValueAddedServiceCodeNavigation)
                    .WithMany(p => p.MoneyOrderValueAddedService)
                    .HasForeignKey(d => d.ValueAddedServiceCode)
                    .HasConstraintName("FK_MoneyOrderValueAddedService_ValueAddedService");

                entity.HasOne(d => d.MoneyOrderRule)
                    .WithMany(p => p.MoneyOrderValueAddedService)
                    .HasForeignKey(d => new { d.MoneyOrderRuleCode, d.DomesticFreightRuleCode, d.ItemTypeCode, d.ServiceCode })
                    .HasConstraintName("FK_MoneyOrderValueAddedService_MoneyOrderRule");
            });

            modelBuilder.Entity<MoneyOrderValueAddedServiceSingeItem>(entity =>
            {
                entity.HasKey(e => new { e.ValueAddedServiceCode, e.MoneyOrderRuleCode, e.MoneyOrderValueAddedServiceSingeItemCode, e.DomesticFreightRuleCode, e.ItemTypeCode, e.ServiceCode });

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.MoneyOrderRuleCode).HasMaxLength(10);

                entity.Property(e => e.MoneyOrderValueAddedServiceSingeItemCode).HasMaxLength(10);

                entity.Property(e => e.DomesticFreightRuleCode).HasMaxLength(10);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(2);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.MoneyOrderValueAddedService)
                    .WithMany(p => p.MoneyOrderValueAddedServiceSingeItem)
                    .HasForeignKey(d => new { d.ValueAddedServiceCode, d.MoneyOrderRuleCode, d.DomesticFreightRuleCode, d.ItemTypeCode, d.ServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoneyOrderValueAddedServiceSingeItem_MoneyOrderValueAddedService");
            });

            modelBuilder.Entity<NearProvince>(entity =>
            {
                entity.HasKey(e => new { e.ProvinceCode, e.RegionCode });

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.RegionCode).HasMaxLength(2);

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.NearProvince)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NearProvince_Province");

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.NearProvince)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NearProvince_Region");
            });

            modelBuilder.Entity<NearRegion>(entity =>
            {
                entity.HasKey(e => new { e.OriginalRegionCode, e.NearRegionCode });

                entity.Property(e => e.OriginalRegionCode).HasMaxLength(2);

                entity.Property(e => e.NearRegionCode).HasMaxLength(2);

                entity.HasOne(d => d.NearRegionCodeNavigation)
                    .WithMany(p => p.NearRegionNearRegionCodeNavigation)
                    .HasForeignKey(d => d.NearRegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NearRegion_Region1");

                entity.HasOne(d => d.OriginalRegionCodeNavigation)
                    .WithMany(p => p.NearRegionOriginalRegionCodeNavigation)
                    .HasForeignKey(d => d.OriginalRegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NearRegion_Region");
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.HasKey(e => e.NodeName);

                entity.Property(e => e.NodeName).HasMaxLength(50);

                entity.Property(e => e.DnsIdentity).HasMaxLength(50);

                entity.Property(e => e.HttpAddress).HasMaxLength(50);

                entity.Property(e => e.HttpsAddress).HasMaxLength(50);

                entity.Property(e => e.IPAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MsmqAddress).HasMaxLength(50);

                entity.Property(e => e.NetTcpAddress).HasMaxLength(50);

                entity.Property(e => e.QueueName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeToNode>(entity =>
            {
                entity.HasKey(e => new { e.FromNodeName, e.ToNodeName });

                entity.Property(e => e.FromNodeName).HasMaxLength(50);

                entity.Property(e => e.ToNodeName).HasMaxLength(50);

                entity.HasOne(d => d.FromNodeNameNavigation)
                    .WithMany(p => p.NodeToNodeFromNodeNameNavigation)
                    .HasForeignKey(d => d.FromNodeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NodeToNode_Node");

                entity.HasOne(d => d.ToNodeNameNavigation)
                    .WithMany(p => p.NodeToNodeToNodeNameNavigation)
                    .HasForeignKey(d => d.ToNodeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NodeToNode_Node1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.IsSentAll).HasDefaultValueSql("((0))");

                entity.Property(e => e.PosCode).HasMaxLength(6);

                entity.Property(e => e.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<Notification_User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Notification_User)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Notificat__Notif__4479F190");
            });

            modelBuilder.Entity<OE>(entity =>
            {
                entity.HasKey(e => e.OECode);

                entity.Property(e => e.OECode).HasMaxLength(6);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.OEName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.OE)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK_OE_Country");
            });

            modelBuilder.Entity<ObjectReceiver>(entity =>
            {
                entity.HasKey(e => e.ReceiverObjectID);

                entity.Property(e => e.ReceiverObjectID).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.DeliveryPointCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.ReceiverObjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Tel).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.DeliveryPoint)
                    .WithMany(p => p.ObjectReceiver)
                    .HasForeignKey(d => new { d.DeliveryPointCode, d.CustomerCode })
                    .HasConstraintName("FK_ObjectReceiver_DeliveryPoint");
            });

            modelBuilder.Entity<ObjectRef>(entity =>
            {
                entity.Property(e => e.ObjectRefId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Link).HasMaxLength(500);

                entity.Property(e => e.ObjectRefName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ObjectType).HasMaxLength(200);
            });

            modelBuilder.Entity<ObjectSender>(entity =>
            {
                entity.HasKey(e => e.SenderObjectID);

                entity.Property(e => e.SenderObjectID).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.SenderObjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Tel).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.ObjectSender)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_ObjectSender_Customer");
            });

            modelBuilder.Entity<OfflinePOS>(entity =>
            {
                entity.HasKey(e => new { e.OfflinePOSCode, e.OnlinePOSCode });

                entity.Property(e => e.OfflinePOSCode).HasMaxLength(6);

                entity.Property(e => e.OnlinePOSCode).HasMaxLength(6);

                entity.HasOne(d => d.OfflinePOSCodeNavigation)
                    .WithMany(p => p.OfflinePOSOfflinePOSCodeNavigation)
                    .HasForeignKey(d => d.OfflinePOSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfflinePOS_POS1");

                entity.HasOne(d => d.OnlinePOSCodeNavigation)
                    .WithMany(p => p.OfflinePOSOnlinePOSCodeNavigation)
                    .HasForeignKey(d => d.OnlinePOSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfflinePOS_POS");
            });

            modelBuilder.Entity<OnlineBatch>(entity =>
            {
                entity.HasKey(e => new { e.BatchCode, e.CustomerCode, e.OrderCode });

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.HasOne(d => d.OnlineOrder)
                    .WithMany(p => p.OnlineBatch)
                    .HasForeignKey(d => new { d.OrderCode, d.CustomerCode })
                    .HasConstraintName("FK_OnlineBatch_OnlineOrder");
            });

            modelBuilder.Entity<OnlineItem>(entity =>
            {
                entity.HasKey(e => e.ItemIndex);

                entity.Property(e => e.ItemIndex).ValueGeneratedNever();

                entity.Property(e => e.AddressCode).HasMaxLength(6);

                entity.Property(e => e.BatchCode).HasMaxLength(13);

                entity.Property(e => e.CertificateNumber).HasMaxLength(50);

                entity.Property(e => e.CheckSum).HasMaxLength(1);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.DataCode).HasMaxLength(50);

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.ExchangeRateCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.ItemNumber).HasMaxLength(50);

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.MachineName).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomReference).HasMaxLength(500);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReceiverIdentification).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueCountry).HasMaxLength(50);

                entity.Property(e => e.ReceiverIssueDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverJob).HasMaxLength(500);

                entity.Property(e => e.ReceiverMobile).HasMaxLength(15);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.SectionCode).HasMaxLength(3);

                entity.Property(e => e.SenderAddress).HasMaxLength(50);

                entity.Property(e => e.SenderCustomReference).HasMaxLength(500);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SenderIdentification).HasMaxLength(50);

                entity.Property(e => e.SenderIssueCountry).HasMaxLength(50);

                entity.Property(e => e.SenderIssueDate).HasColumnType("datetime");

                entity.Property(e => e.SenderJob).HasMaxLength(500);

                entity.Property(e => e.SenderMobile).HasMaxLength(15);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<OnlineOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.CustomerCode });

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.OnlineOrder)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_OnlineOrder_Customer");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.POSCode, e.CustomerCode });

                entity.Property(e => e.OrderCode).HasMaxLength(5);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<POS>(entity =>
            {
                entity.HasKey(e => e.POSCode);

                entity.HasIndex(e => new { e.POSCode, e.ProvinceCode })
                    .HasName("PK_PosCode")
                    .IsUnique();

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AddressCode).HasMaxLength(50);

                entity.Property(e => e.CommuneCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DatabasePassword).HasMaxLength(255);

                entity.Property(e => e.DatabaseServer).HasMaxLength(50);

                entity.Property(e => e.DatabaseUsername).HasMaxLength(255);

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IP).HasMaxLength(50);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.POSLevelCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.POSName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.POSNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([POSName])),(0)))");

                entity.Property(e => e.POSTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ServiceServer).HasMaxLength(50);

                entity.Property(e => e.Stamp).HasMaxLength(500);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UnitCode).HasMaxLength(6);
            });

            modelBuilder.Entity<POSConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.ConfigCode });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ConfigCode).HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(50);

                entity.HasOne(d => d.ConfigCodeNavigation)
                    .WithMany(p => p.POSConfiguration)
                    .HasForeignKey(d => d.ConfigCode)
                    .HasConstraintName("FK_POSConfiguration_Configuration");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.POSConfiguration)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_POSConfiguration_POS");
            });

            modelBuilder.Entity<POSFreightRegion>(entity =>
            {
                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.FreightRegion)
                    .WithMany(p => p.POSFreightRegion)
                    .HasForeignKey(d => d.FreightRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSFreightRegion_FreightRegion");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.POSFreightRegion)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSFreightRegion_POS");
            });

            modelBuilder.Entity<POSInternal>(entity =>
            {
                entity.HasKey(e => e.POSCode);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Parent).HasMaxLength(6);

                entity.Property(e => e.ParentTag).HasMaxLength(300);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithOne(p => p.POSInternal)
                    .HasForeignKey<POSInternal>(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSInternal_POS");
            });

            modelBuilder.Entity<POSInternalFull>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IsPos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Parent).HasMaxLength(6);

                entity.Property(e => e.ParentTag).HasMaxLength(300);

                entity.Property(e => e.PosName).HasMaxLength(200);
            });

            modelBuilder.Entity<POSLevel>(entity =>
            {
                entity.HasKey(e => e.POSLevelCode);

                entity.Property(e => e.POSLevelCode).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.POSLevelName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<POSLevel_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.POSLevelCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.POSLevelName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<POSService>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.ServiceCode });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.POSService)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_POSService_POS");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.POSService)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_POSService_Service");
            });

            modelBuilder.Entity<POSService_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<POSType>(entity =>
            {
                entity.HasKey(e => e.POSTypeCode);

                entity.HasIndex(e => e.POSTypeNameSearch)
                    .HasName("ix_regiongroup_name_search");

                entity.Property(e => e.POSTypeCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.POSTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.POSTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([POSTypeName])),0))");
            });

            modelBuilder.Entity<POSType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.POSTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.POSTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<POSVersion>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.MachineName })
                    .HasName("PK_POSVersion_1");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.MachineName).HasMaxLength(150);

                entity.Property(e => e.BCCPDBVersion).HasMaxLength(50);

                entity.Property(e => e.BCCPVersion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WindowsVersion).HasMaxLength(150);
            });

            modelBuilder.Entity<POS_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AddressCode).HasMaxLength(50);

                entity.Property(e => e.CommuneCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DatabasePassword).HasMaxLength(255);

                entity.Property(e => e.DatabaseServer).HasMaxLength(50);

                entity.Property(e => e.DatabaseUsername).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IP).HasMaxLength(50);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.POSLevelCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.POSName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.POSTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ServiceServer).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UnitCode).HasMaxLength(6);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNumber, e.CustomerCode, e.POSCode });

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.InputUser).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_Payment_Customer1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PermissionAndGroupPermission>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.Property(e => e.PerId).ValueGeneratedNever();

                entity.HasOne(d => d.PermissionGroup)
                    .WithMany(p => p.PermissionAndGroupPermission)
                    .HasForeignKey(d => d.PermissionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionAndGroupPermission_PermissionGroup");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionAndGroupPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionAndGroupPermission_Permission");
            });

            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.Property(e => e.PermissionGroupId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PermissionGroupName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Permission_GroupReport_ShiftReport>(entity =>
            {
                entity.HasKey(e => new { e.ReportID, e.GroupCode });

                entity.Property(e => e.ReportID)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.GroupCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Permission_Report_ShiftReport>(entity =>
            {
                entity.HasKey(e => e.ReportID)
                    .HasName("PK_Permission_ShiftReport");

                entity.Property(e => e.ReportID)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDes).HasMaxLength(200);

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PetrolFreightSurchargeRule>(entity =>
            {
                entity.HasKey(e => new { e.PetrolFreightSurchargeRuleCode, e.ServiceCode })
                    .HasName("PK_PetrolFreightSurchargeRule_1");

                entity.Property(e => e.PetrolFreightSurchargeRuleCode).HasMaxLength(5);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNo).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Phase>(entity =>
            {
                entity.HasKey(e => e.PhaseCode);

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ParentPhaseCode).HasMaxLength(3);

                entity.Property(e => e.PhaseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ParentPhaseCodeNavigation)
                    .WithMany(p => p.InverseParentPhaseCodeNavigation)
                    .HasForeignKey(d => d.ParentPhaseCode)
                    .HasConstraintName("FK_Phase_Phase");
            });

            modelBuilder.Entity<PhaseQualityTarget>(entity =>
            {
                entity.HasKey(e => new { e.PhaseCode, e.ServiceCode, e.RegionTypeCode, e.QualityTargetRuleCode });

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RegionTypeCode).HasMaxLength(1);

                entity.Property(e => e.QualityTargetRuleCode).HasMaxLength(5);

                entity.HasOne(d => d.RegionTypeCodeNavigation)
                    .WithMany(p => p.PhaseQualityTarget)
                    .HasForeignKey(d => d.RegionTypeCode)
                    .HasConstraintName("FK_PhaseQualityTarget_RegionType");

                entity.HasOne(d => d.ServicePhase)
                    .WithMany(p => p.PhaseQualityTarget)
                    .HasForeignKey(d => new { d.PhaseCode, d.ServiceCode })
                    .HasConstraintName("FK_PhaseQualityTarget_ServicePhase");

                entity.HasOne(d => d.QualityTargetRule)
                    .WithMany(p => p.PhaseQualityTarget)
                    .HasForeignKey(d => new { d.QualityTargetRuleCode, d.ServiceCode })
                    .HasConstraintName("FK_PhaseQualityTarget_QualityTargetRule");
            });

            modelBuilder.Entity<PostBag>(entity =>
            {
                entity.HasComment("Túi thư");

                entity.HasIndex(e => e.MailtripID)
                    .HasName("idx_PostBag_MailtripID");

                entity.Property(e => e.PostBagID)
                    .HasComment("ID túi thư")
                    .ValueGeneratedNever();

                entity.Property(e => e.CaseWeight).HasComment("Khối lượng vỏ túi");

                entity.Property(e => e.ConvertWeight).HasComment("Khối lượng quy đổi");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.CreatedMachine)
                    .HasMaxLength(50)
                    .HasComment("Máy tính thực hiện");

                entity.Property(e => e.F).HasComment("Túi F");

                entity.Property(e => e.IdentityNumber).HasMaxLength(50);

                entity.Property(e => e.MailtripID).HasComment("ID chuyến thư");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú");

                entity.Property(e => e.OpeningBy)
                    .HasMaxLength(50)
                    .HasComment("Người mở");

                entity.Property(e => e.OpeningDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày mở");

                entity.Property(e => e.OpeningMachine)
                    .HasMaxLength(50)
                    .HasComment("Tên máy tính mở");

                entity.Property(e => e.PackagingBy)
                    .HasMaxLength(50)
                    .HasComment("Người đóng");

                entity.Property(e => e.PackagingDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày đóng");

                entity.Property(e => e.PackagingMachine)
                    .HasMaxLength(50)
                    .HasComment("Tên máy tính đóng");

                entity.Property(e => e.PostBagCode)
                    .HasMaxLength(50)
                    .HasComment("Số hiệu túi");

                entity.Property(e => e.PostBagIndex).HasComment("Thứ tự túi trong chuyến thư");

                entity.Property(e => e.PostBagNumber)
                    .HasMaxLength(3)
                    .HasComment("Túi số");

                entity.Property(e => e.PostBagTypeCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("Mã túi");

                entity.Property(e => e.Quantity).HasComment("Số lượng");

                entity.Property(e => e.SealNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.Weight).HasComment("Khối lượng túi");

                entity.HasOne(d => d.Mailtrip)
                    .WithMany(p => p.PostBag)
                    .HasForeignKey(d => d.MailtripID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBag_Mailtrip");

                entity.HasOne(d => d.PostBagTypeCodeNavigation)
                    .WithMany(p => p.PostBag)
                    .HasForeignKey(d => d.PostBagTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBag_PostBagType");
            });

            modelBuilder.Entity<PostBagEmpty>(entity =>
            {
                entity.Property(e => e.PostBagEmptyID)
                    .HasComment("ID túi rỗng")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasComment("Số lượng");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục");

                entity.Property(e => e.PostBagEmptyType).HasComment("Hình thức xuất nhập túi rỗng 0- Nhập; 1 - Hủy");

                entity.Property(e => e.PostBagTypeCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("Loại túi");

                entity.Property(e => e.ReturnPOSCode).HasMaxLength(6);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.PostBagEmpty)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBagEmpty_POS");

                entity.HasOne(d => d.PostBagTypeCodeNavigation)
                    .WithMany(p => p.PostBagEmpty)
                    .HasForeignKey(d => d.PostBagTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBagEmpty_PostBagType");
            });

            modelBuilder.Entity<PostBagEmptyInventory>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.PostBagTypeCode });

                entity.Property(e => e.PostBagTypeCode).HasMaxLength(2);

                entity.HasOne(d => d.PostBagTypeCodeNavigation)
                    .WithMany(p => p.PostBagEmptyInventory)
                    .HasForeignKey(d => d.PostBagTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBagEmptyInventory_PostBagType");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.PostBagEmptyInventory)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBagEmptyInventory_ShiftHandover");
            });

            modelBuilder.Entity<PostBagLog>(entity =>
            {
                entity.Property(e => e.PostbagLogID).ValueGeneratedNever();

                entity.Property(e => e.BC37Date).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser).HasMaxLength(50);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.IncomingDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.LogContent).HasMaxLength(500);

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.OpeningTime).HasColumnType("datetime");

                entity.Property(e => e.OpeningUser).HasMaxLength(50);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingTime).HasColumnType("datetime");

                entity.Property(e => e.PackagingUser).HasMaxLength(50);

                entity.Property(e => e.PostBagCode).HasMaxLength(50);

                entity.Property(e => e.PostBagLogCode)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.PostBagNumber).HasMaxLength(3);

                entity.Property(e => e.PostBagTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.Postbag)
                    .WithMany(p => p.PostBagLog)
                    .HasForeignKey(d => d.PostbagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostBagLog_PostBag1");
            });

            modelBuilder.Entity<PostBagType>(entity =>
            {
                entity.HasKey(e => e.PostBagTypeCode);

                entity.HasComment("Danh mục túi thư");

                entity.HasIndex(e => e.PostBagTypeNameSearch)
                    .HasName("ix_postbagtype_name_search");

                entity.Property(e => e.PostBagTypeCode)
                    .HasMaxLength(2)
                    .HasComment("Mã túi thư");

                entity.Property(e => e.CaseWeight).HasComment("Khối lượng vỏ túi");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasComment("Mô tả");

                entity.Property(e => e.IsPostBag).HasComment("True là túi,  False là gói");

                entity.Property(e => e.MaximumWeight).HasComment("Khối lượng túi đa");

                entity.Property(e => e.OrderIndex).HasComment("Thứ tự");

                entity.Property(e => e.PostBagTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Tên túi thư");

                entity.Property(e => e.PostBagTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([PostBagTypeName])),0))");

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(2)
                    .HasComment("Dịch vụ");

                entity.Property(e => e.Type).HasComment("loại túi/goi : 0 là loại thường,1 là loại giao rời, 2 là loại đi ngoài");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.PostBagType)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_PostBagType_Service");
            });

            modelBuilder.Entity<Postbag_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BC37Date).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.IncomingDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.OpeningTime).HasColumnType("datetime");

                entity.Property(e => e.OpeningUser).HasMaxLength(50);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingTime).HasColumnType("datetime");

                entity.Property(e => e.PackagingUser).HasMaxLength(50);

                entity.Property(e => e.PostBagCode).HasMaxLength(50);

                entity.Property(e => e.PostBagNumber).HasMaxLength(3);

                entity.Property(e => e.PostBagTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<PrintedMatter>(entity =>
            {
                entity.HasKey(e => e.PrintedMatterCode);

                entity.Property(e => e.PrintedMatterCode).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PrintedMatterName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PrintedMatterMachine>(entity =>
            {
                entity.HasKey(e => new { e.PrintedMatterCode, e.POSCode });

                entity.Property(e => e.PrintedMatterCode).HasMaxLength(255);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PrinterName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.PrintedMatterCodeNavigation)
                    .WithMany(p => p.PrintedMatterMachine)
                    .HasForeignKey(d => d.PrintedMatterCode)
                    .HasConstraintName("FK_PrintedMatterMachine_PrintedMatter");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.PropertyCode);

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.Property(e => e.Control)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ControlValue).HasMaxLength(500);

                entity.Property(e => e.DataType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupPropertyCode).HasMaxLength(50);

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.GroupPropertyCodeNavigation)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.GroupPropertyCode)
                    .HasConstraintName("FK_Property_GroupProperty");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceCode)
                    .HasName("PK_ProvinceCode");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProvinceCombobox)
                    .IsRequired()
                    .HasMaxLength(106)
                    .HasComputedColumnSql("(([ProvinceCode]+' - ')+[ProvinceName])");

                entity.Property(e => e.ProvinceListCode).HasMaxLength(100);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([ProvinceName])),(0)))");

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_Region");
            });

            modelBuilder.Entity<ProvinceFreightRegion>(entity =>
            {
                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.FreightRegion)
                    .WithMany(p => p.ProvinceFreightRegion)
                    .HasForeignKey(d => d.FreightRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvinceFreightRegion_FreightRegion");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.ProvinceFreightRegion)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvinceFreightRegion_Province");
            });

            modelBuilder.Entity<ProvinceInterconnect>(entity =>
            {
                entity.HasIndex(e => new { e.ServiceCode, e.DomesticFreightRuleId, e.FromProvinceCode, e.ToProvinceCode })
                    .HasName("IX_ProvinceInterconnect");

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FromProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.DomesticFreightBlock)
                    .WithMany(p => p.ProvinceInterconnect)
                    .HasForeignKey(d => d.DomesticFreightBlockId)
                    .HasConstraintName("FK_ProvinceInterconnect_DomesticFreightBlock");

                entity.HasOne(d => d.FromProvinceCodeNavigation)
                    .WithMany(p => p.ProvinceInterconnectFromProvinceCodeNavigation)
                    .HasForeignKey(d => d.FromProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvinceInterconnect_Province");

                entity.HasOne(d => d.ToProvinceCodeNavigation)
                    .WithMany(p => p.ProvinceInterconnectToProvinceCodeNavigation)
                    .HasForeignKey(d => d.ToProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvinceInterconnect_Province1");
            });

            modelBuilder.Entity<Province_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ProvinceListCode).HasMaxLength(100);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<QualityTargetRule>(entity =>
            {
                entity.HasKey(e => new { e.QualityTargetRuleCode, e.ServiceCode });

                entity.Property(e => e.QualityTargetRuleCode).HasMaxLength(5);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNo).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.QualityTargetRule)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_QualityTargetRule_Service");
            });

            modelBuilder.Entity<RP_CustomerAcceptanceReports>(entity =>
            {
                entity.HasKey(e => new { e.InsertedDate, e.POSCode, e.ShiftCode, e.ReportTargetCode, e.CustomerCode, e.TargetIndex });

                entity.Property(e => e.InsertedDate).HasMaxLength(8);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ShiftCode).HasMaxLength(6);

                entity.Property(e => e.ReportTargetCode).HasMaxLength(15);

                entity.Property(e => e.CustomerCode).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Machinename)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Range>(entity =>
            {
                entity.HasKey(e => e.RangeCode);

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.RangeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RangeCause>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.CauseCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.CauseCode).HasMaxLength(2);

                entity.HasOne(d => d.CauseCodeNavigation)
                    .WithMany(p => p.RangeCauseNavigation)
                    .HasForeignKey(d => d.CauseCode)
                    .HasConstraintName("FK_RangeCause_Cause");

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeCause)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeCause_Range");
            });

            modelBuilder.Entity<RangeCommodityType>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.CommodityTypeCode, e.ServiceCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.CommodityTypeCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeCommodityType)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeCommodityType_Range");

                entity.HasOne(d => d.ServiceCommodityType)
                    .WithMany(p => p.RangeCommodityType)
                    .HasForeignKey(d => new { d.ServiceCode, d.CommodityTypeCode })
                    .HasConstraintName("FK_RangeCommodityType_ServiceCommodityType");
            });

            modelBuilder.Entity<RangeServiceItemType>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.ServiceCode, e.ItemTypeCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeServiceItemType)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeServiceItemType_Range");

                entity.HasOne(d => d.ServiceItemType)
                    .WithMany(p => p.RangeServiceItemType)
                    .HasForeignKey(d => new { d.ServiceCode, d.ItemTypeCode })
                    .HasConstraintName("FK_RangeServiceItemType_ServiceItemType");
            });

            modelBuilder.Entity<RangeSolution>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.SolutionCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeSolution)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeSolution_Range");

                entity.HasOne(d => d.SolutionCodeNavigation)
                    .WithMany(p => p.RangeSolution)
                    .HasForeignKey(d => d.SolutionCode)
                    .HasConstraintName("FK_RangeSolution_Solution");
            });

            modelBuilder.Entity<RangeUndeliveryGuide>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.UndeliveryGuideCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeUndeliveryGuide)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeUndeliveryGuide_Range");

                entity.HasOne(d => d.UndeliveryGuideCodeNavigation)
                    .WithMany(p => p.RangeUndeliveryGuide)
                    .HasForeignKey(d => d.UndeliveryGuideCode)
                    .HasConstraintName("FK_RangeUndeliveryGuide_UndeliveryGuide");
            });

            modelBuilder.Entity<RangeValueAddedServicePhase>(entity =>
            {
                entity.HasKey(e => new { e.RangeCode, e.ServiceCode, e.ValueAddedServiceCode, e.PhaseCode });

                entity.Property(e => e.RangeCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.HasOne(d => d.RangeCodeNavigation)
                    .WithMany(p => p.RangeValueAddedServicePhase)
                    .HasForeignKey(d => d.RangeCode)
                    .HasConstraintName("FK_RangeValueAddedServicePhase_Range");

                entity.HasOne(d => d.ValueAddedServicePhase)
                    .WithMany(p => p.RangeValueAddedServicePhase)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode, d.PhaseCode })
                    .HasConstraintName("FK_RangeValueAddedServicePhase_RangeValueAddedServicePhase");
            });

            modelBuilder.Entity<RateUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RateDesc).HasMaxLength(3000);

                entity.Property(e => e.RateMonth)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.RateUser)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RateUser__UserNa__24EC379E");
            });

            modelBuilder.Entity<Receptacles_OETemp>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DATE_DEPARTURE).HasColumnType("smalldatetime");

                entity.Property(e => e.Destination_Impc)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.MAIL_SUB_CLASS_CODE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Mail_Number)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Origin_Impc)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionCode);

                entity.HasIndex(e => e.RegionNameSearch)
                    .HasName("ix_region_name_search");

                entity.Property(e => e.RegionCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegionNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([RegionName])),0))");
            });

            modelBuilder.Entity<RegionGroup>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__RegionGr__A25C5AA661E8DF24");

                entity.HasIndex(e => e.NameSearch)
                    .HasName("ix_regiongroup_name_search");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.ListCommune)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.ListDistrict)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.ListObject)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.ListProvince)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.ListRegion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([Name])),0))");

                entity.Property(e => e.Type).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RegionInterconnect>(entity =>
            {
                entity.HasIndex(e => new { e.ServiceCode, e.DomesticFreightRuleCode, e.FromFreightRegionCode, e.ToFreightRegionCode })
                    .HasName("IX_RegionInterconnect")
                    .IsUnique();

                entity.Property(e => e.DomesticFreightRuleCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FromFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ToFreightRegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.DomesticFreightBlock)
                    .WithMany(p => p.RegionInterconnect)
                    .HasForeignKey(d => d.DomesticFreightBlockId)
                    .HasConstraintName("FK_RegionInterconnect_DomesticFreightBlock");
            });

            modelBuilder.Entity<RegionType>(entity =>
            {
                entity.HasKey(e => e.RegionTypeCode);

                entity.Property(e => e.RegionTypeCode)
                    .HasMaxLength(1)
                    .HasComment(@"0: Nội vùng
1: Cận vùng
2: Cách vùng");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RegionTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Region_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ReportManager>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.FileTemplate).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ParentTag)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("(',')");

                entity.Property(e => e.Type).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ReportManagerDataSet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConnectString).HasMaxLength(50);

                entity.Property(e => e.DataType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Object, Array, Json, String, Int...");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.SourceType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Dữ liệu tĩnh, SQL, API, Hệ thống");

                entity.HasOne(d => d.ReportManager)
                    .WithMany(p => p.ReportManagerDataSet)
                    .HasForeignKey(d => d.ReportManagerId)
                    .HasConstraintName("FK__ReportMan__Repor__1EE87A2E");
            });

            modelBuilder.Entity<ReportManagerGroupBy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.DataSet)
                    .WithMany(p => p.ReportManagerGroupBy)
                    .HasForeignKey(d => d.DataSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportMan__DataS__01230D1D");

                entity.HasOne(d => d.ReportManager)
                    .WithMany(p => p.ReportManagerGroupBy)
                    .HasForeignKey(d => d.ReportManagerId)
                    .HasConstraintName("FK__ReportMan__Repor__002EE8E4");
            });

            modelBuilder.Entity<ReportManagerParam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataFileDefault).HasMaxLength(300);

                entity.Property(e => e.DataType).HasDefaultValueSql("((1))");

                entity.Property(e => e.InputType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.ReportManager)
                    .WithMany(p => p.ReportManagerParam)
                    .HasForeignKey(d => d.ReportManagerId)
                    .HasConstraintName("FK__ReportMan__Repor__155F0FF4");
            });

            modelBuilder.Entity<ReportManagerPrinter>(entity =>
            {
                entity.HasKey(e => e.PrinterID);

                entity.Property(e => e.PrinterID).ValueGeneratedNever();

                entity.Property(e => e.IP)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('[]')");

                entity.Property(e => e.OptionPrint).HasMaxLength(500);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PrinterName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.ReportManagerPrinter)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportManagerPrinter_POS");

                entity.HasOne(d => d.ReportManager)
                    .WithMany(p => p.ReportManagerPrinter)
                    .HasForeignKey(d => d.ReportManagerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportManagerPrinter_ReportManager");
            });

            modelBuilder.Entity<RequestAccepted>(entity =>
            {
                entity.HasKey(e => e.RequestID);

                entity.HasComment("Tiếp nhận yêu cầu");

                entity.Property(e => e.RequestID)
                    .HasComment("Id yêu cầu")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .HasComment("Người duyệt");

                entity.Property(e => e.ApprovedContent)
                    .HasMaxLength(500)
                    .HasComment("Nội dung phê duyệt");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày duyệt");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ItemNumber).HasComment("Số lượng bưu gửi");

                entity.Property(e => e.ItemNumberPostman).HasComment("Số lượng bưu gửi bưu tá nhận");

                entity.Property(e => e.ItemNumberPrioritize).HasComment("Số lượng bưu gửi ưu tiên");

                entity.Property(e => e.ItemNumberPrioritizePostman).HasComment("Số lượng bưu gửi ưu tiên bưu tá nhận");

                entity.Property(e => e.ItemNumberPrioritizeTellers).HasComment("Số lượng bưu gửi ưu tiên gdv nhận");

                entity.Property(e => e.ItemNumberSecret).HasComment("Số lượng bưu gửi đặc biệt");

                entity.Property(e => e.ItemNumberSecretPostman).HasComment("Số lượng bưu gửi đặc biệt bưu tá nhận");

                entity.Property(e => e.ItemNumberSecretTellers).HasComment("Số lượng bưu gửi đặc biệt gdv nhận");

                entity.Property(e => e.ItemNumberTellers).HasComment("Số lượng bưu gửi gdv nhận");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục tiếp nhận");

                entity.Property(e => e.PostmanApprovedBy)
                    .HasMaxLength(50)
                    .HasComment("Bưu tá duyệt");

                entity.Property(e => e.PostmanApprovedContent)
                    .HasMaxLength(500)
                    .HasComment("Nội dung phê duyệt");

                entity.Property(e => e.PostmanApprovedDate)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian bưu tá duyệt");

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerTel).HasMaxLength(15);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.ReceiverPOSCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.RequestAcceptedType).HasComment("Yêu cầu chấp nhận: 0 - Loại thường; 1 - Loại đặc biệt");

                entity.Property(e => e.RequestCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Mã yêu cầu");

                entity.Property(e => e.RequestContent)
                    .HasMaxLength(500)
                    .HasComment("Nội dung yêu cầu");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày gửi yêu cầu");

                entity.Property(e => e.RequestType).HasComment("Loại yêu cầu: 0 - Yêu cầu tại địa chỉ; 1 - Yêu cầu tại quầy; 2 - GDV tiếp nhận; 3 - Bưu tá tiếp nhận, -1 - Tudong");

                entity.Property(e => e.SenderAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ gửi");

                entity.Property(e => e.SenderCommuneCode)
                    .HasMaxLength(6)
                    .HasComment("Địa chỉ gửi: Phường /xã");

                entity.Property(e => e.SenderCustomerCode)
                    .HasMaxLength(50)
                    .HasComment("Mã khách hàng gửi");

                entity.Property(e => e.SenderDistrictCode)
                    .HasMaxLength(4)
                    .HasComment("Địa chỉ gửi: quận / huyện");

                entity.Property(e => e.SenderEmail)
                    .HasMaxLength(50)
                    .HasComment("Email người gửi");

                entity.Property(e => e.SenderFax)
                    .HasMaxLength(15)
                    .HasComment("Fax người gửi");

                entity.Property(e => e.SenderFullName)
                    .HasMaxLength(500)
                    .HasComment("Tên khách hàng gửi");

                entity.Property(e => e.SenderIdentifyNumber)
                    .HasMaxLength(20)
                    .HasComment("Số CMND/ CCCD");

                entity.Property(e => e.SenderProvinceCode)
                    .HasMaxLength(3)
                    .HasComment("Địa chỉ gửi: tỉnh / tp");

                entity.Property(e => e.SenderTaxCode)
                    .HasMaxLength(50)
                    .HasComment("Mã số thuế người gửi");

                entity.Property(e => e.SenderTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại người gửi");

                entity.Property(e => e.Status).HasComment("Trạng thái yêu cầu: 1 - Đang khởi tạo; 2 - Chờ phê duyệt; 3 - Đã duyệt; 4 - Từ chối duyệt; 5 - Đã nhận gửi");

                entity.Property(e => e.TellersApprovedBy)
                    .HasMaxLength(50)
                    .HasComment("GDV duyệt");

                entity.Property(e => e.TellersApprovedContent)
                    .HasMaxLength(500)
                    .HasComment("Nội dung phê duyệt");

                entity.Property(e => e.TellersApprovedDate)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian GDV duyệt");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.RequestAccepted)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestAccepted_POS");
            });

            modelBuilder.Entity<RequestAcceptedConfirm>(entity =>
            {
                entity.HasKey(e => e.ConfirmID);

                entity.HasComment("Xác nhận yêu cầu tiếp nhận");

                entity.Property(e => e.ConfirmID)
                    .HasComment("ID xác nhận")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ItemNumber).HasComment("Số lượng");

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasComment("Loại bưu gửi");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú");

                entity.Property(e => e.RequestID).HasComment("ID yêu cầu");

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.RequestAcceptedConfirm)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestAcceptedConfirm_ItemType");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestAcceptedConfirm)
                    .HasForeignKey(d => d.RequestID)
                    .HasConstraintName("FK_RequestAcceptedConfirm_RequestAccepted");
            });

            modelBuilder.Entity<RequestAcceptedDetail>(entity =>
            {
                entity.HasKey(e => e.RequestDetailID);

                entity.HasComment("Chi tiết tiếp nhận yêu cầu");

                entity.Property(e => e.RequestDetailID)
                    .HasComment("ID chi tiết tiếp nhận")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttachFile).HasComment("File đính kèm");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ItemCodeCustomer)
                    .HasMaxLength(500)
                    .HasComment("Số công văn / số hiệu khách hàng");

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(3)
                    .HasComment("Loại bưu gửi");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComment("Ghi chú");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ nhận");

                entity.Property(e => e.ReceiverCommuneCode)
                    .HasMaxLength(6)
                    .HasComment("Địa chỉ nhận: phường /xã");

                entity.Property(e => e.ReceiverContact)
                    .HasMaxLength(500)
                    .HasComment("Người liên hệ");

                entity.Property(e => e.ReceiverCustomerAddress)
                    .HasMaxLength(500)
                    .HasComment("Địa chỉ khách hàng");

                entity.Property(e => e.ReceiverCustomerCode)
                    .HasMaxLength(50)
                    .HasComment("Mã khách hàng nhận");

                entity.Property(e => e.ReceiverCustomerName)
                    .HasMaxLength(500)
                    .HasComment("Tên khách hàng nhận");

                entity.Property(e => e.ReceiverCustomerTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại khách hàng");

                entity.Property(e => e.ReceiverDistrictCode)
                    .HasMaxLength(4)
                    .HasComment("Địa chỉ nhận: quận / huyện");

                entity.Property(e => e.ReceiverEmail)
                    .HasMaxLength(50)
                    .HasComment("Email người nhận");

                entity.Property(e => e.ReceiverFax)
                    .HasMaxLength(15)
                    .HasComment("Fax người nhận");

                entity.Property(e => e.ReceiverFullName)
                    .HasMaxLength(500)
                    .HasComment("Tên người nhận nhận");

                entity.Property(e => e.ReceiverIdentifyNumber)
                    .HasMaxLength(20)
                    .HasComment("CMND / căn cước người nhận");

                entity.Property(e => e.ReceiverProvinceCode)
                    .HasMaxLength(3)
                    .HasComment("Địa chỉ nhận: tỉnh / tp");

                entity.Property(e => e.ReceiverTaxCode)
                    .HasMaxLength(50)
                    .HasComment("Mã số thuế người nhận");

                entity.Property(e => e.ReceiverTel)
                    .HasMaxLength(15)
                    .HasComment("Điện thoại người nhận");

                entity.Property(e => e.RequestID).HasComment("ID tiếp nhận");

                entity.Property(e => e.RequestIndex).HasComment("Thứ tự");

                entity.Property(e => e.Special).HasComment("Bưu gửi đặc biệt cần phát ngay");

                entity.Property(e => e.Status).HasComment("Trạng thái yêu cầu: 1 - Đang khởi tạo; 2 - Chờ phê duyệt; 3 - Đã duyệt; 4 - Từ chối duyệt; 5 - Đã nhận gửi");

                entity.Property(e => e.TimerDelivery)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian phát hẹn giờ");

                entity.Property(e => e.UndeliveryGuideCode).HasComment("Chỉ dẫn khi không phát được");

                entity.Property(e => e.VPostCode).HasMaxLength(100);

                entity.Property(e => e.Weight).HasComment("Khối lượng");

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.RequestAcceptedDetail)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .HasConstraintName("FK_RequestAcceptedDetail_ItemType");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestAcceptedDetail)
                    .HasForeignKey(d => d.RequestID)
                    .HasConstraintName("FK_RequestAcceptedDetail_RequestAccepted");

                entity.HasOne(d => d.UndeliveryGuideCodeNavigation)
                    .WithMany(p => p.RequestAcceptedDetail)
                    .HasForeignKey(d => d.UndeliveryGuideCode)
                    .HasConstraintName("FK_RequestAcceptedDetail_UndeliveryGuide");
            });

            modelBuilder.Entity<RevenueSharing>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ItemCode, e.POSCode, e.PhaseCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.RevenueSharing)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_RevenueSharing_POS");

                entity.HasOne(d => d.ServicePhase)
                    .WithMany(p => p.RevenueSharing)
                    .HasForeignKey(d => new { d.PhaseCode, d.ServiceCode })
                    .HasConstraintName("FK_RevenueSharing_ServicePhase");
            });

            modelBuilder.Entity<RevenueSharingItemType>(entity =>
            {
                entity.HasKey(e => new { e.ProvinceCode, e.ValueDate, e.ItemType, e.ServiceCode });

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.ItemType).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(6);
            });

            modelBuilder.Entity<RevenueSharingRule>(entity =>
            {
                entity.HasKey(e => new { e.RevenueSharingRuleCode, e.ServiceCode });

                entity.Property(e => e.RevenueSharingRuleCode).HasMaxLength(5);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.RuleNumber).HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.RevenueSharingRule)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_RevenueSharingRule_Service");
            });

            modelBuilder.Entity<RevenueSharingValueAddedService>(entity =>
            {
                entity.HasKey(e => new { e.ProvinceCode, e.ValueDate, e.ValueAddedService, e.ServiceCode });

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.ValueAddedService).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(6);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.Property(e => e.RoleCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ParentRoleCode).HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ParentRoleCodeNavigation)
                    .WithMany(p => p.InverseParentRoleCodeNavigation)
                    .HasForeignKey(d => d.ParentRoleCode)
                    .HasConstraintName("FK_Role_Role");
            });

            modelBuilder.Entity<RoleObject>(entity =>
            {
                entity.Property(e => e.RoleObjectId).ValueGeneratedNever();

                entity.HasOne(d => d.ObjectRef)
                    .WithMany(p => p.RoleObject)
                    .HasForeignKey(d => d.ObjectRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleObject_ObjectRef");

                entity.HasOne(d => d.RolesGrantPermission)
                    .WithMany(p => p.RoleObject)
                    .HasForeignKey(d => d.RolesGrantPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleObject_RolesGrantPermission");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleObjectId, e.GroupCode });

                entity.Property(e => e.GroupCode).HasMaxLength(10);

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.GroupCode)
                    .HasConstraintName("FK_RolePermission_Group");

                entity.HasOne(d => d.RoleObject)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_RoleObject");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.Property(e => e.RoleCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RolesGrantPermission>(entity =>
            {
                entity.Property(e => e.RolesGrantPermissionId).ValueGeneratedNever();

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.RolesGrantPermission)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesGrantPermission_PermissionAndGroupPermission");

                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.RolesGrantPermission)
                    .HasForeignKey(d => d.RoleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesGrantPermission_Roles");
            });

            modelBuilder.Entity<SMS>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.MessageContent).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SaleChannel>(entity =>
            {
                entity.HasKey(e => e.SaleChannelCode);

                entity.Property(e => e.SaleChannelCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SaleChannelName).HasMaxLength(50);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "KT1");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => new { e.SectionCode, e.POSCode });

                entity.Property(e => e.SectionCode).HasMaxLength(3);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_Section_POS");
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.HasKey(e => new { e.ServerCode, e.POSCode });

                entity.Property(e => e.ServerCode).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.IP).HasMaxLength(50);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Server)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_Server_POS");
            });

            modelBuilder.Entity<Server1>(entity =>
            {
                entity.ToTable("Server", "KT1");

                entity.HasIndex(e => e.LastHeartbeat)
                    .HasName("IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceCode);

                entity.HasIndex(e => e.ServiceNameSearch)
                    .HasName("ix_service_name_search");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.AutomaticGenerationCharacterFrom).HasMaxLength(1);

                entity.Property(e => e.AutomaticGenerationCharacterTo).HasMaxLength(1);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImageName).HasMaxLength(500);

                entity.Property(e => e.PrintCharacterFrom).HasMaxLength(1);

                entity.Property(e => e.PrintCharacterTo).HasMaxLength(1);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([ServiceName])),0))");

                entity.Property(e => e.ServicePriorityCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceTypeCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ShortName).HasMaxLength(10);

                entity.Property(e => e.ShortcutKey).HasMaxLength(1);

                entity.Property(e => e.SupplyScope).HasMaxLength(500);

                entity.HasOne(d => d.ServicePriorityCodeNavigation)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ServicePriorityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_ServicePriority");

                entity.HasOne(d => d.ServiceTypeCodeNavigation)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ServiceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_ServiceType");
            });

            modelBuilder.Entity<ServiceCommodityType>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.CommodityTypeCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.CommodityTypeCode).HasMaxLength(6);

                entity.HasOne(d => d.CommodityTypeCodeNavigation)
                    .WithMany(p => p.ServiceCommodityType)
                    .HasForeignKey(d => d.CommodityTypeCode)
                    .HasConstraintName("FK_ServiceCommodityType_CommodityType");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceCommodityType)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServiceCommodityType_ServiceCommodityType");
            });

            modelBuilder.Entity<ServiceConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ConfigCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ConfigCode).HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(50);

                entity.HasOne(d => d.ConfigCodeNavigation)
                    .WithMany(p => p.ServiceConfiguration)
                    .HasForeignKey(d => d.ConfigCode)
                    .HasConstraintName("FK_ServiceConfiguration_Configuration");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceConfiguration)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServiceConfiguration_Service");
            });

            modelBuilder.Entity<ServiceItemRemaining>(entity =>
            {
                entity.HasKey(e => new { e.HandoverIndex, e.ShiftCode, e.POSCode, e.CounterCode, e.ServiceCode });

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.CounterCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(1);
            });

            modelBuilder.Entity<ServiceItemType>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ItemTypeCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.HasOne(d => d.ItemTypeCodeNavigation)
                    .WithMany(p => p.ServiceItemType)
                    .HasForeignKey(d => d.ItemTypeCode)
                    .HasConstraintName("FK_ServiceItemType_ItemType");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceItemType)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServiceItemType_Service");
            });

            modelBuilder.Entity<ServicePOSConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.ServiceCode, e.ConfigCode });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ConfigCode).HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(50);

                entity.HasOne(d => d.ConfigCodeNavigation)
                    .WithMany(p => p.ServicePOSConfiguration)
                    .HasForeignKey(d => d.ConfigCode)
                    .HasConstraintName("FK_ServicePOSConfiguration_Configuration");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.ServicePOSConfiguration)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_ServicePOSConfiguration_POS");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServicePOSConfiguration)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServicePOSConfiguration_Service");
            });

            modelBuilder.Entity<ServicePhase>(entity =>
            {
                entity.HasKey(e => new { e.PhaseCode, e.ServiceCode });

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.HasOne(d => d.PhaseCodeNavigation)
                    .WithMany(p => p.ServicePhase)
                    .HasForeignKey(d => d.PhaseCode)
                    .HasConstraintName("FK_ServicePhase_Phase");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServicePhase)
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePhase_Service");
            });

            modelBuilder.Entity<ServicePriority>(entity =>
            {
                entity.HasKey(e => e.ServicePriorityCode);

                entity.Property(e => e.ServicePriorityCode).HasMaxLength(2);

                entity.Property(e => e.ServicePriorityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServicePriority_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ServicePriorityCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServicePriorityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceProperty>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.PropertyCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.HasOne(d => d.PropertyCodeNavigation)
                    .WithMany(p => p.ServiceProperty)
                    .HasForeignKey(d => d.PropertyCode)
                    .HasConstraintName("FK_ServiceProperty_Property");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceProperty)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServiceProperty_Service");
            });

            modelBuilder.Entity<ServiceSaleChannel>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.SaleChannelCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.SaleChannelCode).HasMaxLength(2);

                entity.HasOne(d => d.SaleChannelCodeNavigation)
                    .WithMany(p => p.ServiceSaleChannel)
                    .HasForeignKey(d => d.SaleChannelCode)
                    .HasConstraintName("FK_ServiceSaleChannel_SaleChannel");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceSaleChannel)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_ServiceSaleChannel_Service");
            });

            modelBuilder.Entity<ServiceSupplying>(entity =>
            {
                entity.HasKey(e => new { e.CommuneCode, e.POSCode });

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.HasOne(d => d.CommuneCodeNavigation)
                    .WithMany(p => p.ServiceSupplying)
                    .HasForeignKey(d => d.CommuneCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceSupplying_Commune");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.ServiceSupplying)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_ServiceSupplying_POS");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.ServiceTypeCode);

                entity.HasIndex(e => e.ServiceTypeNameSearch)
                    .HasName("ix_servicetype_name_search");

                entity.Property(e => e.ServiceTypeCode).HasMaxLength(15);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ServiceTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([ServiceTypeName])),0))");

                entity.Property(e => e.ServiceTypeParentCode).HasMaxLength(15);

                entity.HasOne(d => d.ServiceTypeParentCodeNavigation)
                    .WithMany(p => p.InverseServiceTypeParentCodeNavigation)
                    .HasForeignKey(d => d.ServiceTypeParentCode)
                    .HasConstraintName("FK_ServiceType_ServiceType");
            });

            modelBuilder.Entity<ServiceType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ServiceTypeCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ServiceTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceTypeParentCode).HasMaxLength(15);
            });

            modelBuilder.Entity<Service_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AutomaticGenerationCharacterFrom).HasMaxLength(1);

                entity.Property(e => e.AutomaticGenerationCharacterTo).HasMaxLength(1);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImageName).HasMaxLength(500);

                entity.Property(e => e.PrintCharacterFrom).HasMaxLength(1);

                entity.Property(e => e.PrintCharacterTo).HasMaxLength(1);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServicePriorityCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ServiceTypeCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ShortName).HasMaxLength(10);

                entity.Property(e => e.SupplyScope).HasMaxLength(500);
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "KT1");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score })
                    .HasName("IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => new { e.ShiftCode, e.POSCode });

                entity.HasIndex(e => e.ShiftNameSearch)
                    .HasName("ix_shift_name_search");

                entity.Property(e => e.ShiftCode)
                    .HasMaxLength(1)
                    .HasComment("Mã ca làm việc");

                entity.Property(e => e.POSCode)
                    .HasMaxLength(6)
                    .HasComment("Mã bưu cục");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasComment("Mô tả");

                entity.Property(e => e.FinishHour)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian kết thúc");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Tên ca làm việc");

                entity.Property(e => e.ShiftNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([ShiftName])),0))");

                entity.Property(e => e.StartHour)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian bắt đầu");

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Shift)
                    .HasForeignKey(d => d.POSCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shift_POS");
            });

            modelBuilder.Entity<ShiftHandover>(entity =>
            {
                entity.HasIndex(e => e.StartDate)
                    .HasName("idx_ShiftHandover_StartDate");

                entity.HasIndex(e => e.StartMonth)
                    .HasName("idx_ShiftHandover_StartMonth");

                entity.HasIndex(e => e.StartYear)
                    .HasName("idx_ShiftHandover_StartYear");

                entity.Property(e => e.ShiftHandoverID)
                    .HasComment("ID ca làm việc")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConfirmContent).HasMaxLength(500);

                entity.Property(e => e.ConfirmTime).HasColumnType("datetime");

                entity.Property(e => e.ConfirmUserName).HasMaxLength(50);

                entity.Property(e => e.GivingFullName)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("([dbo].[ShiftHandover_FullName]([POSCode],[GivingUserName]))");

                entity.Property(e => e.GivingUserName)
                    .HasMaxLength(50)
                    .HasComment("Người bàn giao");

                entity.Property(e => e.HandoverIndex).HasComment("Thứ tự");

                entity.Property(e => e.HandoverTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian chốt ca");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Mã bưu cục");

                entity.Property(e => e.RecevingFullName)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("([dbo].[ShiftHandover_FullName]([POSCode],[RecevingUserName]))");

                entity.Property(e => e.RecevingUserName)
                    .HasMaxLength(50)
                    .HasComment("Người nhận bàn giao");

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasComment("Mã ca");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(8)
                    .HasComputedColumnSql("([dbo].[CP_FORMAT_DATE]([StartTime]))");

                entity.Property(e => e.StartMonth)
                    .HasMaxLength(6)
                    .HasComputedColumnSql("(right('0000'+CONVERT([nvarchar](4),datepart(year,[StartTime])),(4))+right('00'+CONVERT([nvarchar](2),datepart(month,[StartTime])),(2)))");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian bắt đầu");

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .HasComputedColumnSql("(right('0000'+CONVERT([nvarchar](4),datepart(year,[StartTime])),(4)))");

                entity.Property(e => e.Status).HasComment("Trạng thái 0 - Đang khởi tạo; 1- Đã chốt");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ShiftHandover)
                    .HasForeignKey(d => new { d.ShiftCode, d.POSCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandover_Shift");
            });

            modelBuilder.Entity<ShiftHandoverBC37>(entity =>
            {
                entity.HasKey(e => new { e.Status, e.BC37ID, e.ShiftHandoverID });

                entity.Property(e => e.BC37Date)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.CounterCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.BC37)
                    .WithMany(p => p.ShiftHandoverBC37)
                    .HasForeignKey(d => d.BC37ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverBC37_BC37");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverBC37)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverBC37_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverDevice>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.DeviceID });

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.ShiftHandoverDevice)
                    .HasForeignKey(d => d.DeviceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverDevice_Device");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverDevice)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverDevice_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverItem>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.ItemID, e.Status })
                    .HasName("PK_Ctin_ShiftHandoverItem_NonCluster")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ShiftHandoverMonth, e.ShiftHandoverID, e.ItemID, e.Status })
                    .HasName("PK_ShiftHandoverItem")
                    .IsClustered();

                entity.Property(e => e.ShiftHandoverID).HasComment("ID ca làm việc");

                entity.Property(e => e.ItemID).HasComment("ID bưu gửi");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.IndexNumber).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.ShiftHandoverDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](8),[ShiftHandoverTime],(112)))");

                entity.Property(e => e.ShiftHandoverMonth)
                    .HasMaxLength(6)
                    .HasComputedColumnSql("(right('0000'+CONVERT([nvarchar](4),datepart(year,[ShiftHandoverTime])),(4))+right('00'+CONVERT([nvarchar](2),datepart(month,[ShiftHandoverTime])),(2)))");

                entity.Property(e => e.ShiftHandoverTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftHandoverYear).HasComputedColumnSql("(datepart(year,[ShiftHandoverTime]))");

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ShiftHandoverItem)
                    .HasForeignKey(d => d.ItemID)
                    .HasConstraintName("FK_ShiftHandoverItem_Item");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverItem)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverItem_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverMailtrip>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.MailtripID, e.Status })
                    .HasName("PK_Ctin_ShiftHandoverMailtrip_NonCluster")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ShiftHandoverMonth, e.ShiftHandoverID, e.MailtripID, e.Status })
                    .HasName("PK_ShiftHandoverMailtrip")
                    .IsClustered();

                entity.Property(e => e.ShiftHandoverID).HasComment("ID ca làm việc");

                entity.Property(e => e.MailtripID).HasComment("ID chuyến thư");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.ShiftHandoverDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](8),[ShiftHandoverTime],(112)))");

                entity.Property(e => e.ShiftHandoverMonth)
                    .HasMaxLength(6)
                    .HasComputedColumnSql("(right('0000'+CONVERT([nvarchar](4),datepart(year,[ShiftHandoverTime])),(4))+right('00'+CONVERT([nvarchar](2),datepart(month,[ShiftHandoverTime])),(2)))");

                entity.Property(e => e.ShiftHandoverTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftHandoverYear).HasComputedColumnSql("(datepart(year,[ShiftHandoverTime]))");

                entity.HasOne(d => d.Mailtrip)
                    .WithMany(p => p.ShiftHandoverMailtrip)
                    .HasForeignKey(d => d.MailtripID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtrip_Mailtrip");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverMailtrip)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtrip_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverMailtripDelivery>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.MailtripID, e.Status });

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Mailtrip)
                    .WithMany(p => p.ShiftHandoverMailtripDelivery)
                    .HasForeignKey(d => d.MailtripID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtripDelivery_Mailtrip");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverMailtripDelivery)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtripDelivery_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverMailtripTransport>(entity =>
            {
                entity.HasKey(e => new { e.Status, e.MailtripTransportID, e.ShiftHandoverID })
                    .HasName("PK_ShiftHandoverMailtripTransport_1");

                entity.Property(e => e.CounterCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransportDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.MailtripTransport)
                    .WithMany(p => p.ShiftHandoverMailtripTransport)
                    .HasForeignKey(d => d.MailtripTransportID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtripTransport_MailtripTransport1");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverMailtripTransport)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverMailtripTransport_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverPostBag>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.PostbagID, e.Status });

                entity.Property(e => e.ShiftHandoverID).HasComment("ID ca làm việc");

                entity.Property(e => e.PostbagID).HasComment("ID túi");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.HasOne(d => d.Postbag)
                    .WithMany(p => p.ShiftHandoverPostBag)
                    .HasForeignKey(d => d.PostbagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverPostBag_PostBag");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverPostBag)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverPostBag_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverPostBagEmpty>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.PostBagEmptyID });

                entity.Property(e => e.ShiftHandoverID).HasComment("Id ca làm việc");

                entity.Property(e => e.PostBagEmptyID).HasComment("Id túi rỗng");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người điều chỉnh");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày điều chỉnh");

                entity.HasOne(d => d.PostBagEmpty)
                    .WithMany(p => p.ShiftHandoverPostBagEmpty)
                    .HasForeignKey(d => d.PostBagEmptyID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverPostBagEmpty_PostBagEmpty");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverPostBagEmpty)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverPostBagEmpty_ShiftHandover");
            });

            modelBuilder.Entity<ShiftHandoverRequestAccepted>(entity =>
            {
                entity.HasKey(e => new { e.ShiftHandoverID, e.RequestID, e.Status });

                entity.Property(e => e.ShiftHandoverID).HasComment("ID ca làm việc");

                entity.Property(e => e.RequestID).HasComment("ID yêu cầu");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ShiftHandoverRequestAccepted)
                    .HasForeignKey(d => d.RequestID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverRequestAccepted_RequestAccepted");

                entity.HasOne(d => d.ShiftHandover)
                    .WithMany(p => p.ShiftHandoverRequestAccepted)
                    .HasForeignKey(d => d.ShiftHandoverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftHandoverRequestAccepted_ShiftHandover");
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.HasKey(e => e.SolutionCode);

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SolutionName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SolutionCustomer>(entity =>
            {
                entity.HasKey(e => new { e.SolutionCode, e.CustomerCode });

                entity.Property(e => e.SolutionCode).HasMaxLength(2);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.SolutionCustomer)
                    .HasForeignKey(d => d.CustomerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolutionCustomer_Customer");

                entity.HasOne(d => d.SolutionCodeNavigation)
                    .WithMany(p => p.SolutionCustomer)
                    .HasForeignKey(d => d.SolutionCode)
                    .HasConstraintName("FK_SolutionCustomer_Solution");
            });

            modelBuilder.Entity<StampMachine>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.StampMachineNumber });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.StampMachineNumber).HasMaxLength(6);

                entity.Property(e => e.StampMachineName).HasMaxLength(200);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.StampMachine)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_StampMachine_POS");
            });

            modelBuilder.Entity<StampMachineFeight>(entity =>
            {
                entity.HasKey(e => new { e.POSCode, e.StampMachineNumber, e.DateInput });

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.StampMachineNumber).HasMaxLength(6);

                entity.Property(e => e.DateInput).HasColumnType("datetime");

                entity.HasOne(d => d.StampMachine)
                    .WithMany(p => p.StampMachineFeight)
                    .HasForeignKey(d => new { d.POSCode, d.StampMachineNumber })
                    .HasConstraintName("FK_StampMachineFeight_StampMachine");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "KT1");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<StoreBehavior>(entity =>
            {
                entity.Property(e => e.StoreBehaviorId).ValueGeneratedNever();

                entity.Property(e => e.StoreBehaviorName).HasMaxLength(50);
            });

            modelBuilder.Entity<StoreDependOn>(entity =>
            {
                entity.HasKey(e => new { e.MessageTypeName, e.TableName, e.ColumnName, e.StoreDependOnTableName, e.StoreDependOnColumnName })
                    .HasName("PK_StoreDependOn_1");

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.ColumnName).HasMaxLength(100);

                entity.Property(e => e.StoreDependOnTableName).HasMaxLength(100);

                entity.Property(e => e.StoreDependOnColumnName).HasMaxLength(100);

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.StoreDependOnColumn)
                    .HasForeignKey(d => new { d.ColumnName, d.TableName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreDependOn_Column");

                entity.HasOne(d => d.MessageTypeTable)
                    .WithMany(p => p.StoreDependOn)
                    .HasForeignKey(d => new { d.MessageTypeName, d.TableName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreDependOn_MessageTypeTable");

                entity.HasOne(d => d.StoreDependOnNavigation)
                    .WithMany(p => p.StoreDependOnStoreDependOnNavigation)
                    .HasForeignKey(d => new { d.StoreDependOnColumnName, d.StoreDependOnTableName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreDependOn_Column1");
            });

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.Property(e => e.StoreTypeId).ValueGeneratedNever();

                entity.Property(e => e.StoreTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SynchronizationHistory>(entity =>
            {
                entity.HasKey(e => e.MessageTypeName);

                entity.Property(e => e.MessageTypeName).HasMaxLength(100);

                entity.Property(e => e.SyncDate).HasColumnType("datetime");

                entity.Property(e => e.SyncUser).HasMaxLength(50);
            });

            modelBuilder.Entity<TMSTransport>(entity =>
            {
                entity.HasKey(e => e.BD10);

                entity.Property(e => e.BD10).HasMaxLength(200);

                entity.Property(e => e.ATA)
                    .HasColumnType("datetime")
                    .HasComment("Thực tế kết thúc");

                entity.Property(e => e.ATD)
                    .HasColumnType("datetime")
                    .HasComment("Thực tế bắt đầu");

                entity.Property(e => e.BC37DestinationCode).HasMaxLength(6);

                entity.Property(e => e.BC37StartingCode).HasMaxLength(6);

                entity.Property(e => e.BD10RoutingTypeName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Cấp đường thư");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tài xế 1");

                entity.Property(e => e.DriverName2)
                    .HasMaxLength(200)
                    .HasComment("Tài xế 2");

                entity.Property(e => e.ETA)
                    .HasColumnType("datetime")
                    .HasComment("Dự kiến kết thúc");

                entity.Property(e => e.ETD)
                    .HasColumnType("datetime")
                    .HasComment("Dự kiến băt đầu");

                entity.Property(e => e.GroupOfVehicleRangeName)
                    .HasMaxLength(200)
                    .HasComment("Tải trọng phương tiện");

                entity.Property(e => e.GroupOfVendorCode)
                    .HasMaxLength(200)
                    .HasComment("Loại hình đơn vị");

                entity.Property(e => e.HRM)
                    .HasMaxLength(200)
                    .HasComment("Mã HRM 1");

                entity.Property(e => e.HRM2)
                    .HasMaxLength(200)
                    .HasComment("Mã HRM 2");

                entity.Property(e => e.KmGPS)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("KM GPS");

                entity.Property(e => e.OPSRoutingName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tên đường thư");

                entity.Property(e => e.OPSRoutingOfficeName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tên đơn vị");

                entity.Property(e => e.RoutingCategoryName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tính chất đường thư");

                entity.Property(e => e.RoutingContentName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Nội dung vận chuyển");

                entity.Property(e => e.TOMasterCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Mã chuyến");

                entity.Property(e => e.TypeOfContractDriverName)
                    .HasMaxLength(200)
                    .HasComment("Hợp đồng tài xế 1");

                entity.Property(e => e.TypeOfContractDriverName2)
                    .HasMaxLength(200)
                    .HasComment("Hợp đồng tài xế 2");

                entity.Property(e => e.TypeOfTrip)
                    .HasMaxLength(200)
                    .HasComment("Loại chuyến thư");

                entity.Property(e => e.VehicleCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Biển số xe");

                entity.Property(e => e.VehicleGroupName)
                    .HasMaxLength(200)
                    .HasComment("Loại xe");

                entity.Property(e => e.VehicleTypeName)
                    .HasMaxLength(200)
                    .HasComment("Loại phương tiện");

                entity.Property(e => e.VendorCode)
                    .HasMaxLength(200)
                    .HasComment("Mã đơn vị vận chuyển");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tên đơn vị vận chuyển");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.Property(e => e.TableName).HasMaxLength(100);
            });

            modelBuilder.Entity<TargetCataloge>(entity =>
            {
                entity.HasKey(e => e.TargetCatalogeCode);

                entity.Property(e => e.TargetCatalogeCode).HasMaxLength(50);

                entity.Property(e => e.TargetCatalogeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TargetCatalogeParentCode).HasMaxLength(50);

                entity.HasOne(d => d.TargetCatalogeParentCodeNavigation)
                    .WithMany(p => p.InverseTargetCatalogeParentCodeNavigation)
                    .HasForeignKey(d => d.TargetCatalogeParentCode)
                    .HasConstraintName("FK_TargetCataloge_TargetCataloge");
            });

            modelBuilder.Entity<TargetParameters>(entity =>
            {
                entity.HasKey(e => new { e.ParameterCode, e.TargetCode })
                    .HasName("PK_Parameters");

                entity.Property(e => e.ParameterCode).HasMaxLength(50);

                entity.Property(e => e.TargetCode).HasMaxLength(50);

                entity.Property(e => e.ParameterValue).HasMaxLength(500);

                entity.HasOne(d => d.TargetCodeNavigation)
                    .WithMany(p => p.TargetParameters)
                    .HasForeignKey(d => d.TargetCode)
                    .HasConstraintName("FK_Parameters_Tagets");
            });

            modelBuilder.Entity<TargetValues>(entity =>
            {
                entity.HasKey(e => new { e.TargetCode, e.POSCode, e.InsertDate })
                    .HasName("PK_TargetValues_1");

                entity.Property(e => e.TargetCode).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasMaxLength(8);

                entity.HasOne(d => d.TargetCodeNavigation)
                    .WithMany(p => p.TargetValues)
                    .HasForeignKey(d => d.TargetCode)
                    .HasConstraintName("FK_TagetValues_Tagets");
            });

            modelBuilder.Entity<Targets>(entity =>
            {
                entity.HasKey(e => e.TargetCode)
                    .HasName("PK_Tagets");

                entity.Property(e => e.TargetCode).HasMaxLength(50);

                entity.Property(e => e.TargetCatalogeCode).HasMaxLength(50);

                entity.Property(e => e.TargetName).HasMaxLength(150);

                entity.Property(e => e.UnitType).HasMaxLength(50);

                entity.HasOne(d => d.TargetCatalogeCodeNavigation)
                    .WithMany(p => p.Targets)
                    .HasForeignKey(d => d.TargetCatalogeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Targets_TargetCataloge");
            });

            modelBuilder.Entity<TraceItem>(entity =>
            {
                entity.HasComment("Lịch sử bưu gửi");

                entity.HasIndex(e => e.ItemID)
                    .HasName("idx_traceitem_itemid");

                entity.HasIndex(e => new { e.ItemID, e.IsLast })
                    .HasName("idx_traceitem_itemIdIsLast");

                entity.HasIndex(e => new { e.ItemID, e.POSCode, e.Status, e.IsLast })
                    .HasName("idx_TraceItem_IsLast");

                entity.HasIndex(e => new { e.TraceItemID, e.ItemID, e.POSCode, e.Status, e.IsLast })
                    .HasName("idx_TraceItem_PosCodeStatusIsLast");

                entity.Property(e => e.TraceItemID)
                    .HasComment("ID lịch sử")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.IsLast).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("([dbo].[TraceItem_ItemCode]([ItemID]))");

                entity.Property(e => e.ItemID).HasComment("ID bưu gửi");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasComment("Ghi chú");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.StatusDesc)
                    .HasMaxLength(200)
                    .HasComment("Mô tả");

                entity.Property(e => e.TableID).HasComment("ID bảng phát sinh nghiệp vụ");

                entity.Property(e => e.TableName)
                    .HasMaxLength(256)
                    .HasComment("Tên bảng nghiệp vụ phát sinh dịch vụ");

                entity.Property(e => e.TraceDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày thực hiện");

                entity.Property(e => e.TraceIndex).HasComment("Thứ tự");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TraceItem)
                    .HasForeignKey(d => d.ItemID)
                    .HasConstraintName("FK_TraceItem_Item");
            });

            modelBuilder.Entity<TraceItem_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StatusDesc).HasMaxLength(200);

                entity.Property(e => e.TraceDate).HasColumnType("datetime");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);
            });

            modelBuilder.Entity<TracePostBag>(entity =>
            {
                entity.HasComment("Lịch sử túi thư");

                entity.Property(e => e.TracePostBagID)
                    .HasComment("ID lịch sử túi thư")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasComment("Ghi chú");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Bưu cục");

                entity.Property(e => e.PostbagID).HasComment("ID túi thư");

                entity.Property(e => e.Status).HasComment("Trạng thái");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(200)
                    .HasComment("Mô tả");

                entity.Property(e => e.TableID).HasComment("ID bảng phát sinh nghiệp vụ");

                entity.Property(e => e.TableName)
                    .HasMaxLength(256)
                    .HasComment("Tên bảng phát sinh nghiệp vụ");

                entity.Property(e => e.TraceDate)
                    .HasColumnType("datetime")
                    .HasComment("Thời gian phát sinh");

                entity.Property(e => e.TraceIndex).HasComment("Thứ tự");

                entity.HasOne(d => d.Postbag)
                    .WithMany(p => p.TracePostBag)
                    .HasForeignKey(d => d.PostbagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TracePostBag_PostBag");
            });

            modelBuilder.Entity<TracePostBag_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.MailTripNumber)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.MailTripType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StatusDescription).HasMaxLength(200);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.TraceDate).HasColumnType("datetime");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferMachine).HasMaxLength(50);

                entity.Property(e => e.TransferPOSCode).HasMaxLength(6);

                entity.Property(e => e.TransferUser).HasMaxLength(50);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.TransportCode)
                    .HasName("PK_Transport_Status");

                entity.Property(e => e.TransportCode).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransportGroup)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.Transport)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK_Transport_POS");

                entity.HasOne(d => d.TransportGroupNavigation)
                    .WithMany(p => p.Transport)
                    .HasForeignKey(d => d.TransportGroup)
                    .HasConstraintName("FK_Transport_TransportGroup");
            });

            modelBuilder.Entity<TransportError>(entity =>
            {
                entity.Property(e => e.TransportErrorID).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(3000);

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.TransportCodeNavigation)
                    .WithMany(p => p.TransportError)
                    .HasForeignKey(d => d.TransportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__Trans__2185BB0E");
            });

            modelBuilder.Entity<TransportGroup>(entity =>
            {
                entity.HasKey(e => e.TransportGroupCode);

                entity.Property(e => e.TransportGroupCode).HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.TransportGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TransportGroup_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.TransportGroupCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TransportGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TransportType>(entity =>
            {
                entity.HasKey(e => e.TransportTypeCode);

                entity.HasIndex(e => e.TransportTypeNameSearch)
                    .HasName("ix_transporttype_name_search");

                entity.Property(e => e.TransportTypeCode).HasMaxLength(1);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.TransportTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TransportTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([TransportTypeName])),0))");
            });

            modelBuilder.Entity<TransportType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.TransportTypeCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.TransportTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Transport_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransportGroup)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<UndeliveryGuide>(entity =>
            {
                entity.HasKey(e => e.UndeliveryGuideCode);

                entity.Property(e => e.UndeliveryGuideCode).HasComment("Mã chỉ dẫn khi không phát được");

                entity.Property(e => e.UndeliveryGuideName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Tên chỉ dẫn khi không phát được");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.UnitCode);

                entity.HasIndex(e => e.UnitNameSearch)
                    .HasName("ix_unit_name_search");

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(6)
                    .HasComment("Mã đơn vị");

                entity.Property(e => e.CommuneCode)
                    .HasMaxLength(6)
                    .HasComment("Mã phường xã");

                entity.Property(e => e.ParentUnitCode)
                    .HasMaxLength(6)
                    .HasComment("Mã đơn vị cha");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tên đơn vị");

                entity.Property(e => e.UnitNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([UnitName])),0))");

                entity.Property(e => e.UnitTypeCode)
                    .HasMaxLength(3)
                    .HasComment("Loại đơn vị");

                entity.HasOne(d => d.CommuneCodeNavigation)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.CommuneCode)
                    .HasConstraintName("FK_Unit_Commune");

                entity.HasOne(d => d.ParentUnitCodeNavigation)
                    .WithMany(p => p.InverseParentUnitCodeNavigation)
                    .HasForeignKey(d => d.ParentUnitCode)
                    .HasConstraintName("FK_Unit_Unit");

                entity.HasOne(d => d.UnitTypeCodeNavigation)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Unit_UnitType");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.HasKey(e => e.UnitTypeCode);

                entity.HasIndex(e => e.UnitTypeNameSearch)
                    .HasName("ix_unittype_name_search");

                entity.Property(e => e.UnitTypeCode)
                    .HasMaxLength(3)
                    .HasComment("Loại đơn vị");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasComment("Mô tả");

                entity.Property(e => e.UnitTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Tên đơn vị");

                entity.Property(e => e.UnitTypeNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([UnitTypeName])),0))");
            });

            modelBuilder.Entity<UnitType_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UnitTypeCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.UnitTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Unit_MBCSync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.ParentUnitCode).HasMaxLength(6);

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitTypeCode).HasMaxLength(3);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__User__C9F28457634F2312");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CustomerCode).HasMaxLength(17);

                entity.Property(e => e.FullName).HasMaxLength(500);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PassWord).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.HasOne(d => d.POSCodeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.POSCode)
                    .HasConstraintName("FK__User__POSCode__7F30A30A");
            });

            modelBuilder.Entity<UserTargets>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.POSCode, e.TargetCode });

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.TargetCode).HasMaxLength(50);
            });

            modelBuilder.Entity<VASProperty>(entity =>
            {
                entity.HasKey(e => new { e.PropertyCode, e.ValueAddedServiceCode });

                entity.Property(e => e.PropertyCode).HasMaxLength(50);

                entity.Property(e => e.ValueAddedServiceCode).HasMaxLength(3);

                entity.Property(e => e.Control)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ControlValue).HasMaxLength(500);

                entity.Property(e => e.DataType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PropertyName).HasMaxLength(50);

                entity.HasOne(d => d.ValueAddedServiceCodeNavigation)
                    .WithMany(p => p.VASProperty)
                    .HasForeignKey(d => d.ValueAddedServiceCode)
                    .HasConstraintName("FK_VASProperty_ValueAddedService");
            });

            modelBuilder.Entity<VASUsing>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ValueAddedServiceCode });

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(2)
                    .HasComment("Mã dịch vụ");

                entity.Property(e => e.ValueAddedServiceCode)
                    .HasMaxLength(3)
                    .HasComment("Mã dịch vụ GTGT");

                entity.Property(e => e.CalculationMethod).HasComment(@"1: Tính cước theo nấc khối lượng
2: Tính cước theo số lượng Item trong lô
3: Tính cước theo khối lượng Item trong lô
4: Tính cước theo phần trăm tiền gửi
5: Tính cước theo 1 bưu gửi
6: Tính cước theo ngày lưu kho
7: Tính theo công thức");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.VASUsing)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("FK_VASUsing_Service");

                entity.HasOne(d => d.ValueAddedServiceCodeNavigation)
                    .WithMany(p => p.VASUsing)
                    .HasForeignKey(d => d.ValueAddedServiceCode)
                    .HasConstraintName("FK_VASUsing_ValueAddedService");
            });

            modelBuilder.Entity<ValueAddedService>(entity =>
            {
                entity.HasKey(e => e.ValueAddedServiceCode);

                entity.HasIndex(e => e.ValueAddedServiceNameSearch)
                    .HasName("ix_value_added_service_name_search");

                entity.Property(e => e.ValueAddedServiceCode)
                    .HasMaxLength(3)
                    .HasComment("Mã dịch dịch cộng thêm");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasComment("Mô tả");

                entity.Property(e => e.OrderIndex).HasComment("Thứ tự hiển thị");

                entity.Property(e => e.ValueAddedServiceName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Tên dịch vụ cộng thêm");

                entity.Property(e => e.ValueAddedServiceNameSearch)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](256),[dbo].[non_unicode_convert]([dbo].[fTCVNToUnicode]([ValueAddedServiceName])),0))");
            });

            modelBuilder.Entity<ValueAddedServiceItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemID, e.ServiceCode, e.ValueAddedServiceCode });

                entity.Property(e => e.ItemID).HasComment("ID bưu gửi");

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(2)
                    .HasComment("Mã dịch vụ");

                entity.Property(e => e.ValueAddedServiceCode)
                    .HasMaxLength(3)
                    .HasComment("Mã dịch vụ GTGT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Người tạo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasComment("Người cập nhật");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cập nhật");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ValueAddedServiceItem)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValueAddedServiceItem_Item");

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.ValueAddedServiceItem)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValueAddedServiceItem_VASUsing");
            });

            modelBuilder.Entity<ValueAddedServiceItem_Sync>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.PhaseCode).HasMaxLength(3);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ValueAddedServiceCode)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<ValueAddedServicePhase>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.ValueAddedServiceCode, e.PhaseCode });

                entity.Property(e => e.ServiceCode)
                    .HasMaxLength(2)
                    .HasComment("Mã dịch vụ");

                entity.Property(e => e.ValueAddedServiceCode)
                    .HasMaxLength(3)
                    .HasComment("Mã dịch vụ GTGT");

                entity.Property(e => e.PhaseCode)
                    .HasMaxLength(3)
                    .HasComment("Mã công đoạn");

                entity.HasOne(d => d.PhaseCodeNavigation)
                    .WithMany(p => p.ValueAddedServicePhase)
                    .HasForeignKey(d => d.PhaseCode)
                    .HasConstraintName("FK_ValueAddedServicePhase_Phase");

                entity.HasOne(d => d.VASUsing)
                    .WithMany(p => p.ValueAddedServicePhase)
                    .HasForeignKey(d => new { d.ServiceCode, d.ValueAddedServiceCode })
                    .HasConstraintName("FK_ValueAddedServicePhase_VASUsing");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasKey(e => e.VersionCode);

                entity.Property(e => e.VersionCode).HasMaxLength(10);

                entity.Property(e => e.ApplicationType).HasMaxLength(1);

                entity.Property(e => e.ReleasedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<View_15>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_15");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<View_2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_2");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OnMailRoutePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<View_3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_3");

                entity.Property(e => e.FromPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.MailRouteCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OnMailRoutePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<View_4>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_4");

                entity.Property(e => e.OnMailRoutePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<View_5>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_5");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.POSName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<View_717066_MailTrip>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_717066_MailTrip");

                entity.Property(e => e.CT)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<View_Acceptance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Acceptance");

                entity.Property(e => e.AcceptanceCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AdditionalDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.AdditionalDeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.AdditionalDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerGroupCode).HasMaxLength(20);

                entity.Property(e => e.DeliveryNote).HasMaxLength(500);

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemCodeCustomer).HasMaxLength(500);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ReasonModified).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerTel).HasMaxLength(15);

                entity.Property(e => e.ReceiverDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.ReceiverDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.RegionFreight).HasMaxLength(50);

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderCommuneCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullName).HasMaxLength(500);

                entity.Property(e => e.SenderIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.SenderProvinceCode).HasMaxLength(3);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(50);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingDate).HasMaxLength(8);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianToanTrinh).HasColumnType("datetime");

                entity.Property(e => e.TimerDelivery).HasColumnType("datetime");

                entity.Property(e => e.TracePOSCode).HasMaxLength(6);

                entity.Property(e => e.VPostCode).HasMaxLength(100);
            });

            modelBuilder.Entity<View_AllTables>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_AllTables");

                entity.Property(e => e.TABLE_CATALOG).HasMaxLength(128);

                entity.Property(e => e.TABLE_NAME)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TABLE_SCHEMA).HasMaxLength(128);

                entity.Property(e => e.TABLE_TYPE)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_BaoCaoSanLuong>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_BaoCaoSanLuong");

                entity.Property(e => e.PhamVi)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SendingTime).HasMaxLength(4000);
            });

            modelBuilder.Entity<View_CompareRequestAcceptance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CompareRequestAcceptance");

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.CustomerAddress).HasMaxLength(500);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(50);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<View_HCM_All>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HCM_All");

                entity.Property(e => e.Expr1).HasMaxLength(108);

                entity.Property(e => e.POSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<View_HCM_BK>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HCM_BK");

                entity.Property(e => e.Expr1).HasMaxLength(108);

                entity.Property(e => e.POSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<View_HCM_GS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HCM_GS");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.POSName).HasMaxLength(108);
            });

            modelBuilder.Entity<View_HCM_KT1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HCM_KT1");

                entity.Property(e => e.Expr1).HasMaxLength(108);

                entity.Property(e => e.POSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<View_Item_ToanTrinh>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Item_ToanTrinh");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ToiHuyen).HasMaxLength(4);

                entity.Property(e => e.ToiTinh).HasMaxLength(3);

                entity.Property(e => e.Tu).HasMaxLength(4);
            });

            modelBuilder.Entity<View_LK_BCUT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_BCUT");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_LK_BK_QT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_BK_QT");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_LK_BK_TN>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_BK_TN");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_LK_GS_QT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_GS_QT");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_LK_GS_TN>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_GS_TN");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_LK_KT1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LK_KT1");

                entity.Property(e => e.A)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_Mailtrip_Incoming>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Mailtrip_Incoming");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DestinationName).HasMaxLength(100);

                entity.Property(e => e.DestinationProvinceCode).HasMaxLength(3);

                entity.Property(e => e.InitialBy).HasMaxLength(50);

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachine).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBy).HasMaxLength(50);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDateOnly).HasMaxLength(8);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackagingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingDateOnly).HasMaxLength(8);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.ShiftName).HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StartingName).HasMaxLength(100);

                entity.Property(e => e.StartingProvinceCode).HasMaxLength(3);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<View_Mailtrip_Incoming_AdditionalInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Mailtrip_Incoming_AdditionalInfo");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DestinationName).HasMaxLength(100);

                entity.Property(e => e.InitialBy).HasMaxLength(50);

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachine).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBy).HasMaxLength(50);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDateOnly).HasMaxLength(8);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackagingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingDateOnly).HasMaxLength(8);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StartingName).HasMaxLength(100);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<View_Mailtrip_Incoming_Dispatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Mailtrip_Incoming_Dispatch");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<View_Mailtrip_Outgoing>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Mailtrip_Outgoing");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DestinationName).HasMaxLength(100);

                entity.Property(e => e.DestinationProvinceCode).HasMaxLength(3);

                entity.Property(e => e.InitialBy).HasMaxLength(50);

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachine).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBy).HasMaxLength(50);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDateOnly).HasMaxLength(8);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackagingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingDateOnly).HasMaxLength(8);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StartingName).HasMaxLength(100);

                entity.Property(e => e.StartingProvinceCode).HasMaxLength(3);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<View_Mailtrip_Outgoing_Dispatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Mailtrip_Outgoing_Dispatch");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<View_Offline_BK>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_BK");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_BK_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_BK_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_GS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_GS");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_GS_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_GS_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_BK>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_BK");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_BK_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_BK_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_GS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_GS");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_GS_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_GS_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_UT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_UT");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_TT_UT_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_TT_UT_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_UT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_UT");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_Offline_UT_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Offline_UT_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<View_PosExternal>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_PosExternal");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.POSName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<View_PosFull>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_PosFull");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PosName).HasMaxLength(200);
            });

            modelBuilder.Entity<View_PostBagEmpty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_PostBagEmpty");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PostBagTypeCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.PostBagTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReturnPOSCode).HasMaxLength(6);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<View_RequestAccepted>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_RequestAccepted");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PostmanApprovedBy).HasMaxLength(50);

                entity.Property(e => e.PostmanApprovedContent).HasMaxLength(500);

                entity.Property(e => e.PostmanApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerTel).HasMaxLength(15);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.ReceiverPOSCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.RequestCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RequestContent).HasMaxLength(500);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderCommuneCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(50);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullName).HasMaxLength(500);

                entity.Property(e => e.SenderIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.SenderProvinceCode).HasMaxLength(3);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(50);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TellersApprovedBy).HasMaxLength(50);

                entity.Property(e => e.TellersApprovedContent).HasMaxLength(500);

                entity.Property(e => e.TellersApprovedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<View_Tinh_BCUT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BCUT");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BCUT_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BCUT_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BK>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BK");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BK_QT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BK_QT");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BK_QT_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BK_QT_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BK_TN>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BK_TN");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_BK_TN_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_BK_TN_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_GS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_GS");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_GS_QT>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_GS_QT");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_GS_QT_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_GS_QT_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_GS_TN>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_GS_TN");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_GS_TN_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_GS_TN_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_KT1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_KT1");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_KT11>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_KT11");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_Tinh_KT11_LastDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Tinh_KT11_LastDay");

                entity.Property(e => e.ProvinceCode).HasMaxLength(3);
            });

            modelBuilder.Entity<View_TraCuu_ToanTrinh>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_TraCuu_ToanTrinh");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AcceptanceProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ArCode).HasMaxLength(13);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryUser).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.LastPosCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.RealReciverName).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianToanTrinh).HasColumnType("datetime");

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<View_TraCuu_ToanTrinh_Report>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_TraCuu_ToanTrinh_Report");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AcceptanceProvinceCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ArCode).HasMaxLength(13);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryUser).HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.LastPosCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.RealReciverName).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverProvinceCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianToanTrinh).HasColumnType("datetime");

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<View_TraceItemLast>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_TraceItemLast");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemCodeCustomer).HasMaxLength(500);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverDistrictName).HasMaxLength(100);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverProvinceName).HasMaxLength(100);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SenderFullName).HasMaxLength(500);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<View_sp_BaoCaoChuyenThuNoiTinh>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_sp_BaoCaoChuyenThuNoiTinh");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BCChapNhan).HasMaxLength(6);

                entity.Property(e => e.ConfirmContent).HasMaxLength(500);

                entity.Property(e => e.ConfirmTime).HasColumnType("datetime");

                entity.Property(e => e.ConfirmUserName).HasMaxLength(50);

                entity.Property(e => e.DestinationProvice)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.GivingFullName).HasMaxLength(500);

                entity.Property(e => e.GivingUserName).HasMaxLength(50);

                entity.Property(e => e.HandoverTime).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackingTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RecevingFullName).HasMaxLength(500);

                entity.Property(e => e.RecevingUserName).HasMaxLength(50);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.StartDate).HasMaxLength(8);

                entity.Property(e => e.StartMonth).HasMaxLength(6);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StartYear).HasMaxLength(4);

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StartingProvice)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<View_sp_GetUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_sp_GetUser");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CustomerCode).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(500);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.POSCode).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<View_sp_Report_Mailtrip_Incoming>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_sp_Report_Mailtrip_Incoming");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedContent).HasMaxLength(500);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DestinationName).HasMaxLength(100);

                entity.Property(e => e.DestinationProvinceCode).HasMaxLength(3);

                entity.Property(e => e.InitialBy).HasMaxLength(50);

                entity.Property(e => e.InitialDate).HasColumnType("datetime");

                entity.Property(e => e.InitialMachine).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningBy).HasMaxLength(50);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDateOnly).HasMaxLength(8);

                entity.Property(e => e.OpeningMachine).HasMaxLength(50);

                entity.Property(e => e.PackagingBy).HasMaxLength(50);

                entity.Property(e => e.PackagingDate).HasColumnType("datetime");

                entity.Property(e => e.PackagingDateOnly).HasMaxLength(8);

                entity.Property(e => e.PackagingMachine).HasMaxLength(50);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ShiftCode).HasMaxLength(1);

                entity.Property(e => e.ShiftHandoverDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftName).HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StartingCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.StartingName).HasMaxLength(100);

                entity.Property(e => e.StartingProvinceCode).HasMaxLength(3);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Warning>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.WarningContent).HasMaxLength(2500);
            });

            modelBuilder.Entity<WebsiteSupport>(entity =>
            {
                entity.HasKey(e => e.WebsiteName);

                entity.Property(e => e.WebsiteName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<WholeQualityTarget>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.QualityTargetRuleCode, e.TrasportTypeCode, e.RegionTypeCode });

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.QualityTargetRuleCode).HasMaxLength(5);

                entity.Property(e => e.TrasportTypeCode).HasMaxLength(1);

                entity.Property(e => e.RegionTypeCode).HasMaxLength(1);

                entity.HasOne(d => d.RegionTypeCodeNavigation)
                    .WithMany(p => p.WholeQualityTarget)
                    .HasForeignKey(d => d.RegionTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WholeQualityTarget_RegionType");

                entity.HasOne(d => d.TrasportTypeCodeNavigation)
                    .WithMany(p => p.WholeQualityTarget)
                    .HasForeignKey(d => d.TrasportTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WholeQualityTarget_TransportType");

                entity.HasOne(d => d.QualityTargetRule)
                    .WithMany(p => p.WholeQualityTarget)
                    .HasForeignKey(d => new { d.QualityTargetRuleCode, d.ServiceCode })
                    .HasConstraintName("FK_WholeQualityTarget_QualityTargetRule");
            });

            modelBuilder.Entity<bcn_Commissiontodelivery_LevelWeight>(entity =>
            {
                entity.HasKey(e => e.Levelweight)
                    .HasName("PK_bcn_LevelWeight");
            });

            modelBuilder.Entity<bcn_Commissiontodelivery_SubOffice>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<bcn_commissiontodelivery>(entity =>
            {
                entity.Property(e => e.IsSubOffice).HasComment("0:Không có văn phòng hoặc chi nhánh;1:Có văn phòng hoặc chi nhánh");

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Region).HasComment("1: EMS Nội tỉnh; 2: EMS Liên tỉnh; 3: EMS Quốc tế");

                entity.Property(e => e.VASICode)
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<bcn_commissiontodeliveryspecial>(entity =>
            {
                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<sp_BangKe_BuuGui_ChuyenPhat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sp_BangKe_BuuGui_ChuyenPhat");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CoQuanGui).HasMaxLength(100);

                entity.Property(e => e.CoQuanNhan).HasMaxLength(100);

                entity.Property(e => e.CommuneCode).HasMaxLength(6);

                entity.Property(e => e.CommuneName).HasMaxLength(50);

                entity.Property(e => e.DistrictCode).HasMaxLength(4);

                entity.Property(e => e.DistrictName).HasMaxLength(100);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SendingDate).HasMaxLength(8);

                entity.Property(e => e.ShiftHandoverDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ToPOSCode).HasMaxLength(6);
            });

            modelBuilder.Entity<temptmp_Item_0312>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AcceptanceCode).HasMaxLength(50);

                entity.Property(e => e.AcceptancePOSCode).HasMaxLength(6);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerGroupCode).HasMaxLength(20);

                entity.Property(e => e.DeliveryNote).HasMaxLength(500);

                entity.Property(e => e.DeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.DeliveryPointCustomerCode).HasMaxLength(17);

                entity.Property(e => e.DeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.DestinationPOSCode).HasMaxLength(6);

                entity.Property(e => e.ItemCode).HasMaxLength(13);

                entity.Property(e => e.ItemCodeCustomer).HasMaxLength(500);

                entity.Property(e => e.ItemTypeCode).HasMaxLength(3);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ReasonModified).HasMaxLength(500);

                entity.Property(e => e.ReceiverAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCommuneCode).HasMaxLength(6);

                entity.Property(e => e.ReceiverContact).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerAddress).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerCode).HasMaxLength(17);

                entity.Property(e => e.ReceiverCustomerName).HasMaxLength(500);

                entity.Property(e => e.ReceiverCustomerTel).HasMaxLength(15);

                entity.Property(e => e.ReceiverDeliveryPointCode).HasMaxLength(10);

                entity.Property(e => e.ReceiverDeliveryPointName).HasMaxLength(250);

                entity.Property(e => e.ReceiverDistrictCode).HasMaxLength(4);

                entity.Property(e => e.ReceiverEmail).HasMaxLength(50);

                entity.Property(e => e.ReceiverFax).HasMaxLength(15);

                entity.Property(e => e.ReceiverFullName).HasMaxLength(500);

                entity.Property(e => e.ReceiverIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.ReceiverProvinceCode).HasMaxLength(3);

                entity.Property(e => e.ReceiverTaxCode).HasMaxLength(50);

                entity.Property(e => e.ReceiverTel).HasMaxLength(15);

                entity.Property(e => e.RegionFreight).HasMaxLength(50);

                entity.Property(e => e.SenderAddress).HasMaxLength(500);

                entity.Property(e => e.SenderCommuneCode).HasMaxLength(6);

                entity.Property(e => e.SenderCustomerCode).HasMaxLength(17);

                entity.Property(e => e.SenderDistrictCode).HasMaxLength(4);

                entity.Property(e => e.SenderEmail).HasMaxLength(50);

                entity.Property(e => e.SenderFax).HasMaxLength(15);

                entity.Property(e => e.SenderFullName).HasMaxLength(500);

                entity.Property(e => e.SenderIdentifyNumber).HasMaxLength(20);

                entity.Property(e => e.SenderProvinceCode).HasMaxLength(3);

                entity.Property(e => e.SenderTaxCode).HasMaxLength(50);

                entity.Property(e => e.SenderTel).HasMaxLength(15);

                entity.Property(e => e.SendingDate).HasMaxLength(8);

                entity.Property(e => e.SendingTime).HasColumnType("datetime");

                entity.Property(e => e.ServiceCode).HasMaxLength(2);

                entity.Property(e => e.ThoiGianToanTrinh).HasColumnType("datetime");

                entity.Property(e => e.TimerDelivery).HasColumnType("datetime");

                entity.Property(e => e.TracePOSCode).HasMaxLength(6);

                entity.Property(e => e.VPostCode).HasMaxLength(100);
            });

            modelBuilder.Entity<tmp_Transport>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.POSCode).HasMaxLength(6);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransportCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransportGroup)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<vSelectItemsByBatchCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSelectItemsByBatchCode");

                entity.Property(e => e.AcceptancePOSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AcceptancePOSName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryPOSName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ToPOSCode)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<vSelectUserBelongGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSelectUserBelongGroup");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.POSCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
