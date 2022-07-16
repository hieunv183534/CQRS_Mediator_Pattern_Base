using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemType
    {
        public ItemType()
        {
            DeductionDetail = new HashSet<DeductionDetail>();
            DomesticFreightRuleItemTypeUsing = new HashSet<DomesticFreightRuleItemTypeUsing>();
            DomesticFreightStep = new HashSet<DomesticFreightStep>();
            Item = new HashSet<Item>();
            RequestAcceptedConfirm = new HashSet<RequestAcceptedConfirm>();
            RequestAcceptedDetail = new HashSet<RequestAcceptedDetail>();
            ServiceItemType = new HashSet<ServiceItemType>();
        }

        public string ItemTypeCode { get; set; }
        public string ItemTypeName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public string ShortName { get; set; }
        public bool? Special { get; set; }
        public string ItemTypeNameSearch { get; set; }

        public virtual ICollection<DeductionDetail> DeductionDetail { get; set; }
        public virtual ICollection<DomesticFreightRuleItemTypeUsing> DomesticFreightRuleItemTypeUsing { get; set; }
        public virtual ICollection<DomesticFreightStep> DomesticFreightStep { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<RequestAcceptedConfirm> RequestAcceptedConfirm { get; set; }
        public virtual ICollection<RequestAcceptedDetail> RequestAcceptedDetail { get; set; }
        public virtual ICollection<ServiceItemType> ServiceItemType { get; set; }
    }
}
