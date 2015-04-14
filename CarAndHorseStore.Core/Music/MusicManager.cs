using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.Music
{
    public class MusicManager
    {
        public Dictionary<string, string> MusicDictionary = new Dictionary<string, string>();

        public MusicManager()
        {
            MusicDictionary.Add("LogInUser","witamy");
            MusicDictionary.Add("AddProductToCart", "wybranie_produktu");
            MusicDictionary.Add("CheckOut", "koniec");
        }
    }
}
