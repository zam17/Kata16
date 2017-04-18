using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Impl
{
    public static class Extensions
    {
        public static bool DefaultEquals(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
