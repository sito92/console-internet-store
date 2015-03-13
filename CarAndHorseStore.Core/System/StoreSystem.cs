using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Domain.Models;


namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private List<UserBase> loggedUSers; 
      

        public void LogInUser(UserBase user)
        {
            loggedUSers.Add(user);
            //dodaj user do zalogowanych
        }

    }
}
