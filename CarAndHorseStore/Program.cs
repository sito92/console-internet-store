using System;
using System.Collections.Generic;
using System.Linq;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserBaseRepository userBaseRepository= new UserBaseRepository();
            var system = new StoreSystem(userBaseRepository);

            var commandPArser = new CommandParser(system);

            while (true)
            {
                Console.WriteLine(commandPArser.ParseCommand(Console.ReadLine()));
            }
        }
    }
}
