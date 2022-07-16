using Newtonsoft.Json.Linq;
using NSwag.Annotations;
using System.Collections.Generic;

namespace NOM._Base.Models
{
    public interface IPagingModel
    {
        long? Count { get; set; }
        int? Page { get; set; }
        int? Size { get; set; }
        Dictionary<string, bool> Order { get; set; }
        bool? LoadMore { get; set; }
    }

    public record PagingModel : IPagingModel
    {
        public long? Count { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
        public Dictionary<string, bool> Order { get; set; }

        public bool? LoadMore { get; set; }
    }

    public record BasePagingModel : IPagingModel
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

        public bool? LoadMore { get; set; }
    }

    public record BaseWhereModel
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

    public record PagingResultModel<T>
    {
        public List<T> Data { get; set; }

        public PagingModel Paging { get; set; }
    }

    public record ComboboxModel<T>
    {
        public T Value { get; set; }

        public string Text { get; set; }

        public T Parent { get; set; }
    }
}