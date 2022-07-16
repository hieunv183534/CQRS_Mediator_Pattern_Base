using System;
using System.Collections.Generic;
using System.Linq;

namespace NOM.Domain._Base.Extentions;

public static class Oxtensions
{
    public static List<string> CheckDuplicate<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        return source.GroupBy(keySelector)
                      .Where(gr => gr.Count() > 1)
                      .Select(gr => gr.Key.ToString()).ToList();
    }
}