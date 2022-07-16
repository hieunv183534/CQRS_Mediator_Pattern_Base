using NOM.DomainGlobal._Base.Extentions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace NOM.DomainGlobal._Base.Models
{

    public interface IPagingModel
    {
        long? Count { get; set; }
        int? Page { get; set; }
        int? Size { get; set; }
        bool? LoadMore { get; set; }
        Dictionary<string, bool> Order { get; set; }
    }

    public class PagingModel : IPagingModel
    {
        public long? Count { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
        public bool? LoadMore { get; set; } = false;
        public Dictionary<string, bool> Order { get; set; }
    }

    public class BasePagingModel : IPagingModel
    {

        public object Where { get; set; }

        [OpenApiIgnore]
        public JObject WhereLoopBack
        {
            get
            {
                return Where != null ? JObject.Parse(System.Text.Json.JsonSerializer.Serialize(Where)) : null;
            }
        }

        public object Select { get; set; }

        [OpenApiIgnore]
        public JObject SelectLoopBack
        {
            get
            {
                return Select != null ? JObject.Parse(System.Text.Json.JsonSerializer.Serialize(Select)) : null;
            }
        }

        public Dictionary<string, bool> Order { get; set; }

        [OpenApiIgnore]
        public JObject OrderLoopBack
        {
            get
            {
                if (Order == null) return null;
                return JObject.FromObject(Order);
            }
        }

        public int? Page { get; set; }

        public int? Size { get; set; }

        public long? Count { get; set; }

        public bool? LoadMore { get; set; } = false;
    }

    public class BaseWhereModel
    {
        public object Where { get; set; }

        [OpenApiIgnore]
        public JObject WhereLoopBack
        {
            get
            {
                return Where != null ? JObject.Parse(System.Text.Json.JsonSerializer.Serialize(Where)) : null;
            }
        }

        public object Select { get; set; }

        [OpenApiIgnore]
        public JObject SelectLoopBack
        {
            get
            {
                return Select != null ? JObject.Parse(System.Text.Json.JsonSerializer.Serialize(Select)) : null;
            }
        }

        public Dictionary<string, bool> Order { get; set; }

        [OpenApiIgnore]
        public JObject OrderLoopBack
        {
            get
            {
                if (Order == null) return null;
                return JObject.FromObject(Order);
            }
        }
    }

    public class PagingResultModel<T>
    {
        public List<T> Data { get; set; }

        public PagingModel Paging { get; set; }
    }

    public class ComboboxModel<T>
    {
        public T Value { get; set; }

        public string Text { get; set; }

        public T Parent { get; set; }
    }
}
