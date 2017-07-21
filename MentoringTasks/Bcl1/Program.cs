using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAttribute = (MyAttr)Attribute.GetCustomAttribute(typeof(MyClass), typeof(MyAttr));
            Console.WriteLine($"{myAttribute.Name} <-> {myAttribute.Email}");
            Console.Read();
        }

        [MyAttr(2,"email")]
        class MyClass
        {

        }

        [AttributeUsage(AttributeTargets.Class)]
        class MyAttr : Attribute 
        {
            public int Name { get; set; }
            public string Email { get; set; }
            public MyAttr(int name, string email)
            {
                Name = name;
                Email = email;
            }
        }
    }
}
