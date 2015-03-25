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
            {CommunicatesKinds.LoginAccepted, "Zalogowano pomyślnie."},
            {CommunicatesKinds.LoginFailed, "Wystąpił błąd podczas logowania."},
            {CommunicatesKinds.LoginNotFound, "Nie znaleziono podanego użytkownika."},
            {CommunicatesKinds.IncorrectPassword, "Hasło nie prawidłowe."},
            {CommunicatesKinds.ProductNotFound,"Produkt o podanych parametrach nie istnieje."},
            {CommunicatesKinds.ProductOutOfStock, "Aktualnie nie posiadamy wybranego produktu."},
            {CommunicatesKinds.ProductAddedToList, "Dodano produkt do koszyka."},
            {CommunicatesKinds.ProductNotAddedError, "Wystąpił błąd podczas dodawania do koszyka. Proszę spróbować ponownie."},
            {CommunicatesKinds.ProductRemovedFromList, "Produkt został pomyślnie usunięty z koszyka."},
            {CommunicatesKinds.ProductNotRemovedError, "Usunięcie z koszyka nie powiodło się. Proszę spróbować ponownie."},
            {CommunicatesKinds.OrderIsInProgress, "Zamówienie zostało złożone i jest w trakcie realizacji."},
            {CommunicatesKinds.OrderCancelled, "Zamówienie zostało anulowane."},
            {CommunicatesKinds.LogoutFailed, "Wylogowanie nie powiodło się. Proszę spróbować ponownie."},
            {CommunicatesKinds.IncorrectParametersAmmount, "Nie prawidłowaliczba parametrów"},
            {CommunicatesKinds.CommandNotCooperate, "Komenda nie obsługiwana"},
            {CommunicatesKinds.LoggedAs, "Zalogowany jako"},
            {CommunicatesKinds.NotLogged, "Nie jesteś zalogowany"},
            {CommunicatesKinds.Thanks, "Dziękujemy za używanie systemu"},
            {CommunicatesKinds.LogoutAccepted, "Pomyślnie wylogowano"},
            {CommunicatesKinds.AllreadyLogged, "Jesteś już zalogowany"},
            {CommunicatesKinds.IncorrectParameter, "Nieprawidłowy parametr: "},
            {CommunicatesKinds.EmptyCart, "Koszyk jest pusty"}
        };

        public static string GetCommunicate(CommunicatesKinds kind)
        {
            return communicatesDictionary.ContainsKey(kind) ? communicatesDictionary[kind] : "Błąd";
        }
    }
}
