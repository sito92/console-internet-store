using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore.Core.CommandParser.Commands;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Core.System.Abstract;

namespace CarAndHorseStore.Core.CommandParser
{
    public class CommandParser : ICommandParser
    {
        private IStoreSystem storeSystem;

        //private IRepository rep;



        private Dictionary<string, Command> comandsDictionary = new Dictionary
            <string, Command>();
            

        public CommandParser(IStoreSystem system)
        {
            storeSystem = system;
            comandsDictionary.Add("login",new Command(){commandDelegate = system.LogInUser,properParametersAmmount = new List<int>(){2}});
            comandsDictionary.Add("whoami",new Command(){commandDelegate = system.WhoAmI,properParametersAmmount = new List<int>(){1,2}});
        }
        public string ParseCommand(string command)
        {
            var keyWord = command.GetKeyWord();
            var parameters = command.GetParameters();

            //TODO sprawdzenie czy komenda jest obsługiwana
            return comandsDictionary[keyWord].IsProperParametersAmmount(parameters.Count) ? comandsDictionary[keyWord].commandDelegate(parameters) : CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParametersAmmount);
        }
    }
}
