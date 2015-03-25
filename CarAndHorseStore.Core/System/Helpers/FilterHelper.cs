using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.System.Exeptions;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Models.HelpModels;

namespace CarAndHorseStore.Core.System.Helpers
{
    public static class FilterHelper
    {
        public static bool CheckeProperties<T>(Dictionary<string, string> filters)
        {
            var type = typeof(T);
            var typePropertiesNames = type.GetProperties().Select(x => x.Name.ToLower());

            return !filters.Any(filter => !typePropertiesNames.Contains(filter.Key.ToLower()));
        }

        public static Dictionary<string, string> GetFiltersDictionary(string parameters)
        {
            var filters = parameters.Split(',');
            Dictionary<string, string> filtersDictionary = new Dictionary<string, string>();

            foreach (var temp in filters.Select(filter => filter.Split('=')))
            {
                if (temp.Count() != 2 || string.IsNullOrEmpty(temp[0]) || string.IsNullOrEmpty(temp[1]))
                {
                    return null;
                }

                filtersDictionary.Add(temp[0].ToLower(), temp[1]);
            }
            return filtersDictionary;
        }

        public static ComapreModel GetHorseByFilters(Dictionary<string, string> filtersDictionary)
        {
            var type = typeof(ComapreModel);
            ComapreModel compareModel = new ComapreModel();

            foreach(var filter in filtersDictionary)
            {
                var property = type.GetProperty(filter.Key.UpperCaseFirstLetter());
                try
                {
                    property.SetValue(compareModel, Convert.ChangeType(filter.Value, property.PropertyType), null);
                   
                }
                catch(Exception ex)
                {
                    throw new InvalidValueExeption(filter.Value,filter.Key);
                }

            }
            return compareModel;
        }

        private static string UpperCaseFirstLetter(this string s)
        {
            
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            
            return char.ToUpper(s[0]) + s.Substring(1);
        }

     
    }
}
