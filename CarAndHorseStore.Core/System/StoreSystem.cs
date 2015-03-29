using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.CommandParser.Role;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Core.System.Exeptions;
using CarAndHorseStore.Core.System.Helpers;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Models.HelpModels;
using CarAndHorseStore.Domain.Repository.Interfaces;

namespace CarAndHorseStore.Core.System
{
    public class StoreSystem : IStoreSystem
    {
        private UserBase loggedUSer;
        private IUserBaseRepository userBaseRepository;
        private IProductRepository productRepository;
        public bool IsWorking { get; protected set; }

        public StoreSystem(IUserBaseRepository urepository, IProductRepository pRepository)
        {
            userBaseRepository = urepository;
            productRepository = pRepository;
            IsWorking = true;
        }

        public string LogInUser(List<string> parameters)
        {
            if (loggedUSer != null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.AllreadyLogged);

            var login = parameters[0];
            var password = parameters[1];


            var user = userBaseRepository.GetUserByLogin(login);

            if (user == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginNotFound);

            if (user.Password != password)
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectPassword);
            loggedUSer = user;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginAccepted);
        }

        public string LogOutUSer(List<string> parameters)
        {
            if (loggedUSer == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
            loggedUSer = null;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LogoutAccepted);
        }

        public string WhoAmI(List<string> parameters)
        {
            return loggedUSer != null
                ? CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoggedAs) + loggedUSer.Name
                : CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
        }

        public string Exit(List<string> parameters = null)
        {
            IsWorking = false;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.Thanks);
        }

        public string Add(List<string> parameters)
        {
            if (loggedUSer == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
            if (loggedUSer.GetRole() == RoleKind.Administrator) return "Zalogowano jako admin";

            List<int> intParams = new List<int>(parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                int temp;
                if (Int32.TryParse(parameters[i], out temp))
                {
                    intParams.Insert(i, temp);
                }
                else
                {
                    return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParameter) + i;
                }
            }
            var id = intParams[0];

            var user = (Client)loggedUSer;

            if (user.Cart == null)
            {
                user.Cart = new Cart();
            }

            var product = productRepository.FindBy(x => x.Id == id).FirstOrDefault();
            if (product == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductNotFound);

            //TODO AMount razy
            user.Cart.Products.Add(product);
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductAddedToList);
        }

        public string ShowCart(List<string> parameters)
        {
            if (loggedUSer == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
            if (loggedUSer.GetRole() == RoleKind.Administrator) return "Zalogowano jako admin";
            var user = (Client)loggedUSer;

            return user.Cart == null ? CommunicatesFactory.GetCommunicate(CommunicatesKinds.EmptyCart) : user.Cart.ToString();
        }

        public string ShowHorsesBy(List<string> parameters)
        {
            var filtersDictionary = FilterHelper.GetFiltersDictionary(parameters[0]);
            if (filtersDictionary == null)
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorectKeyValue);

            if (!FilterHelper.CheckeProperties<Horse>(filtersDictionary))
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.InvalidHorseAttribute);

            try
            {
                var compareModel = FilterHelper.GetHorseByFilters(filtersDictionary);

                var filtredHorses = productRepository.FindBy(x => x == x).AsEnumerable().OfType<Horse>()
                    .Where(x => x.Id == (compareModel.Id == 0 ? x.Id : compareModel.Id))
                    .Where(x => x.Name == (compareModel.Name ?? x.Name));


                if (filtredHorses.Count() == 0)
                    return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductNotFound);

                var stringresult = filtredHorses.Aggregate("Znaleziono:\n",
                    (current, horse) => current + (horse.ToString() + "\n"));
                return stringresult;
            }
            catch (InvalidValueExeption ex)
            {
                return ex.Message;
            }
        }

    }
}
