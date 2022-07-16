using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeleteParameter
    {
        public string MessageTypeName { get; set; }
        public string TableName { get; set; }
        public string DeleteParameterName { get; set; }
        public string DataType { get; set; }
    }
}
