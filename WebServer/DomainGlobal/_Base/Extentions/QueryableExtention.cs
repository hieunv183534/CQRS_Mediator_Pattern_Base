using NOM.Dao.Bases;
//using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.DomainGlobal._Base.Extentions
{
    public static class QueryableExtention
    {
        /// <summary>
        /// Converts the specified source to <see cref="PagedListVm{T}"/> by the specified <paramref name="pageNumber"/> and <paramref name="pageSize"/>.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageNumber">The number of the page, index from 1.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <returns>An instance of  implements <see cref="PagedListVm{T}"/> interface.</returns>
        public static PagingResultModel<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            var count = source.Count();
            var pagedList = new PagingResultModel<T>()
            {
                Data = new List<T>(),
                Paging = new PagingModel
                {
                    Page = pageNumber,
                    Size = pageSize,
                    Count = count
                }
            };
            if (count == 0)
            {
                return pagedList;
            }

            if (pageNumber > 1)
            {
                source = source.Skip((pageNumber - 1) * pageSize);
            }
            var items = source.Take(pageSize).ToList();
            pagedList.Data = items;

            return pagedList;
        }

        /// <summary>
        /// Converts the specified source to <see cref="PagedListVm{T}"/> by the specified <paramref name="pageNumber"/> and <paramref name="pageSize"/>.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageNumber">The number of the page, index from 1.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>An instance of  implements  <see cref="PagedListVm{T}"/> interface.</returns>
        public static async Task<PagingResultModel<T>> ToPagedListAsync<T>(this IQueryable<T> source, IPagingModel option, CancellationToken cancellationToken = default)
        {
            if (option.Page == null || option.Page <= 0)
            {
                option.Page = 1;
            }

            if (option.Size == null || option.Size <= 0)
            {
                option.Size = 10;
            }

            if (option.Size > 1000)
            {
                option.Size = 1000;
            }

            var count = 0;
            var sizeLimit = option.Size;
            if (option.LoadMore == true)
            {
                if (option.Size > 1)
                {
                    sizeLimit++;
                }
            }
            else
            {
                count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            }

            if (option.Page > 1)
            {
                source = source.Skip((option.Page.Value - 1) * option.Size.Value);
            }
            var items = await source.Take(sizeLimit.Value).ToListAsync(cancellationToken);

            if (option.LoadMore == true)
            {
                count = items.Count;
                if (count > option.Size)
                {
                    items.RemoveAt(items.Count - 1);
                }
            }

            var pagedList = new PagingResultModel<T>()
            {
                Data = items,
                Paging = new PagingModel
                {
                    Page = option.Page,
                    Size = option.Size,
                    Order = option.Order,
                    Count = count
                }
            };

            return pagedList;
        }

        public static IQueryable<T> WhereLoopback<T>(this IQueryable<T> source, JObject where)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T));

                var expression = ExpressionAnd(parameter, where);

                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);
                source = source.Where(lambda);

                return source;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Lỗi cú pháp where loopback: " + where.ToString());
            }
        }

        public static IQueryable<T> OrderByLoopback<T>(this IQueryable<T> source, JObject order) where T : class
        {
            try
            {
                var table = Expression.Parameter(typeof(T));
                var fisrt = true;
                foreach (JProperty opr in order.Properties())
                {
                    JObject param = new JObject();
                    param.Add(opr.Name, opr.Value);

                    var resultKey = param.ReadKeyObject(table);

                    Expression property = default;
                    Type propertyType = default;

                    property = GetProperty(table, resultKey.property);
                    propertyType = property.Type;

                    if (resultKey.isJson)
                    {
                        var propertyJson = GetProperty(table, resultKey.field);
                        var jsonFC = typeof(DbFunction).GetMethods().First(m => m.Name == "JsonValue" && m.GetParameters().Length == 2);
                        property = Expression.Convert(Expression.Call(jsonFC, propertyJson, Expression.Constant(resultKey.pathJson)), propertyType);
                    }

                    var queryExpr = source.Expression;
                    var selectorExpr = Expression.Lambda(property, table);
                    var funcName = fisrt ? resultKey.value.Value<bool>() ? "OrderBy" : "OrderByDescending" : resultKey.value.Value<bool>() ? "ThenBy" : "ThenByDescending";
                    queryExpr = Expression.Call(typeof(Queryable), funcName,
                                          new Type[] { source.ElementType, propertyType },
                                         queryExpr,
                                        selectorExpr);
                    source = source.Provider.CreateQuery<T>(queryExpr);
                    fisrt = false;
                }

                return source;
            }
            catch (Exception)
            {
                throw new ValidationException("Lỗi cú pháp order by loopback: " + order.ToString());
            }
        }

        //-- private func extension
        private static Expression ExpressionAnd(ParameterExpression table, JObject param)
        {
            Expression expression = default;

            if (param.ContainsKey("and") || param.ContainsKey("or"))
            {
                var key = param.ContainsKey("and") ? "and" : "or";
                var value = param.GetValue(key) as JArray;

                foreach (JObject item in value)
                {
                    var query = ExpressionAnd(table, item);
                    if (key == "and")
                    {
                        if (expression == null)
                        {
                            expression = query;
                        }
                        else
                        {
                            expression = Expression.AndAlso(expression, query);
                        }

                    }
                    else
                    {
                        if (expression == null)
                        {
                            expression = query;
                        }
                        else
                        {
                            expression = Expression.OrElse(expression, query);
                        }
                    }
                }
            }
            else
            {
                var resultKey = param.ReadKeyObject(table);

                Expression property = default;
                Type propertyType = default;

                property = GetProperty(table, resultKey.property);
                propertyType = property.Type;

                if (resultKey.isJson)
                {
                    var propertyJson = GetProperty(table, resultKey.field);
                    var jsonFC = typeof(DbFunction).GetMethods().First(m => m.Name == "JsonValue" && m.GetParameters().Length == 2);
                    property = Expression.Convert(Expression.Call(jsonFC, propertyJson, Expression.Constant(resultKey.pathJson)), propertyType);
                }

                if (resultKey.value.GetType() == typeof(JObject))
                {
                    foreach (var v2value in resultKey.value.Value<JObject>())
                    {
                        switch (v2value.Key)
                        {
                            case "gt":
                                var valueEx = v2value.Value.ToObject(propertyType);
                                expression = Expression.GreaterThan(property, Expression.Constant(valueEx, propertyType));
                                break;
                            case "gte":
                                valueEx = v2value.Value.ToObject(propertyType);
                                expression = Expression.GreaterThanOrEqual(property, Expression.Constant(valueEx, propertyType));
                                break;
                            case "lt":
                                valueEx = v2value.Value.ToObject(propertyType);
                                expression = Expression.LessThan(property, Expression.Constant(valueEx, propertyType));
                                break;
                            case "lte":
                                valueEx = v2value.Value.ToObject(propertyType);
                                expression = Expression.LessThanOrEqual(property, Expression.Constant(valueEx, propertyType));
                                break;
                            case "neq":
                                valueEx = v2value.Value.ToObject(propertyType);
                                expression = Expression.NotEqual(property, Expression.Constant(valueEx, propertyType));
                                break;
                            case "like":
                                valueEx = v2value.Value.ToObject(propertyType);
                                var mi = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
                                expression = Expression.Call(property, mi, Expression.Constant(valueEx, propertyType));
                                break;
                            case "nlike":
                                valueEx = v2value.Value.ToObject(propertyType);
                                mi = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
                                expression = Expression.Not(Expression.Call(property, mi, Expression.Constant(valueEx, propertyType)));
                                break;
                            //case "insplit":
                            //    lstWhere += $"{part}{v2value.Value} in (select * from STRING_SPLIT({rk},','))";
                            //    part = " and ";
                            //    break;
                            //case "ninsplit":
                            //    lstWhere += $"{part}{v2value.Value} not in (select * from STRING_SPLIT({rk},','))";
                            //    part = " and ";
                            //    break;
                            //case "inarray":
                            //    lstWhere += $"{part}{v2value.Value} in (select t.* from  {rk.Replace("JSON_VALUE", "OPENJSON")} WITH(id nvarchar(max) '$') as t)";
                            //    part = " and ";
                            //    break;
                            //case "ninarray":
                            //    lstWhere += $"{part}{v2value.Value} not in (select t.* from  {rk.Replace("JSON_VALUE", "OPENJSON")} WITH(id nvarchar(max) '$') as t)";
                            //    part = " and ";
                            //    break;
                            case "in":
                                var valueExIn = v2value.Value.ToObject(typeof(JArray));
                                mi = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
                                expression = Expression.Call(property, mi, Expression.Constant(valueExIn, propertyType));
                                break;
                            //case "nin":
                            //    lstWhere += $"{part}{rk} not in ({string.Join(',', v2value.Value)})";
                            //    part = " and ";
                            //    break;
                            case "startwith":
                                valueEx = v2value.Value.ToObject(propertyType);
                                mi = typeof(string).GetMethods().First(m => m.Name == "StartsWith" && m.GetParameters().Length == 1);
                                expression = Expression.Call(property, mi, Expression.Constant(valueEx, propertyType));
                                break;
                            case "endwith":
                                valueEx = v2value.Value.ToObject(propertyType);
                                mi = typeof(string).GetMethods().First(m => m.Name == "EndsWith" && m.GetParameters().Length == 1);
                                expression = Expression.Call(property, mi, Expression.Constant(valueEx, propertyType));
                                break;
                        }
                    }
                }
                else
                {
                    var valueEx = resultKey.value.ToObject(propertyType);
                    expression = Expression.Equal(property, Expression.Constant(valueEx, propertyType));
                }
            }

            return expression;
        }

        private static Expression GetProperty(ParameterExpression table, string property)
        {
            string[] properties = property.Split('.');
            Expression lastMember = table;
            for (int i = 0; i < properties.Length; i++)
            {
                MemberExpression member = Expression.Property(lastMember, properties[i]);
                lastMember = member;
            }
            return lastMember;
        }

        private static (string field, JToken value, string property, string pathJson, bool isJson) ReadKeyObject(this JObject source, ParameterExpression table)
        {
            var field = "";
            var pathJson = "$";
            var property = "";
            JToken vaule = null;
            bool isHasfield = false;

            foreach (var item in source)
            {
                var k = item.Key.ToString().Split('.');
                vaule = item.Value;

                for (int j = 0; j < k.Length; j++)
                {
                    if (j == 0)
                    {
                        field = k[j];
                        property = k[j];
                    }
                    else
                    {
                        if (!isHasfield)
                        {
                            var propertyType = GetProperty(table, property);
                            if (propertyType.Type.Name.Contains("Json"))
                            {
                                isHasfield = true;
                                pathJson += $".{k[j]}";
                                property += $".{k[j]}";
                            }
                            else
                            {
                                field += $".{k[j]}";
                                property += $".{k[j]}";
                            }
                        }
                        else
                        {
                            pathJson += $".{k[j]}";
                            property += $".{k[j]}";
                        }
                    }
                }
            }
            return (field, vaule, property, pathJson, isHasfield);
        }

        public static async Task<JArray> ExcuteStoredProcedure(this DbContext db, string query, params SqlParameter[] param)
        {
            var result = new JArray();
            using (var cm = db.Database.GetDbConnection().CreateCommand())
            {
                cm.CommandText = query;
                cm.CommandType = CommandType.Text;
                cm.CommandTimeout = 1000;
                if (param != null)
                {
                    cm.Parameters.AddRange(param);
                }
                await db.Database.OpenConnectionAsync();
                using (var r = await cm.ExecuteReaderAsync())
                {
                    if (r.HasRows)
                    {
                        while (await r.ReadAsync())
                        {
                            var row = new JObject();
                            for (int i = 0; i < r.FieldCount; i++)
                            {
                                row.Add(r.GetName(i), JToken.FromObject(r.GetValue(i)));
                            }
                            result.Add(row);
                        }
                    }
                }
            }

            return result;
        }
        public static async Task<JArray> ExcuteStoredProcedure2(this DbContext db, string query, params SqlParameter[] param)
        {
            var result = new JArray();
            using (var cm = db.Database.GetDbConnection().CreateCommand())
            {
                cm.CommandText = query;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 1000;
                if (param != null)
                {
                    cm.Parameters.AddRange(param);
                }
                await db.Database.OpenConnectionAsync();
                using (var r = await cm.ExecuteReaderAsync())
                {
                    if (r.HasRows)
                    {
                        while (await r.ReadAsync())
                        {
                            var row = new JObject();
                            for (int i = 0; i < r.FieldCount; i++)
                            {
                                row.Add(r.GetName(i), JToken.FromObject(r.GetValue(i)));
                            }
                            result.Add(row);
                        }
                    }
                }
            }

            return result;
        }
    }
}
