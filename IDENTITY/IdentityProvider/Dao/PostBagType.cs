using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PostBagType
    {
        public PostBagType()
        {
            MailtripPostBagEmpty = new HashSet<MailtripPostBagEmpty>();
            PostBag = new HashSet<PostBag>();
            PostBagEmpty = new HashSet<PostBagEmpty>();
            PostBagEmptyInventory = new HashSet<PostBagEmptyInventory>();
        }

        public string PostBagTypeCode { get; set; }
        public string PostBagTypeName { get; set; }
        public string Description { get; set; }
        public string ServiceCode { get; set; }
        public bool? IsPostBag { get; set; }
        public byte? Type { get; set; }
        public int? OrderIndex { get; set; }
        public double? CaseWeight { get; set; }
        public double? MaximumWeight { get; set; }
        public string PostBagTypeNameSearch { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<MailtripPostBagEmpty> MailtripPostBagEmpty { get; set; }
        public virtual ICollection<PostBag> PostBag { get; set; }
        public virtual ICollection<PostBagEmpty> PostBagEmpty { get; set; }
        public virtual ICollection<PostBagEmptyInventory> PostBagEmptyInventory { get; set; }
    }
}
