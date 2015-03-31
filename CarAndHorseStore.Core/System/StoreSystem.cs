using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.CommandParser.Role;
using CarAndHorseStore.Core.Extensions;
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
        private string checkCommunicate;
        private UserBase loggedUser;
        private IUserBaseRepository userBaseRepository;
        private IProductRepository productRepository;
 
        public bool IsWorking { get; protected set; }

        public StoreSystem(IUserBaseRepository urepository, IProductRepository pRepository)
        {
            userBaseRepository = urepository;
            productRepository = pRepository;
            IsWorking = true;
        }
        #region FunctinalitiesMethods
        public string LogInUser(List<string> parameters)
        {
            if (loggedUser != null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.AlreadyLogged);

            var login = parameters[0];
            var password = parameters[1];


            var user = userBaseRepository.GetUserByLogin(login);

            if (user == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginNotFound);

            if (user.Password != password)
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectPassword);
            loggedUser = user;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginAccepted);
        }

        public string LogOutUser(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            loggedUser = null;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LogoutAccepted);
        }

        public string WhoAmI(List<string> parameters)
        {
            return loggedUser != null
                ? CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoggedAs) + loggedUser.Name
                : CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
        }

        public string Exit(List<string> parameters = null)
        {
            IsWorking = false;
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.Thanks);
        }

        public string AddProductToCart(List<string> parameters)
        {
            
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

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

            var user = (Client)loggedUser;

            if (user.Cart == null)
            {
                user.Cart = new Cart();
            }
            
            var product = productRepository.FindBy(x => x.Id == id).FirstOrDefault();
            if (product == null) return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductNotFound);

                       
         
           user.Cart.Products.AddRange(product,intParams[0]);
                             
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductAddedToCart);
        }

        public string RemoveProductFromCart(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

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

            var user = (Client)loggedUser;

            /*
            //Ciało właściwej funkcji
            //            
           

            for (int i = 0; i < intParams[1]; i++)
            {
                //user.Cart.Products.Remove(product);
            }
             */
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductRemovedFromCart);

        }

        public string CheckOut(List<string> parameters)   
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

            var user = (Client)loggedUser;

            if (user.Cart == null)
            {
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.EmptyCart);
            }

            //
            //Ciało właściwej funkcji
            // 

            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.OrderIsInProgress);
        }

        public string ShowProductInfo(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;


            //
            //Ciało właściwej funkcji
            // 

            return "Na razie bez opisu";
        }

        public string CreateUser(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (!CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.NewUserCreated);
        }

        public string AddProductToShop(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (!CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

            //
            //Ciało właściwej funkcji
            // 

            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductAddedToShop);
        }

        public string DeleteProduct(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (!CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;

            int id;
            if (Int32.TryParse(parameters[0], out id))
            {
                //funkcja usuwająca produktu ze sklepu
            }
            else
            {
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParameter);
            }

            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductDeltedFromShop);
        }

        public string UpdateProduct(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (!CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;


            //
            //Ciało właściwej funkcji
            // 

            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.UpdatedProductInfo);
        }
        #endregion
        #region CheckMethods

        private bool CheckIfNotAdmin(out string CheckCommunicate)
        {
            CheckCommunicate = "";
            if (loggedUser.GetRole() != RoleKind.Administrator) return false;
            CheckCommunicate = CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoggedAsAdmin);
            return true;
        }

        private bool CheckIfLogged(out string CheckCommunicate)
        {
            CheckCommunicate = "";
            if (loggedUser != null) return false;
            CheckCommunicate = CommunicatesFactory.GetCommunicate(CommunicatesKinds.NotLogged);
            return true;
        }
        #endregion
        #region ShowMethods
        public string ShowCart(List<string> parameters)
        {
            if (CheckIfLogged(out checkCommunicate)) return checkCommunicate;
            if (CheckIfNotAdmin(out checkCommunicate)) return checkCommunicate;
            var user = (Client)loggedUser;

            return user.Cart == null ? CommunicatesFactory.GetCommunicate(CommunicatesKinds.EmptyCart) : user.Cart.ToString();
        }

        public string ShowHorsesBy(List<string> parameters)
        {
            Dictionary<string, string> filtersDictionary;
            if (FilterCheck<Horse>(parameters, out filtersDictionary, out checkCommunicate)) return checkCommunicate;

            try
            {
                var compareModel = FilterHelper.GetCompareModel(filtersDictionary);

                var filtredHorses = GetFiltredHorses(compareModel);
                    
                if (filtredHorses.Count() == 0)
                    return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductNotFound);

                var stringresult = filtredHorses.Aggregate(CommunicatesFactory.GetCommunicate(CommunicatesKinds.Found),
                    (current, horse) => current + (horse.ToString() + "\n"));
                return stringresult;
            }
            catch (InvalidValueExeption ex)
            {
                return ex.Message;
            }
        }
        public string ShowCarsBy(List<string> parameters)
        {
            Dictionary<string, string> filtersDictionary;
            if (FilterCheck<Car>(parameters, out filtersDictionary, out checkCommunicate)) return checkCommunicate;

            try
            {
                var compareModel = FilterHelper.GetCompareModel(filtersDictionary);

                var filtredCars = GetFiltredCars(compareModel);

                if (filtredCars.Count() == 0)
                    return CommunicatesFactory.GetCommunicate(CommunicatesKinds.ProductNotFound);

                var stringresult = filtredCars.Aggregate(CommunicatesFactory.GetCommunicate(CommunicatesKinds.Found),
                    (current, car) => current + (car.ToString() + "\n"));
                return stringresult;
            }
            catch (InvalidValueExeption ex)
            {
                return ex.Message;
            }
        }
        #endregion    
        #region FiltredProductMethods
        private IEnumerable<Horse> GetFiltredHorses(ComapreModel compareModel)
        {
            var filtredHorses = productRepository.FindBy(x => x==x).AsEnumerable().OfType<Horse>()
                .Where(x => x.Id == (compareModel.Id == 0 ? x.Id : compareModel.Id))
                .Where(
                    x =>
                        x.Name.ContainsWithComparer(compareModel.Name ?? x.Name, StringComparison.OrdinalIgnoreCase))
                .Where(
                    x =>
                        x.Breed.Name.ContainsWithComparer(compareModel.Breed ?? x.Breed.Name,
                            StringComparison.OrdinalIgnoreCase))
                .Where(
                    x =>
                        x.Color.Name.ContainsWithComparer(compareModel.Color ?? x.Color.Name,
                            StringComparison.OrdinalIgnoreCase))
                .Where(x => x.Price == (compareModel.Price == 0 ? x.Price : compareModel.Price));
            return filtredHorses;
        }

        private IEnumerable<Car> GetFiltredCars(ComapreModel compareModel)
        {
            var filtredCars = productRepository.FindBy(x => true).AsEnumerable().OfType<Car>()
                .Where(x => x.Id == (compareModel.Id == 0 ? x.Id : compareModel.Id))
                .Where(
                    x =>
                        x.Name.ContainsWithComparer(compareModel.Name ?? x.Name, StringComparison.OrdinalIgnoreCase))
                .Where(x => x.Price == (compareModel.Price == 0 ? x.Price : compareModel.Price))
                .Where(
                    x =>
                        x.Brand.Name.ContainsWithComparer(compareModel.Brand ?? x.Brand.Name,
                            StringComparison.OrdinalIgnoreCase))
                .Where(
                    x =>
                        x.BodyType.Name.ContainsWithComparer(compareModel.Bodytype ?? x.BodyType.Name,
                            StringComparison.OrdinalIgnoreCase))
                .Where(
                    x =>
                        x.EngineType.CylinderAmount ==
                        (compareModel.Cylinderamount == 0 ? x.EngineType.CylinderAmount : compareModel.Cylinderamount))
                .Where(
                    x =>
                        x.EngineType.EngineCapacity ==
                        (compareModel.Enginecapacity == 0 ? x.EngineType.EngineCapacity : compareModel.Enginecapacity));
            return filtredCars;

        }
        #endregion
        private static bool FilterCheck<T>(List<string> parameters, out Dictionary<string, string> filtersDictionary, out string CheckCommunicate)
        {
            CheckCommunicate = "";
            filtersDictionary = FilterHelper.GetFiltersDictionary(parameters[0]);
            if (filtersDictionary == null)
            {
                CheckCommunicate = CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorectKeyValue);
                return true;
            }

            if (FilterHelper.CheckeProperties<T>(filtersDictionary)) return false;
            CheckCommunicate = CommunicatesFactory.GetCommunicate(CommunicatesKinds.InvalidAttribute);
            return true;
        }

    }
}
