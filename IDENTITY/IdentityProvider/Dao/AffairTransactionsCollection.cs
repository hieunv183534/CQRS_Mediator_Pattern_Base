using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairTransactionsCollection
    {
        public int AffairTransactionsCollection1 { get; set; }
        public int? AffairIndex { get; set; }
        public string TransactionsCollectionCode { get; set; }
        public string ItemCode { get; set; }
        public string POSCode { get; set; }
        public DateTime? TransactionsCollectionDate { get; set; }
        public string TransactionsCollectionChannel { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverTel { get; set; }
        public int? ReceiverCertificateType { get; set; }
        public string ReceiverCertificateNumber { get; set; }
        public DateTime? ReceiverCertificateIssueDate { get; set; }
        public string ReceiverCertificatePlace { get; set; }
        public string ReceiverCertificateOtherName { get; set; }
        public string Note { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
