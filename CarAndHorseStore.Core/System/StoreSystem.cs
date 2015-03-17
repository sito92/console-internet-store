using System.Collections.Generic;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private UserBase loggedUSer;
        private IUserBaseRepository userBaseRepository;
        public StoreSystem(IUserBaseRepository repository)
        {
            userBaseRepository = repository;
        }

        public string LogInUser(List<string> parameters )
        {

            //TODO sprawdzanie parametrów
           var login= parameters[0];
            var password = parameters[1];


            var user = userBaseRepository.GetUserByLogin(login);

            if (user == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotFoundLogin);
            if (user.Password==password)
            {
                loggedUSer = user;
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginAccpted);
            }
            else
            {
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectPassword);
            }
        }

    }
}
