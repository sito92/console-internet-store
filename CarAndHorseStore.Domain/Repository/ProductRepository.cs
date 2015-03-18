﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class ProductRepository : GenericRepository<Product,ShopDbContext>, IProductRepository
    {
        public IQueryable<Product> GetProductsByPrice(float price)
        {
            return FindBy(p => p.Price == price);
        }
    }
}
