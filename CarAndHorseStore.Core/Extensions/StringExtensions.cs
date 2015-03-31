using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsWithComparer(this string source, string cont
                                                    , StringComparison compare)
        {
            return source.IndexOf(cont, compare) >= 0;
        }
    }
}
