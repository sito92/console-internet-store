using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Domain.Repository
{
    public class UserBaseRepository:GenericRepository<UserBase,ShopDbContext>,IUserBaseRepository
    {
        public UserBase GetUserByLogin(string login)
        {
            return FindBy(u => u.UserName==login).FirstOrDefault();
        }
    }
}
