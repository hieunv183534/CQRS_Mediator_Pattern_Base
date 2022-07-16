using System;
using System.Collections.Generic;

namespace NOM.Dao.Entities
{
    public partial class CategoryCode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal MaxCodeLevel { get; set; }
        public string Comma { get; set; }
        public bool Rtl { get; set; }
    }
}
