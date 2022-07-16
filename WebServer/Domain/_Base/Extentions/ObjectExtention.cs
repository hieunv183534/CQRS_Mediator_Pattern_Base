using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace NOM.Domain._Base.Extentions
{
    public static class ObjectExtention
    {
        public static T MapToObject<T>(this object source)
        {
            return JObject.FromObject(source).ToObject<T>();
        }

        public static T MapToArray<T>(this object source)
        {
            return JArray.FromObject(source).ToObject<T>();
        }

        public static T Patch<T>(this T objectValue, object formSource)
        {
            var source = JObject.FromObject(objectValue);
            var result = JObject.FromObject(formSource);
            foreach (var pr in result)
            {
                if (source.ContainsKey(pr.Key))
                {
                    SetValueObject(pr, source);
                }
            }
            return source.ToObject<T>();
        }

        private static void SetValueObject(this KeyValuePair<string, JToken> pr, JObject result)
        {
            if (pr.Value.Type == JTokenType.Object)
            {
                if (pr.Value == null)
                {
                    result[pr.Key] = pr.Value;
                    return;
                }
                foreach (var item in pr.Value as JObject)
                {
                    if (result.Value<JObject>(pr.Key) == null)
                    {
                        result[pr.Key] = pr.Value;
                    }
                    else if (result.Value<JObject>(pr.Key).ContainsKey(item.Key))
                    {
                        SetValueObject(item, result.Value<JObject>(pr.Key));
                    }
                }
            }
            else
            {
                result[pr.Key] = pr.Value;
            }
        }
    }
}