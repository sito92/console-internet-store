using System.Collections.Generic;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.System.Abstract
{
    public interface IStoreSystem
    {
         string LogInUser(List<string> parameters);
         string LogOutUser(List<string> parameters);
         string WhoAmI(List<string> parameters);
         string AddProductToCart(List<string> parameters);
         string RemoveProductFromCart(List<string> parameters);
         string ShowCart(List<string> parameters);
         string CheckOut(List<string> parameters);         
         string ShowHorsesBy(List<string> parameters);
         string ShowCarsBy(List<string> parameters);
         string ShowProductInfo(List<string> parameters);  
         string CreateUser(List<string> parameters);  
         string AddProductToShop(List<string> parameters);  
         string DeleteProduct(List<string> parameters);
         string UpdateProduct(List<string> parameters);  
         string Exit(List<string> parameters);
            void Start();
         bool IsWorking { get; set; }

        void Play(string parameters);


    }
}
