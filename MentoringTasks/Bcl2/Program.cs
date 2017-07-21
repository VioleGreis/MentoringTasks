using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl2
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string>{"asdsad", "gagsga", "zxczxcA", "a", "asfbb", "babsb", "yYayasy"};
            strings = OrdinalSort(strings).ToList();
            foreach (var i in strings)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }

        public static IEnumerable<string> OrdinalSort(IEnumerable<string> list)
        {
            var sortedlist = list.ToList();
            sortedlist.Sort(Comparison);
            return sortedlist;
        }

        private static int Comparison(string s, string s1) => string.CompareOrdinal(s, s1);
    }
}
