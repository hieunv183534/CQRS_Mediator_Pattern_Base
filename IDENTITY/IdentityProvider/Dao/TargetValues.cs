using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TargetValues
    {
        public string TargetCode { get; set; }
        public double Quantity { get; set; }
        public double? Revenue { get; set; }
        public double? Cash { get; set; }
        public double? Debt { get; set; }
        public double? Paid { get; set; }
        public double? VAT { get; set; }
        public double? Out { get; set; }
        public double? In { get; set; }
        public string POSCode { get; set; }
        public string InsertDate { get; set; }
        public bool? IsLast { get; set; }
        public double? Invoice { get; set; }
        public double? NotInvoice { get; set; }
        public double? VATPercent { get; set; }
        public double? Delivery { get; set; }
        public double? POSDebt { get; set; }

        public virtual Targets TargetCodeNavigation { get; set; }
    }
}
