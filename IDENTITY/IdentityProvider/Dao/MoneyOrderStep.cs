using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MoneyOrderStep
    {
        public string MoneyOrderRuleCode { get; set; }
        public double FromMoney { get; set; }
        public double ToMoney { get; set; }
        public double Freight { get; set; }
        public byte CalculationMethod { get; set; }
        public double MinimumFreight { get; set; }
        public string MoneyOrderStepCode { get; set; }
        public bool? isBatch { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ServiceCode { get; set; }
        public double? FreightStep { get; set; }

        public virtual MoneyOrderRule MoneyOrderRule { get; set; }
    }
}
