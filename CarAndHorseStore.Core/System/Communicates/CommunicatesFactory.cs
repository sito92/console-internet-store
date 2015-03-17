using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.CommandParser.Communicates
{
    class CommunicatesFactory
    {
        private static Dictionary<Communicates.CommunicatesKinds, string> communicatesDictionary = new Dictionary
            <CommunicatesKinds, string>()
        {
            {CommunicatesKinds.LoginAccpted, "Zalogowano pomyślnie"},
            {CommunicatesKinds.NotFoundLogin, "Nie znaleziono podanego użytkownika"},
             {CommunicatesKinds.IncorrectPassword, "Hasło nie prawidłowe"}
        };

        public static string GetCommunicate(CommunicatesKinds kind)
        {
            return communicatesDictionary.ContainsKey(kind) ? communicatesDictionary[kind] : "Błąd";
        }
    }
}
