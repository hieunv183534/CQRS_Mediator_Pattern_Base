using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class LetterMoneyOrder
    {
        public string LetterMoneyOrderCode { get; set; }
        public double? FromMoney { get; set; }
        public double? ToMoney { get; set; }
        public double? FreightLevel { get; set; }
        public double? PercentLevel { get; set; }
        public double? MinimumMoney { get; set; }
        public string LetterMoneyOrderRuleCode { get; set; }
        public double? FreightStep { get; set; }
        public byte? CalculationMethod { get; set; }
        public string ServiceCode { get; set; }

        public virtual LetterMoneyOrderRule LetterMoneyOrderRule { get; set; }
    }
}
