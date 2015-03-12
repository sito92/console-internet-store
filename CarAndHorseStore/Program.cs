using System;
using System.Collections.Generic;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;

namespace CarAndHorseStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeSystem = new StoreSystem();
            var commandParser = new CommandParser();


            while (true)
            {
                Console.WriteLine(commandParser.ParseCommand(Console.ReadLine()));
            }

        }
    }
}
