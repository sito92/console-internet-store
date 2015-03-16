using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore;
using CarAndHorseStore.Core.CommandParser.Role;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Domain.Models;


namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private UserBase loggedUSer; 
      

        public void LogInUser(UserBase user)
        {

            loggedUSer = user;
            //dodaj user do zalogowanych
        }

    }
}
