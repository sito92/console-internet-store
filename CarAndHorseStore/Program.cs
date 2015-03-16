using System;
using System.Collections.Generic;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository;

namespace CarAndHorseStore
{
    class Program
    {
        static void Main(string[] args)
        {
            BodyTypeRepository bodyTypeRepository = new BodyTypeRepository();
            bodyTypeRepository.Add(new BodyType(){Name = "Hatchback"});
            bodyTypeRepository.SaveChanges();
            Console.ReadKey();

        }
    }
}
