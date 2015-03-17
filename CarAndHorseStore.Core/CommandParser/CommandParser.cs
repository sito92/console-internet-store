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



        private Dictionary<string, Func<List<string>, string>> comandsDictionary = new Dictionary
            <string, Func<List<string>, string>>();
            

        public CommandParser()
        {
            comandsDictionary.Add("login",storeSystem.LogInUser);
        }
        public string ParseCommand(string command)
        {
            var keyWord = command.GetKeyWord();
            var parameters = command.GetParameters();

            return comandsDictionary[keyWord](parameters);
        }
    }
}
