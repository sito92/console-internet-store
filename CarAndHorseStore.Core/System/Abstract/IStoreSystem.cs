using System.Collections.Generic;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.System.Abstract
{
    public interface IStoreSystem
    {
         string LogInUser(List<string> parameters);
        string LogOutUSer(List<string> parameters);
         string WhoAmI(List<string> parameters);
         string Add(List<string> parameters);
         string ShowCart(List<string> parameters);
         string ShowHorsesBy(List<string> parameters);
        string Exit(List<string> parameters);

    }
}
