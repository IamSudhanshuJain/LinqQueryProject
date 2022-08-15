using System;
using System.Collections.Generic;

namespace BusinessLayer.Helpers
{
    public static class EnumerationHelpers
    {
        public static T SingleElseException<T>(this IEnumerable<T> items, Func<T, bool> predicate, Func<IEnumerable<T>, Exception> exceptionFactory)
        {
            List<T> matchedItems = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    matchedItems.Add(item);
                }
            }

            if (matchedItems.Count == 1)
                return matchedItems[0];

            throw exceptionFactory(matchedItems);
        }
    }
}
