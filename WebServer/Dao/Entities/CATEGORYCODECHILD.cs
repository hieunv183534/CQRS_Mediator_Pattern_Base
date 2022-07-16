using System;
using System.Collections.Generic;

namespace NOM.Dao.Entities
{
    public partial class CategoryCodeChild
    {
        public string CategoryCodeId { get; set; }
        public byte CodeLevel { get; set; }
        public string DefaultValue { get; set; }
        public string CategoryId { get; set; }
        public byte MinLength { get; set; }
        public byte MaxLength { get; set; }
        public string Regex { get; set; }
        public string RegexMessage { get; set; }
        public bool GenerateCode { get; set; }
        public bool Reference { get; set; }
    }
}
