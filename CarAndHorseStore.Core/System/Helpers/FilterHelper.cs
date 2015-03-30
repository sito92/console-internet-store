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
        private const char atribiutesDelimeter = ',';
        private const char keyValueDelimeter = '=';
        public static bool CheckeProperties<T>(Dictionary<string, string> filters)
        {
            var type = typeof(T);
            //var property = type.GetProperties()[0];
           // property.t

            //var typePropertiesNames = type.GetProperties().Select(x => x.Name.ToLower());
            var typePropertiesNames = new List<string>();
            var proprties = type.GetProperties();

            foreach (var property in proprties)
            {
                typePropertiesNames.Add(property.Name.ToLower());
                if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string))
                {
                    typePropertiesNames.AddRange(property.PropertyType.GetProperties().Select(x=>x.Name.ToLower()));
                }
            }
            return !filters.Any(filter => !typePropertiesNames.Contains(filter.Key.ToLower()));
        }

        public static Dictionary<string, string> GetFiltersDictionary(string parameters)
        {
            var filters = parameters.Split(atribiutesDelimeter);
            Dictionary<string, string> filtersDictionary = new Dictionary<string, string>();

            foreach (var temp in filters.Select(filter => filter.Split(keyValueDelimeter)))
            {
                if (temp.Count() != 2 || string.IsNullOrEmpty(temp[0]) || string.IsNullOrEmpty(temp[1]))
                {
                    return null;
                }

                filtersDictionary.Add(temp[0].ToLower(), temp[1]);
            }
            return filtersDictionary;
        }

        public static ComapreModel GetCompareModel(Dictionary<string, string> filtersDictionary)
        {
            var type = typeof(ComapreModel);
            ComapreModel compareModel = new ComapreModel();

            foreach(var filter in filtersDictionary)
            {
                var property = type.GetProperty(filter.Key.UpperCaseFirstLetter());
                try
                {
                    property.SetValue(compareModel, Convert.ChangeType(filter.Value.Replace(".",","), property.PropertyType), null);
                   
                }
                catch
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
