using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Domain.Repository.Interfaces
{
    public interface ICarRepository
    {
        IQueryable<Car> GetCarsByBrand(Brand brand);

        IQueryable<Car> GetCarsByBodyType(BodyType bodyType);

        IQueryable<Car> GetCarsByColor(Color color);

        IQueryable<Car> GetCarsByEngineType(EngineType engineType);
    }
}
