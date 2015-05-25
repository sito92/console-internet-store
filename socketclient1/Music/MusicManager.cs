using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.Music
{
    public class MusicManager
    {
        public static Dictionary<string, string> MusicDictionary = new Dictionary<string, string>();

        static MusicManager()
        {
            MusicDictionary.Add("login","witamy");
            MusicDictionary.Add("addproducttocart", "wybranie_produktu");
            MusicDictionary.Add("checkout", "koniec");
            MusicDictionary.Add("logout", "wylogowanie");
            MusicDictionary.Add("whoami","kim_jestem");
            MusicDictionary.Add("removeproductfromcart", "usuniecie_produktu");
            MusicDictionary.Add("showcart", "zawartosc_koszyka");
            MusicDictionary.Add("showproductinfo", "informacje_o_produkcie");
            MusicDictionary.Add("deleteproduct","usuniecie_produktu");
            MusicDictionary.Add("cls","czyszczenie_ekranu");
        }
    }
}
