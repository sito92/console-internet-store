using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Domain.Repository.Interfaces
{
    public interface IHorseRepository
    {
        IQueryable<Horse> GetHorseByName(string name);

        IQueryable<Horse> GetHorseByBreed(Breed breed);

        IQueryable<Horse> GetHorseByColor(Color color);

        IQueryable<Horse> GetHorseBySex(Sex sex); 

    }
}
