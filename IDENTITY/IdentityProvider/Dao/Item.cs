using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Item
    {
        public Item()
        {
            ClaimItem = new HashSet<ClaimItem>();
            Delivery = new HashSet<Delivery>();
            Dispatch = new HashSet<Dispatch>();
            ItemExclude = new HashSet<ItemExclude>();
            ItemInventory = new HashSet<ItemInventory>();
            ItemVASFreight = new HashSet<ItemVASFreight>();
            MailtripItem = new HashSet<MailtripItem>();
            ShiftHandoverItem = new HashSet<ShiftHandoverItem>();
            TraceItem = new HashSet<TraceItem>();
            ValueAddedServiceItem = new HashSet<ValueAddedServiceItem>();
        }

        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string AcceptanceCode { get; set; }
        public string ServiceCode { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string ItemCodeCustomer { get; set; }
        public string CustomerGroupCode { get; set; }
        public string SenderCustomerCode { get; set; }
        public string SenderFullName { get; set; }
        public string SenderProvinceCode { get; set; }
        public string SenderDistrictCode { get; set; }
        public string SenderCommuneCode { get; set; }
        public string SenderAddress { get; set; }
        public string SenderTel { get; set; }
        public string SenderEmail { get; set; }
        public string SenderFax { get; set; }
        public string SenderTaxCode { get; set; }
        public string SenderIdentifyNumber { get; set; }
        public long? SenderObjectID { get; set; }
        public string DeliveryPointCustomerCode { get; set; }
        public string DeliveryPointCode { get; set; }
        public string DeliveryPointName { get; set; }
        public string ReceiverDeliveryPointCode { get; set; }
        public string ReceiverDeliveryPointName { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverCustomerName { get; set; }
        public string ReceiverCustomerAddress { get; set; }
        public string ReceiverCustomerTel { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverProvinceCode { get; set; }
        public string ReceiverDistrictCode { get; set; }
        public string ReceiverCommuneCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverFax { get; set; }
        public string ReceiverTaxCode { get; set; }
        public string ReceiverIdentifyNumber { get; set; }
        public string ReceiverContact { get; set; }
        public bool? ReceiverProvinceCenter { get; set; }
        public bool? ReceiverDistrictCenter { get; set; }
        public long? ReceiverObjectID { get; set; }
        public string ItemTypeCode { get; set; }
        public DateTime? TimerDelivery { get; set; }
        public bool? Internal { get; set; }
        public double? Weight { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? WeightConvert { get; set; }
        public DateTime SendingTime { get; set; }
        public int? AcceptedType { get; set; }
        public byte? AcceptedStatus { get; set; }
        public int? AcceptedIndex { get; set; }
        public byte? UndeliveryGuideCode { get; set; }
        public string DeliveryNote { get; set; }
        public bool? Special { get; set; }
        public string AttachFile { get; set; }
        public string Note { get; set; }
        public long? RequestID { get; set; }
        public int? ItemNumberAcceptance { get; set; }
        public int? ItemNumberSecretAcceptance { get; set; }
        public int? ItemNumberPrioritizeAcceptance { get; set; }
        public string DestinationPOSCode { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? DiscountAmount { get; set; }
        public double? VATPercentage { get; set; }
        public double? MainFreight { get; set; }
        public double? VATFreight { get; set; }
        public double? SubFreight { get; set; }
        public double? FuelSurchargeFreight { get; set; }
        public double? FarRegionFreight { get; set; }
        public double? AirSurchargeFreight { get; set; }
        public double? OtherFreight { get; set; }
        public double? TotalFreightVAT { get; set; }
        public double? TotalFreightDiscount { get; set; }
        public double? TotalFreightDiscountVAT { get; set; }
        public double? PaymentFreight { get; set; }
        public double? PaymentFreightVAT { get; set; }
        public double? PaymentFreightDiscount { get; set; }
        public double? PaymentFreightDiscountVAT { get; set; }
        public double? RemainingFreightVAT { get; set; }
        public double? RemainingFreightDiscount { get; set; }
        public double? RemainingFreightDiscountVAT { get; set; }
        public double? OriginalMainFreight { get; set; }
        public double? OriginalSubFreight { get; set; }
        public double? OriginalFuelSurchargeFreight { get; set; }
        public double? OriginalFarRegionFreight { get; set; }
        public double? OriginalAirSurchargeFreight { get; set; }
        public double? OriginalVATFreight { get; set; }
        public double? OriginalVATPercentage { get; set; }
        public double? OriginalTotalFreight { get; set; }
        public double? OriginalTotalFreightVAT { get; set; }
        public double? OriginalTotalFreightDiscount { get; set; }
        public double? OriginalTotalFreightDiscountVAT { get; set; }
        public double? OriginalPaymentFreight { get; set; }
        public double? OriginalPaymentFreightVAT { get; set; }
        public double? OriginalPaymentFreightDiscount { get; set; }
        public double? OriginalPaymentFreightDiscountVAT { get; set; }
        public double? OriginalRemainingFreight { get; set; }
        public double? OriginalRemainingFreightVAT { get; set; }
        public double? OriginalRemainingFreightDiscount { get; set; }
        public double? OriginalRemainingFreightDiscountVAT { get; set; }
        public bool? InternalUpdated { get; set; }
        public string TracePOSCode { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public long? ItemIDOriginal { get; set; }
        public string ReasonModified { get; set; }
        public string VPostCode { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public DateTime? ThoiGianToanTrinh { get; set; }
        public string SendingDate { get; set; }
        public string RegionFreight { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedContent { get; set; }
        public string AdditionalDeliveryPointCode { get; set; }
        public string AdditionalDeliveryPointName { get; set; }
        public string AdditionalDeliveryPointCustomerCode { get; set; }
        public DateTime? DeliveryRateTime { get; set; }
        public int? DeliveryRateLevel { get; set; }
        public string DeliveryRateDesc { get; set; }

        public virtual POS AcceptancePOSCodeNavigation { get; set; }
        public virtual CustomerGroup CustomerGroupCodeNavigation { get; set; }
        public virtual ItemType ItemTypeCodeNavigation { get; set; }
        public virtual Commune ReceiverCommuneCodeNavigation { get; set; }
        public virtual Customer ReceiverCustomerCodeNavigation { get; set; }
        public virtual District ReceiverDistrictCodeNavigation { get; set; }
        public virtual Province ReceiverProvinceCodeNavigation { get; set; }
        public virtual RequestAccepted Request { get; set; }
        public virtual Customer SenderCustomerCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual UndeliveryGuide UndeliveryGuideCodeNavigation { get; set; }
        public virtual ItemReturn ItemReturn { get; set; }
        public virtual ICollection<ClaimItem> ClaimItem { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Dispatch> Dispatch { get; set; }
        public virtual ICollection<ItemExclude> ItemExclude { get; set; }
        public virtual ICollection<ItemInventory> ItemInventory { get; set; }
        public virtual ICollection<ItemVASFreight> ItemVASFreight { get; set; }
        public virtual ICollection<MailtripItem> MailtripItem { get; set; }
        public virtual ICollection<ShiftHandoverItem> ShiftHandoverItem { get; set; }
        public virtual ICollection<TraceItem> TraceItem { get; set; }
        public virtual ICollection<ValueAddedServiceItem> ValueAddedServiceItem { get; set; }
    }
}
