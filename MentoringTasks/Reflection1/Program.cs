using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList(typeof(string));
            for (var i = new StringBuilder(); i.Length < 10; i.Append("0"))
            {
                list.Add(i.ToString());
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
