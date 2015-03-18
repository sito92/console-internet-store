using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Domain.Repository.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProductsByPrice(float price);
    }
}
