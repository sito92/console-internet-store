using System;
using System.Collections.Generic;
using System.Linq;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Core.System.Helpers;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository;
using CarAndHorseStore.Domain.Repository.Interfaces;
using Ninject;

namespace CarAndHorseStore
{
    class Program
    {
        private const string connected = "Połączono";
        static void Main(string[] args)
        {

           // IKernel ninjectKernel = new StandardKernel();

            //HorsePropertiesCheckTest();





            
            
            IUserBaseRepository userBaseRepository= new UserBaseRepository();
            IProductRepository productRepository = new ProductRepository();
            //productRepository.Add(new Car(){BodyTypeId = 1,BrandId =1,ColorId = 2,Description = "sfdsf",EngineTypeId = 1,Name = "afasd",Price = 5});
           // productRepository.SaveChanges();
            userBaseRepository.Open();
            Console.WriteLine(connected);

            var system = new StoreSystem(userBaseRepository,productRepository);

            var commandPArser = new CommandParser(system);

            while (system.IsWorking)
            {
                Console.WriteLine(commandPArser.ParseCommand(Console.ReadLine()));

                if (!system.IsWorking)
                {
                    Console.ReadKey();
                }
            }
             
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
