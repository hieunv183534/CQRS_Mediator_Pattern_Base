using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class FeedBack
    {
        public long FeedBackId { get; set; }
        public string FeedBackName { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Attchment { get; set; }
    }
}
