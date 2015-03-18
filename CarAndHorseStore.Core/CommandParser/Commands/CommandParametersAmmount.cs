using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.CommandParser.Commands
{
    class CommandParametersAmmount
    {
        private static Dictionary<string, List<int>> properParametersAmmount = new Dictionary<string, List<int>>()
        {
            {"login", new List<int>() {2}}
        };

        public static bool IsProperParametersAmmount(string keyWord,int parmeters)
        {
            return properParametersAmmount.ContainsKey(keyWord) && properParametersAmmount[keyWord].Contains(parmeters);
        }
    }
}
