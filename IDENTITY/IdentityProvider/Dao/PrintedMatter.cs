using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PrintedMatter
    {
        public PrintedMatter()
        {
            PrintedMatterMachine = new HashSet<PrintedMatterMachine>();
        }

        public string PrintedMatterCode { get; set; }
        public string PrintedMatterName { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? OrderIndex { get; set; }

        public virtual ICollection<PrintedMatterMachine> PrintedMatterMachine { get; set; }
    }
}
