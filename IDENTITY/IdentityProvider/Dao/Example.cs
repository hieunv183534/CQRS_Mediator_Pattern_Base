using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Example
    {
        public long Id { get; set; }
        public string ColText { get; set; }
        public long? ColNumber { get; set; }
        public double? ColFloat { get; set; }
        public bool? ColCheckBox { get; set; }
        public int? ColRadioBox { get; set; }
        public DateTime? ColDate { get; set; }
        public DateTime? ColDateTime { get; set; }
        public string ColTextArea { get; set; }
        public string ColSelectMulti { get; set; }
        public int? ColSelectSingle { get; set; }
        public string ColDateString { get; set; }
    }
}
