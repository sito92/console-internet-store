using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.Extensions
{
    public static class ListExtension
    {

        public static void AddRange<T>(this List<T> list, T item, int count)
        {
            var repeat = Enumerable.Repeat(item, count);
            list.AddRange(repeat);
        }
    }
}
