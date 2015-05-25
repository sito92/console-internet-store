using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Core.Music;

namespace socketclient1.Infrastructure
{
    public static class ClientActionManager
    {
        private static Dictionary<string, Action<string>> actionDictionary = new Dictionary<string, Action<string>>()
        {
            {"", Play},
            {"cls", Cls}
        };
        public static void PerformAction(string action)
        {
            if (actionDictionary.ContainsKey(action))
            {
                actionDictionary[action](action);
            }
            else
            {
                actionDictionary[""](action);
            }
        }
        private static void Play(string name)
        {
            name = name.Split(' ').FirstOrDefault();
            if (MusicManager.MusicDictionary.ContainsKey(name))
            {


                SoundPlayer player = new SoundPlayer();
                var selectedSound = Resource1.ResourceManager.GetStream(MusicManager.MusicDictionary[name]);
                player = new SoundPlayer(selectedSound);
                player.Play();
            }
        }

        private static void Cls(string cls)
        {
            Play(cls);
            Console.Clear();
        }
    }
}
