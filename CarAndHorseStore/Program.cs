using System;
using System.Collections.Generic;
using System.Linq;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;
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

            
            IUserBaseRepository userBaseRepository= new UserBaseRepository();
            IProductRepository productRepository = new ProductRepository();
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
    }
}
