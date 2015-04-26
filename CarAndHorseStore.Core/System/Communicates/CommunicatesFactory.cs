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
            {
                CommunicatesKinds.FoundCars,"Znaleziono: \n"+
                                            "ID | Nazwa | Opis | Cena | Kolor | Marka | Typ nadwozia | Liczba cylindrów | Pojemność silnika \n"
            },
            {
                CommunicatesKinds.FoundHorses,"Znaleziono: \n" +
                                            "ID | Nazwa | Opis | Cena | Kolor | Rasa | Płeć \n"
                                            },
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
            {CommunicatesKinds.UpdatedProductInfoFail, "Aktualizacja informacji o produkcie nie powiodła się. Proszę spróbować ponownie. "},
            {CommunicatesKinds.MusicComunikatesStop, "Zatrzymano komunikaty głosowe. Troche szkoda. "},
            {CommunicatesKinds.Cleaned, "Wyszyszczono ekran. "},
            {
                CommunicatesKinds.ShowHelp,           "Komenda        | Pobierane parametry |          Opis                   | Użytkownik    | Przykład użycia\n" +
                                            "          _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n" +
                                            "          login          |     nazwa hasło     | Logowanie do systemu            | Niezalogowany | login Marek W$7!@\n" +
                                           // "          . . . . . . . . . . . . . . . . .  . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .\n" +
                                            "          logout         |          -          | Wylogowanie z systemu           | Admin/Klient  | logout \n" +
                                            "          whoiam         |          -          | Informacja o loginie            | Admin/Klient  | whoiam \n" +
                                            "          stop           |          -          | Zatrzymanie komunikatów         | Wszyscy       | stop\n" +
                                            "          showcart       |          -          | Wyswietlenie zawartości koszyka | Klient        | showcart \n" +
                                            "          add            | nr_produktu liczba  | Dodanie produktu/ów do koszytka | Klient        | add bmw12 1\n" +
                                            "          remove         | nr_produktu liczba  | Usunięcie produktu/ów z koszyka | Klient        | remove bmw 12 1\n" +
                                            "          checkout       |          -          | Zrealizowanie zakupów           | Klient        | checkout\n" +
                                            "          showcarsby     | (klucz=wartość)+    | Wyswietlenie samochodów         | Klient        | showcarsby \n" +
                                            "                         |                     | o podanych parametrach          |               | brand=BMW \n" +
                                            "          showhorsesby   | (klucz=wartość)+    | Wyswietlenie koni               | Klient        | showhorseby\n" +
                                            "                         |                     | o podanych parametrach          |               | color=palomino \n" +
                                            "          info           | nr_produktu         | Wyswietlenie inf. o produkcie   | Klient        | info BMW12 \n" +
                                            "          cls            |          -          | Wyszyszczenie ekranu            | Wszyscy       | cls \n" +
                                            "          exit           |          -          | Wyjście ze sklepu               | Wszyscy       | exit \n" +
                                            "          create         | nazwa haslo haslo   | Stworzenie konta klienta        | Admin         | create Al qw! qw!\n" +
                                            "          addproduct     | nazwa nr_produktu   | Dodanie produktu do sklepu      | Admin         | addproduct BMW_M4 \n" +
                                            "                         | kategoria cana opis |                                 |               | BMW4 Car 85000 Cool\n" +
                                            "          updateproduct  | nr_produktu (Name|  | Aktualizacja informacji         | Admin         | updateproduct BMW4 \n" +
                                            "                         | Price|Description)  | o produkcie                     |               | cena 82000 \n" +
                                            "                         | nowa wartość        |                                 |               |            \n" +
                                            "          deleteproduct  | nr_produktu         | Usunięcie produktu ze sklepu    | Admin         | delete BMW11 \n"
                                            }

        };

        public static string GetCommunicate(CommunicatesKinds kind)
        {
            return communicatesDictionary.ContainsKey(kind) ? "C&H Shop: " + communicatesDictionary[kind] : "C&H Shop: Błąd";
        }

    }
}
