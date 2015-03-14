using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class HorseRepository : GenericRepository<Horse, ShopDbContext>, IHorseRepository
    {
        public IQueryable<Horse> GetHorseByName(string name)
        {
            return FindBy(h => h.Name == name);
        }

        public IQueryable<Horse> GetHorseByBreed(Breed breed)
        {
            return FindBy(h => h.Breed == breed);
        }

        public IQueryable<Horse> GetHorseByColor(Color color)
        {
            return FindBy(h => h.Color == color);
        }

        public IQueryable<Horse> GetHorseBySex(Sex sex)
        {
            return FindBy(h => h.Sex == sex);
        }
    }
}
