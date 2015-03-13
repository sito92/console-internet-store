using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore.Core.CommandParser.Communicates;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Core.System.Abstract;

namespace CarAndHorseStore.Core.CommandParser
{
    public class CommandParser : ICommandParser
    {
        private IStoreSystem storeSystem;

        //private IRepository rep;



        private Dictionary<string, Func<string, string>> comandsDictionary = new Dictionary
            <string, Func<string, string>>();
            

        public CommandParser()
        {
            comandsDictionary.Add("login",LogIn);
        }
        public string ParseCommand(string command)
        {
            //TODO logika wyciągania parametrów
            var commandArray = command.Split(' ');
            var keyWord = commandArray.First();

            var parameters = "";


            return comandsDictionary[command](parameters);
        }


        private  string LogIn(string parameters)
        {
            
            //var = rep.GetUser();
            //TODO Logiga logowania
            //storeSystem.LogInUser(user);
            return CommunicatesFactory.GetCommunicate(CommunicatesKinds.LoginAccpted);
        }
    }
}
