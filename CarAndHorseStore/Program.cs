using System;
using System.Collections.Generic;
using System.Linq;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Core.System.Helpers;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository;
using CarAndHorseStore.Domain.Repository.Interfaces;
using CarAndHorseStore.Infrastructure;
using Ninject;

namespace CarAndHorseStore
{
    class Program
    {
        static void Main(string[] args)
        {
           
             
        }

        static void HorsePropertiesCheckTest()
        {
            Dictionary<string, string> filtersMock = new Dictionary<string, string>()
            {
                {"id","2"},
                {"name","asdf"},

            };


            var result = FilterHelper.CheckeProperties<Horse>(filtersMock);


            try
            {
                var horse = FilterHelper.GetCompareModel(filtersMock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
