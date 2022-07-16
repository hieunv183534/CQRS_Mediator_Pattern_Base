using NJsonSchema.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOM.MOBILE.WebApi.Filters
{
    public class SchemaNameGenerator : DefaultSchemaNameGenerator, ISchemaNameGenerator
    {
        public string Generate(Type type)
        {
            var name = type.Namespace;
            if (name.StartsWith("BCCP.QTUD.Domain.Application"))
            {
                var listPathName = name.Split(".");
                name = "";
                for (int i = 3; i < listPathName.Length; i++)
                {
                    if (listPathName[i] != "Queries" && listPathName[i] != "Commands")
                    {
                        name += listPathName[i];
                    }
                }
                name += type.Name;
            }
            else if (name.StartsWith("BCCP._Base.Models"))
            {
                name = $"{name.Replace(".", "").Replace("BCCPCommonModels", "")}{type.Name}";
            }
            else
            {
                name = $"{name.Replace(".", "")}{type.Name}";
            }
            return name.Replace("`","");
            //return @$"{type.Namespace.Replace(".", "")
            //    .Replace("BCCPDomainApplication", "")
            //    .Replace("QueriesGetPaging", "")
            //    .Replace("QueriesGetCount", "")
            //    .Replace("QueriesFindOne", "")
            //    .Replace("QueriesCombobox", "")
            //    .Replace("CommandsCreate", "")
            //    .Replace("CommandsUpdate", "")
            //    .Replace("CommandsDelete", "")
            //    .Replace("BCCPCommonModels", "")}{base.Generate(type)}";
            //string retValue = base.Generate(type);
            //// Quite ugly but do fix the concept
            //if (retValue.Equals("BaseClass"))
            //{
            //    retValue = type.FullName.Replace(".", "_");
            //}
            //return retValue;
        }
    }
}
