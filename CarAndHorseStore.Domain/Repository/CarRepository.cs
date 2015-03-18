using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class CarRepository : GenericRepository<Car,ShopDbContext>, ICarRepository
    {
        public IQueryable<Car> GetCarsByBrand(Brand brand)
        {
            return FindBy(c => c.Brand == brand);
        }

        public IQueryable<Car> GetCarsByBodyType(BodyType bodyType)
        {
            return FindBy(c => c.BodyType == bodyType);
        }

        public IQueryable<Car> GetCarsByColor(Color color)
        {
            return FindBy(c => c.Color == color);
        }

        public IQueryable<Car> GetCarsByEngineType(EngineType engineType)
        {
            return FindBy(c => c.EngineType == engineType);
        }
    }
}
