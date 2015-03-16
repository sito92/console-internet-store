using System;
using System.Collections.Generic;
using System.Linq;
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

            ShopDbContext context = new ShopDbContext();

            Admin p = new Admin();
            Console.WriteLine(p.GetType().Name);
            Console.ReadKey();
        }
    }
}
