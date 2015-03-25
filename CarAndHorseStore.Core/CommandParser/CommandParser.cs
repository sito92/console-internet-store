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
            InitializeCommands();
        }

        private void InitializeCommands()
        {

            comandsDictionary.Add("login",
                new Command() { commandDelegate = storeSystem.LogInUser, properParametersAmmount = new List<int>() { 2 } });
            comandsDictionary.Add("whoami",
                new Command() { commandDelegate = storeSystem.WhoAmI, properParametersAmmount = new List<int>() { 1, 2 } });
            comandsDictionary.Add("exit",
                new Command() { commandDelegate = storeSystem.Exit, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("logout",
                new Command() { commandDelegate = storeSystem.LogOutUSer, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("cls",
                new Command() { commandDelegate = this.Cls, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("add",
               new Command() { commandDelegate = storeSystem.Add, properParametersAmmount = new List<int>() { 2 } });
            comandsDictionary.Add("showcart",
               new Command() { commandDelegate = storeSystem.ShowCart, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("showhorsesby",
             new Command() { commandDelegate = storeSystem.ShowHorsesBy, properParametersAmmount = new List<int>() { 1 } });
        }

        public string ParseCommand(string command)
        {
            var keyWord = command.GetKeyWord();
            var parameters = command.GetParameters();


            if (!IsCommandOperate(keyWord))
            {
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.CommandNotCooperate);
            }

            return comandsDictionary[keyWord].IsProperParametersAmmount(parameters.Count)
                ? comandsDictionary[keyWord].commandDelegate(parameters)
                : CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParametersAmmount);
        }

        private string Cls(List<string> parameters)
        {
            Console.Clear();
            return "Wyczyszczono";
        }
        private bool IsCommandOperate(string keyword)
        {
            return comandsDictionary.ContainsKey(keyword);
        }

    }
}
