using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimCompensateRule
    {
        public ClaimCompensateRule()
        {
            ClaimCompensate = new HashSet<ClaimCompensate>();
        }

        public string ClaimCompensateRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public DateTime? ValueDate { get; set; }
        public string RuleNo { get; set; }
        public bool? IsDomestic { get; set; }
        public string CompensateCategoryCode { get; set; }
        public string CompensateResultCode { get; set; }
        public string ExchangeRateCode { get; set; }
        public double? VAT { get; set; }
        public bool? HasVAT { get; set; }
        public string TransportTypeCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string CompensateItemFreightSentFormula { get; set; }
        public string CompensateFreightFormula { get; set; }
        public string CompensateFreightMaxFormula { get; set; }
        public string CompensateFreightMinFormula { get; set; }

        public virtual ICollection<ClaimCompensate> ClaimCompensate { get; set; }
    }
}
