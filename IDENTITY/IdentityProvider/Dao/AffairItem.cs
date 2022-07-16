using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairItem
    {
        public Guid ItemID { get; set; }
        public int AffairIndex { get; set; }
        public string ItemCode { get; set; }
        public double? VATFreight { get; set; }
        public double? SubFreight { get; set; }
        public double? TotalFreight { get; set; }
        public double? TotalFreightVAT { get; set; }
        public double? TotalFreightDiscount { get; set; }
        public double? TotalFreightDiscountVAT { get; set; }
        public double? PaymentFreight { get; set; }
        public double? PaymentFreightVAT { get; set; }
        public double? PaymentFreightDiscount { get; set; }
        public double? PaymentFreightDiscountVAT { get; set; }
        public double? RemainingFreight { get; set; }
        public double? RemainingFreightVAT { get; set; }
        public double? RemainingFreightDiscount { get; set; }
        public double? RemainingFreightDiscountVAT { get; set; }
        public double? OriginalVATFreight { get; set; }
        public double? OriginalSubFreight { get; set; }
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
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
