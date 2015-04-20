using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Domain.Interfaces;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.Extensions
{
    public static class ListExtension
    {
        private const string emptyProductlist = "List produktów jest pusta";

        public static void AddRange<T>(this List<T> list, T item, int count)
        {
            var repeat = Enumerable.Repeat(item, count);
            list.AddRange(repeat);
        }

        //public static string HorsesToString(List<Horse> horses)
        //{
        //    if (horses == null || horses.Count == 0)
        //        return emptyProductlist;
        //}
    }
}
