using System;
using System.Collections.Generic;

namespace NOM.Common.Ultilities
{
    public static class HandleParentTag
    {
        private const string prefix = ",";

        public static string GenaretaParentTag(Object id)
        {
            return prefix + id.ToString() + prefix;
        }

        public static string GetParentTagBefore(string parentTag)
        {
            var myList = new List<string>(parentTag.Split(','));
            if (myList.Count - 1 < 2)
            {
                return "";
            }
            // xóa id cuối trong parentTag
            myList.RemoveAt(myList.Count - 1);
            myList.RemoveAt(myList.Count - 1);

            return String.Join(",", myList);
        }

        public static string ChangeIdInParentTag(string parentTag, Object id)
        {
            var myList = new List<string>(parentTag.Split(','));
            if (myList.Count - 1 < 2)
            {
                return prefix + id.ToString() + prefix;
            }
            // xóa id cuối trong parentTag
            myList.RemoveAt(myList.Count - 1);
            myList.RemoveAt(myList.Count - 1);

            // thêm id hiện tại vào cuối parentTag
            myList.Add(id.ToString());
            myList.Add("");

            return String.Join(",", myList);
        }

        public static string addIdToParentTag(string parentTag, object id)
        {
            return parentTag + id.ToString() + prefix;
        }
    }
}