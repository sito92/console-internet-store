using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore;
using CarAndHorseStore.Interfaces;


namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private List<IUser> loggedUSers; 
        public void StartSystem()
        {
            throw new NotImplementedException();
        }

        public void StopSystem()
        {
            throw new NotImplementedException();
        }

        public void DoAction()
        {
           
        }

        public void LogInUser(IUser user)
        {
            loggedUSers.Add(user);
            //dodaj user do zalogowanych
        }
        
    }
}
