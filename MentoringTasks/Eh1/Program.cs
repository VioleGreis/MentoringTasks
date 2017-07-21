using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eh1
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = string.Empty;
            while (str != "E" || str != "Exit")
            {
                str = Console.ReadLine();
                Console.WriteLine(str == string.Empty ? "Empty" : str?[0].ToString());
            }
            Console.Read();
        }
    }
}
