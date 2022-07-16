using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NOM.DomainGlobal._Base.Extentions
{
    public static class JsonExtention
    {
        public static string JsonToString<T>(this T source, bool fixMSSQL = true)
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(source);
            if (fixMSSQL)
            {
                result = result.Replace("'", "''");
            }
            return result;
        }

        public static JObject JsonToObject(this string source)
        {
            if (source != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(source);
            }
            else
            {
                return default(JObject);
            }
        }

        public static T JsonToObject<T>(this string source)
        {
            if (source != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(source);
            }
            else
            {
                return default(T);
            }
        }

        public static JObject JsonToObject(this JObject source, string keyName)
        {
            if (source != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(source.Value<string>(keyName));
            }
            else
            {
                return default(JObject);
            }
        }

        public static T JsonToObject<T>(this JObject source, string keyName)
        {
            if (source != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(source.Value<string>(keyName));
            }
            else
            {
                return default(T);
            }
        }            

        public static IDictionary<string, object> ToDictionary(this JObject json)
        {
            var propertyValuePairs = json.ToObject<Dictionary<string, object>>();
            ProcessJObjectProperties(propertyValuePairs);
            ProcessJArrayProperties(propertyValuePairs);
            return propertyValuePairs;
        }

        private static void ProcessJObjectProperties(IDictionary<string, object> propertyValuePairs)
        {
            var objectPropertyNames = (from property in propertyValuePairs
                                       let propertyName = property.Key
                                       let value = property.Value
                                       where value is JObject
                                       select propertyName).ToList();

            objectPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToDictionary((JObject)propertyValuePairs[propertyName]));
        }

        private static void ProcessJArrayProperties(IDictionary<string, object> propertyValuePairs)
        {
            var arrayPropertyNames = (from property in propertyValuePairs
                                      let propertyName = property.Key
                                      let value = property.Value
                                      where value is JArray
                                      select propertyName).ToList();

            arrayPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToArray((JArray)propertyValuePairs[propertyName]));
        }

        public static object[] ToArray(this JArray array)
        {
            return array.ToObject<object[]>().Select(ProcessArrayEntry).ToArray();
        }

        private static object ProcessArrayEntry(object value)
        {
            if (value is JObject)
            {
                return ToDictionary((JObject)value);
            }
            if (value is JArray)
            {
                return ToArray((JArray)value);
            }
            return value;
        }

        public static bool HaveWhereStatusDb(this JObject source)
        {
            if (source.ContainsKey("and") || source.ContainsKey("or"))
            {
                var key = source.ContainsKey("and") ? "and" : "or";
                var value = source.GetValue(key) as JArray;
                var checkHaveWhereStatus = false;
                foreach (JObject item in value)
                {
                   if(item.HaveWhereStatusDb()) checkHaveWhereStatus = true;
                }
                return checkHaveWhereStatus;
            }
            else
            {
                return source.ContainsKey("dataDb.status");
            }
        }
    }
}
