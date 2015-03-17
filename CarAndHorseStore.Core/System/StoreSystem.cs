using System.Collections.Generic;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private UserBase loggedUSer; 
      

        public string LogInUser(List<string> parameters )
        {
            //TODO sprawdzanie parametrów
           var login= parameters[1];
            var password = parameters[2];
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginAccpted);
        }

    }
}
