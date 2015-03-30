using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.System.Exeptions
{
    public class InvalidValueExeption:Exception
    {
        private const string error = "Nieprawidłowa wartość: ";
        private const string errorfor = " dla: ";
        private string value;
        private string property;
        public InvalidValueExeption(string _value,string _property)
        {
            value = _value;
            property = _property;
        }
        public override string Message
        {
            get { return error + value + errorfor + property; }
        }
    }
}
