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
            {CommunicatesKinds.IncorrectPassword, "Hasło jest nieprawidłowe."},
            {CommunicatesKinds.ProductNotFound,"Produkt o podanych parametrach nie istnieje."},
            {CommunicatesKinds.ProductOutOfStock, "Aktualnie nie posiadamy wybranego produktu."},
            {CommunicatesKinds.ProductAddedToCart, "Dodano produkt do koszyka."},
            {CommunicatesKinds.ProductNotAddedError, "Wystąpił błąd podczas dodawania do koszyka. Proszę spróbować ponownie."},
            {CommunicatesKinds.ProductRemovedFromCart, "Produkt został pomyślnie usunięty z koszyka."},
            {CommunicatesKinds.ProductNotRemovedError, "Usunięcie z koszyka nie powiodło się. Proszę spróbować ponownie."},
            {CommunicatesKinds.OrderIsInProgress, "Zamówienie zostało złożone i jest w trakcie realizacji."},
            {CommunicatesKinds.OrderCancelled, "Zamówienie zostało anulowane."},
            {CommunicatesKinds.LogoutFailed, "Wylogowanie nie powiodło się. Proszę spróbować ponownie."},
            {CommunicatesKinds.IncorrectParametersAmmount, "Nieprawidłowa liczba parametrów."},
            {CommunicatesKinds.CommandNotCooperate, "Komenda nieobsługiwana."},
            {CommunicatesKinds.LoggedAs, "Zalogowany jako: "},
            {CommunicatesKinds.NotLogged, "Nie jesteś zalogowany."},
            {CommunicatesKinds.Thanks, "Dziękujemy za używanie systemu."},
            {CommunicatesKinds.LogoutAccepted, "Pomyślnie wylogowano."},
            {CommunicatesKinds.AlreadyLogged, "Jesteś już zalogowany."},
            {CommunicatesKinds.IncorrectParameter, "Nieprawidłowy parametr: "},
            {CommunicatesKinds.EmptyCart, "Koszyk jest pusty."},
            {CommunicatesKinds.InvalidHorseAttribute, "Nieobsługiwany atrybut konia."},
            {CommunicatesKinds.InvalidCarAttribute, "Nieobsługiwany atrybut samochodu."},
            {CommunicatesKinds.LoggedAsAdmin,"Nie można wykonać akcji, zalogowano jako admin."},                
            {CommunicatesKinds.Found,"Znaleziono: \n"},
            {CommunicatesKinds.IncorectKeyValue,"Nieprawidłowa para wartość-klucz."},
            {CommunicatesKinds.InvalidAttribute,"Nieprawidłowy atrubut."},
            {CommunicatesKinds.UserAlreadyExist,"Podana nazwa użytkownika jest zajęta. "},
            {CommunicatesKinds.PasswordAreDifferent,"Podane hasła nie są jednakowe. "},
            {CommunicatesKinds.NewUserCreated,"Dodano nowego użytkownika. "},
            {CommunicatesKinds.ProductAddedToShop, "Dodano produkt do sklepu. "},
            {CommunicatesKinds.ProductDeltedFromShop, "Usunięto produkt ze sklepu. "},
            {CommunicatesKinds.UpdatedProductInfo, "Zaktualizowano informaje o produkcie. "},
            {CommunicatesKinds.NewUserCreatedFail,"Dodanie nowego użytkownika nie powiodło się. Proszę spróbować ponownie. "},
            {CommunicatesKinds.ProductAddedToShopFail, "Dodanie produktu do sklepu nie powiodło się. Proszę spróbować ponownie. "},
            {CommunicatesKinds.ProductDeltedFromShopFail, "Usunięcie produktu ze sklepu nie powiodło się. Proszę spróbować ponownie. "},
            {CommunicatesKinds.UpdatedProductInfoFail, "Aktualizacja informaji o produkcie nie powiodła się. Proszę spróbować ponownie. "}

        };

        public static string GetCommunicate(CommunicatesKinds kind)
        {
            return communicatesDictionary.ContainsKey(kind) ? communicatesDictionary[kind] : "Błąd";
        }

    }
}
