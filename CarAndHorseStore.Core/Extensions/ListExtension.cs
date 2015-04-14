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

        public static string ListToString<T>(this List<T> list) where T : class 
        {
            if (list == null || list.Count == 0)
                return emptyProductlist;

            var prefix = typeof (T);
            string listContent = "";
            
            foreach (var prod in list)
            {
                var props = prod.GetType().GetProperties();

                foreach (var prop in props)
                {
                    if (!listContent.Contains(prod.ToString())) // tu wymysl cos lepszego. bo to nie zadziala, nie?
                    {
                        listContent += prop.Name + ":" + prop.GetValue(prod,null);
                    }
                }
            }
            return prefix + listContent;
        }
    }
}
