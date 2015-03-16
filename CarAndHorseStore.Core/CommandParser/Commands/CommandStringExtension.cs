using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.CommandParser.Commands
{
    public static class CommandStringExtension
    {
        private const char commandDelimeter = ' ';
        public static List<string> GetParameters(this string command)
        {
            return command.Split(commandDelimeter).Skip(1).ToList();
        }

        public static string GetKeyWord(this string command)
        {
            return command.Split(commandDelimeter).FirstOrDefault();
        }
    }
}
