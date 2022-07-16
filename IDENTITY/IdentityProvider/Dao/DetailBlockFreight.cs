using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailBlockFreight
    {
        public int Id { get; set; }
        public int DomesticFreightStepId { get; set; }
        public int DomesticFreightBlockId { get; set; }
        public double? Freight { get; set; }

        public virtual DomesticFreightBlock DomesticFreightBlock { get; set; }
        public virtual DomesticFreightStep DomesticFreightStep { get; set; }
    }
}
