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
        private const string cleaned = "Wyczyszczono";
        private const string connected = "Połączono";
        private const string connecting = "Łączenie...";
        private const string notStarted = "System nie wystartował";
        public bool IsParsing { get; set; }
        //private IRepository rep;



        private Dictionary<string, Command> comandsDictionary = new Dictionary<string, Command>();


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
                new Command() { commandDelegate = storeSystem.WhoAmI, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("exit",
                new Command() { commandDelegate = storeSystem.Exit, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("logout",
                new Command() { commandDelegate = storeSystem.LogOutUser, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("cls",
                new Command() { commandDelegate = this.Cls, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("add",
               new Command() { commandDelegate = storeSystem.AddProductToCart, properParametersAmmount = new List<int>() { 2 } });
            comandsDictionary.Add("remove",
             new Command() { commandDelegate = storeSystem.RemoveProductFromCart, properParametersAmmount = new List<int>() { 2 } }); 
            comandsDictionary.Add("showcart",
               new Command() { commandDelegate = storeSystem.ShowCart, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("showhorsesby",
             new Command() { commandDelegate = storeSystem.ShowHorsesBy, properParametersAmmount = new List<int>() { 1 } });
            comandsDictionary.Add("showcarsby",
             new Command() { commandDelegate = storeSystem.ShowCarsBy, properParametersAmmount = new List<int>() { 1 } });
            comandsDictionary.Add("checkout",
             new Command() { commandDelegate = storeSystem.CheckOut, properParametersAmmount = new List<int>() { 0 } });
            comandsDictionary.Add("info",
             new Command() { commandDelegate = storeSystem.ShowProductInfo, properParametersAmmount = new List<int>() { 1 } });
            comandsDictionary.Add("create",
             new Command() { commandDelegate = storeSystem.CreateUser, properParametersAmmount = new List<int>() { 3 } });
            comandsDictionary.Add("addproduct",
             new Command() { commandDelegate = storeSystem.AddProductToShop, properParametersAmmount = new List<int>() { 5 } }); 
            comandsDictionary.Add("deleteproduct",
             new Command() { commandDelegate = storeSystem.DeleteProduct, properParametersAmmount = new List<int>() { 1 } });
            comandsDictionary.Add("updateproduct",
             new Command() { commandDelegate = storeSystem.UpdateProduct, properParametersAmmount = new List<int>() { 2, 3, 4, 5 } });  //TODO przemyslenie 
            //comandsDictionary.Add("play",
            // new Command() { commandDelegate = storeSystem.Play, properParametersAmmount = new List<int>() {0} }); 
        }

        public string ParseCommand(string command)
        {
            
            if (!IsParsing) return notStarted;
            if (String.IsNullOrEmpty(command))
            {
                return command;
            }
            var keyWord = command.GetKeyWord();
            var parameters = command.GetParameters();


            if (!IsCommandOperate(keyWord))
            {
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.CommandNotCooperate);
            }

            if (!comandsDictionary[keyWord].IsProperParametersAmmount(parameters.Count))
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParametersAmmount);
            var result = comandsDictionary[keyWord].commandDelegate(parameters);
            SystemWorkingSwitch();
            return result;
        }

        public void Start()
        {
            Console.WriteLine(connecting);
            storeSystem.Start();
            SystemWorkingSwitch();
            Console.WriteLine(connected);
            
            
        }

        private string Cls(List<string> parameters)
        {
            Console.Clear();
            return cleaned;
        }
        private bool IsCommandOperate(string keyword)
        {
            return comandsDictionary.ContainsKey(keyword);
        }

        private void SystemWorkingSwitch()
        {
            IsParsing = storeSystem.IsWorking;
        }
    }
}
