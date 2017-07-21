using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl3
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string> { "a", "b", "a", "b", "a", "b", "a", "b", "a", "b", "a", "b", "a", "b", "Odd", "Even" };
            Console.WriteLine(StringEvenUnion(strings));
            Console.Read();
        }

        static string StringEvenUnion(IEnumerable<string> strings)
        {
            var list = strings.ToList();
            var sb = new StringBuilder();
            for (var i = 1; i < list.Count; i += 2)
            {
                sb.Append(list[i]);
            }
            return sb.ToString();
        }
    }
}
