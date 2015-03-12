using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Interfaces;

namespace CarAndHorseStore.Core.CommandParser
{
    class CommandParser : ICommandParser
    {
        private IStoreSystem storeSystem;



        private Dictionary<string, Func<string, string>> comandsDictionary = new Dictionary
            <string, Func<string, string>>();
            

        public CommandParser()
        {
            comandsDictionary.Add("line",LogIn);
        }
        public void ParseCommand(string command)
        {
            //TODO logika wyciągania parametrów
            var commandArray = command.Split(' ');
            var keyWord = commandArray.First();

            var parameters = "";


            comandsDictionary[command](parameters);
        }


        public  string LogIn(string parameters)
        {
            IUser user = null;
            //TODO Logiga logowania
            //storeSystem.LogInUser(user);
            return "Zalogowano pomyślnie";
        }
    }
}
