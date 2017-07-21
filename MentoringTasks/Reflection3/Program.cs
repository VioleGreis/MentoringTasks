using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList(typeof(string));
            for (string i = "0"; i != "00000000000"; i += "0")
            {
                list.Add(i);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        private static IList CreateList(Type type) => 
            (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
    }
}
