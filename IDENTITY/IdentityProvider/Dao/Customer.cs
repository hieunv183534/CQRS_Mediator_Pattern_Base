using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Customer
    {
        public Customer()
        {
            CauseCustomer = new HashSet<CauseCustomer>();
            CustomerObject = new HashSet<CustomerObject>();
            DeliveryPoint = new HashSet<DeliveryPoint>();
            ItemReceiverCustomerCodeNavigation = new HashSet<Item>();
            ItemSenderCustomerCodeNavigation = new HashSet<Item>();
            ObjectSender = new HashSet<ObjectSender>();
            OnlineOrder = new HashSet<OnlineOrder>();
            Order = new HashSet<Order>();
            Payment = new HashSet<Payment>();
            SolutionCustomer = new HashSet<SolutionCustomer>();
        }

        public string CustomerCode { get; set; }
        public string POSCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string IdentificationNumber { get; set; }
        public string Note { get; set; }
        public string CustomerNameSearch { get; set; }
        public bool? IsSender { get; set; }
        public bool? IsReceive { get; set; }

        public virtual ICollection<CauseCustomer> CauseCustomer { get; set; }
        public virtual ICollection<CustomerObject> CustomerObject { get; set; }
        public virtual ICollection<DeliveryPoint> DeliveryPoint { get; set; }
        public virtual ICollection<Item> ItemReceiverCustomerCodeNavigation { get; set; }
        public virtual ICollection<Item> ItemSenderCustomerCodeNavigation { get; set; }
        public virtual ICollection<ObjectSender> ObjectSender { get; set; }
        public virtual ICollection<OnlineOrder> OnlineOrder { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<SolutionCustomer> SolutionCustomer { get; set; }
    }
}
