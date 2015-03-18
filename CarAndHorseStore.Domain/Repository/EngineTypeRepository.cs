using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class EngineTypeRepository : GenericRepository<EngineType,ShopDbContext>,IEngineTypeRepository
    {
        public IQueryable<EngineType> GetEngineTypesByCylinderAmount(int cylinderAmount)
        {
            return FindBy(et => et.CylinderAmount==cylinderAmount);
        }

        public IQueryable<EngineType> GetEngineTypesByEngineCapacity(float engineCapacity)
        {
            return FindBy(et => et.EngineCapacity == engineCapacity);
        }
    }
}
