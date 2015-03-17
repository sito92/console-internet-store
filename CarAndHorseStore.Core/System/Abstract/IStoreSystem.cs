using System.Collections.Generic;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.System.Abstract
{
    public interface IStoreSystem
    {
         string LogInUser(List<string> parameters);

    }
}
