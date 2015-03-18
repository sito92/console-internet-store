using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.CommandParser.Commands
{
    class Command
    {

        public Func<List<string>, string> commandDelegate { get; set; }
        public List<int> properParametersAmmount { get; set; }

        public string keyWord { get; set; }

        public bool IsProperParametersAmmount(int parametersAmmount)
        {
            return properParametersAmmount.Contains(parametersAmmount);
        }
       
    }
}
