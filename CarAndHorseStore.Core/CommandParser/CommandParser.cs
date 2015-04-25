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
        private const string connectedMessage = "                                                              ::              \n" +
                                         "                                                             NDNM:             \n" +
                                         "                                                           ODDDNMNN            \n" +
                                         "                                                               MMMN            \n" +
                                         "                                                              NMMMMD           \n" +
                                         "                                                             ~NMMMNO           \n" +
                                         "                                                         ~DNNDNNMMM            \n" +
                                         "                                                        8DNNNNNMMMM            \n" +
                                         "                                                       D  MNNNNNNMN            \n" +
                                         "                                                       D     88NNNND           \n" +
                                         "                                                       ?      NDO8DNN          \n" +
                                         "                                  ~=++=~                       MMNM8NND        \n" +
                                         "                             ,,:,=I?7Z8DOI~8=                   DDDDNNNN       \n" +
                                         "                       ,,,,,~~==?7?,.,:~.,,?=NO:..,               N8888NN8     \n" +
                                         "                     ~OOOZ$I?++=++ODZNIM,:=8OI~I,:,,:.+~         OOZNONDNNN    \n" +
                                         "                     Z$NNMNOZZ$$$$O8M7MDN+=++,$==,:=====,II      D8D8NNN  NN   \n" +
                                         "                     Z.NOND8$~O8888DNM+:OM?ZZO$7?+=~===+?I7       DN 8D    NN  \n" +
                                         "                      DDD+=:7$..ZZO8I?$=MMONMMNDMM=?O$?IMM7        D8 NN  8NND \n" +
                                         "                          :7O88D8M=O8ND8DM+8NZ77D7?~,MMMD.$        DN  N       \n" +
                                         "                                  ,+$NINNM,Z8DNNND8I8D88Z~       ZM    D       \n" +
                                         "                                         ,~+I$$7I+~,            =     D        \n" +
                                         "                                                                      O        \n" +
                                         "                                                                               \n" +
                                         "                                   Witaj w Car & Horse Shop                    \n";
                                                                                                       
        private const string connecting = "Łączenie...";
        private const string notStarted = "System nie wystartował";
        private const string unauthorizetUserOnSystemStart = "Niezalogowany> ↓ ";  //Czytałem ostanio o wzorcach projektowych. Jeden szczzególnie mi się spodobał KISS
        private const string userPrompt = "> ↓ ";
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
                new Command() { commandDelegate = storeSystem.Cls, properParametersAmmount = new List<int>() { 0 } });
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
            comandsDictionary.Add("addhorse",
             new Command() { commandDelegate = storeSystem.AddHorseToShop, properParametersAmmount = new List<int>() { 6 } });
            comandsDictionary.Add("addcar",
             new Command() { commandDelegate = storeSystem.AddCarToShop, properParametersAmmount = new List<int> { 7 } });
            comandsDictionary.Add("deleteproduct",
             new Command() { commandDelegate = storeSystem.DeleteProduct, properParametersAmmount = new List<int>() { 1 } });
            comandsDictionary.Add("updateproduct",
             new Command() { commandDelegate = storeSystem.UpdateProduct, properParametersAmmount = new List<int>() { 2, 3, 4, 5 } });  //TODO przemyslenie 
            //comandsDictionary.Add("play",
            // new Command() { commandDelegate = storeSystem.Play, properParametersAmmount = new List<int>() {0} });
           comandsDictionary.Add("stop",
               new Command() {commandDelegate = storeSystem.Stop, properParametersAmmount = new List<int>() { 0} });
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
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.CommandNotCooperate) + "\n" + storeSystem.GetUserNameToDisplay() + userPrompt;
            }

            if (!comandsDictionary[keyWord].IsProperParametersAmmount(parameters.Count))
                return CommunicatesFactory.GetCommunicate(CommunicatesKinds.IncorrectParametersAmmount) + "\n" + storeSystem.GetUserNameToDisplay() + userPrompt;
            var result = comandsDictionary[keyWord].commandDelegate(parameters);
            SystemWorkingSwitch();
            return result + "\n" + storeSystem.GetUserNameToDisplay() + userPrompt;
        }

        public void Start()
        {
            Console.WriteLine(connecting);
            storeSystem.Start();
            SystemWorkingSwitch();
            Console.Clear();
            Console.WriteLine(connectedMessage);
            Console.WriteLine(unauthorizetUserOnSystemStart);
            
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
