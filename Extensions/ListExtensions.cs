using System.Collections;

namespace OpenSeaWebApi.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Groups an ICollection by divisions of time based on a start and end date, with the spans relative to the divisions
    /// </summary>
    /// <param name="list"> The list to operate on </param>
    /// <param name="timeGetter"> How to get the DateTime object on the ICollection to ble able to perform comparisons </param>
    /// <param name="fromDate"> When does the time division start </param>
    /// <param name="toDate"> When does the time division stop </param>
    /// <param name="divisions"> How many divisions to perform (2018 -> 2022, with 8 divisions => 6 month span) </param>
    /// <typeparam name="T"> Any object with contains a DateTime that can be comparable </typeparam>
    /// <returns> An array objects that are grouped by span with a list of objects that fit in that span </returns>
    public static object[] GroupByTime<T>(this ICollection<T> list, Func<T,DateTime> timeGetter, DateTime fromDate, DateTime toDate, int divisions)
    {
        Dictionary<int,ICollection<T>> groups = new Dictionary<int, ICollection<T>>();
        for (int i = 0; i < divisions; i++) groups.Add(i,new List<T>());
        var span = (toDate - fromDate)/divisions;
        foreach (var w in list)
        {
            var wSpan = (timeGetter(w) - fromDate);
            var groupId = (int)(wSpan/span);
            groups[groupId].Add(w);
        }
        return groups.GroupBy(g=>fromDate+(span*g.Key)).Select( u => new object[]{u.Key,u.Select(a => a.Value)}).ToArray();
    }
}