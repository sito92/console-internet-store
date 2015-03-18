using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class OrderRepository : GenericRepository<Order,ShopDbContext>, IOrderRepository
    {
        public IQueryable<Order> GetOrdersByClient(Client client)
        {
            return FindBy(o => o.Client == client);
        }
    }
}
