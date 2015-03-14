using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class BodyTypeRepository : GenericRepository<BodyType, ShopDbContext>, IBodyTypeRepository
    {
        public BodyType GetBodyTypeByName(string name)
        {
            return FindBy(bt => bt.Name == name).FirstOrDefault();
        }
    }
}
