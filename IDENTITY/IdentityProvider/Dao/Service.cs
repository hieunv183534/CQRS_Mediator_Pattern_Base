using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Service
    {
        public Service()
        {
            ClaimItem = new HashSet<ClaimItem>();
            CollectionFreightStep = new HashSet<CollectionFreightStep>();
            Deduction = new HashSet<Deduction>();
            DeliveryRouteService = new HashSet<DeliveryRouteService>();
            DomesticCompensateRule = new HashSet<DomesticCompensateRule>();
            DomesticServiceSurchange = new HashSet<DomesticServiceSurchange>();
            ExchangeRelationship = new HashSet<ExchangeRelationship>();
            Item = new HashSet<Item>();
            LetterMoneyOrderRule = new HashSet<LetterMoneyOrderRule>();
            LimitWeight = new HashSet<LimitWeight>();
            MailRouteService = new HashSet<MailRouteService>();
            Mailtrip = new HashSet<Mailtrip>();
            MenuService = new HashSet<MenuService>();
            POSService = new HashSet<POSService>();
            PostBagType = new HashSet<PostBagType>();
            QualityTargetRule = new HashSet<QualityTargetRule>();
            RevenueSharingRule = new HashSet<RevenueSharingRule>();
            ServiceCommodityType = new HashSet<ServiceCommodityType>();
            ServiceConfiguration = new HashSet<ServiceConfiguration>();
            ServiceItemType = new HashSet<ServiceItemType>();
            ServicePOSConfiguration = new HashSet<ServicePOSConfiguration>();
            ServicePhase = new HashSet<ServicePhase>();
            ServiceProperty = new HashSet<ServiceProperty>();
            ServiceSaleChannel = new HashSet<ServiceSaleChannel>();
            VASUsing = new HashSet<VASUsing>();
        }

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
        public string ShortcutKey { get; set; }
        public int? OrderIndex { get; set; }
        public string ServiceNameSearch { get; set; }

        public virtual ServicePriority ServicePriorityCodeNavigation { get; set; }
        public virtual ServiceType ServiceTypeCodeNavigation { get; set; }
        public virtual ICollection<ClaimItem> ClaimItem { get; set; }
        public virtual ICollection<CollectionFreightStep> CollectionFreightStep { get; set; }
        public virtual ICollection<Deduction> Deduction { get; set; }
        public virtual ICollection<DeliveryRouteService> DeliveryRouteService { get; set; }
        public virtual ICollection<DomesticCompensateRule> DomesticCompensateRule { get; set; }
        public virtual ICollection<DomesticServiceSurchange> DomesticServiceSurchange { get; set; }
        public virtual ICollection<ExchangeRelationship> ExchangeRelationship { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<LetterMoneyOrderRule> LetterMoneyOrderRule { get; set; }
        public virtual ICollection<LimitWeight> LimitWeight { get; set; }
        public virtual ICollection<MailRouteService> MailRouteService { get; set; }
        public virtual ICollection<Mailtrip> Mailtrip { get; set; }
        public virtual ICollection<MenuService> MenuService { get; set; }
        public virtual ICollection<POSService> POSService { get; set; }
        public virtual ICollection<PostBagType> PostBagType { get; set; }
        public virtual ICollection<QualityTargetRule> QualityTargetRule { get; set; }
        public virtual ICollection<RevenueSharingRule> RevenueSharingRule { get; set; }
        public virtual ICollection<ServiceCommodityType> ServiceCommodityType { get; set; }
        public virtual ICollection<ServiceConfiguration> ServiceConfiguration { get; set; }
        public virtual ICollection<ServiceItemType> ServiceItemType { get; set; }
        public virtual ICollection<ServicePOSConfiguration> ServicePOSConfiguration { get; set; }
        public virtual ICollection<ServicePhase> ServicePhase { get; set; }
        public virtual ICollection<ServiceProperty> ServiceProperty { get; set; }
        public virtual ICollection<ServiceSaleChannel> ServiceSaleChannel { get; set; }
        public virtual ICollection<VASUsing> VASUsing { get; set; }
    }
}
