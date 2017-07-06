using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv_c_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Product(i.ToString(),i,i));
            }
            var temp = new Product("30", 30, 30);
            Console.WriteLine(list[30] == temp);
            Console.WriteLine(list.Where(x => x.cost > 56).Count());
            Console.WriteLine(list.Where(x => x == temp).ElementAt(0).name);
            Console.Read();
        }

        struct Product : IEquatable<Product>
        {
            public string name;
            public double cost;
            public int count;
            public Product(string name, double cost, int count)
            {
                this.name = name;
                this.cost = cost;
                this.count = count;
            }

            public override int GetHashCode() => name.GetHashCode() ^ cost.GetHashCode();

            public override bool Equals(object obj) =>  obj is Product ? Equals((Product)obj) : false;

            public bool Equals(Product other) => name == other.name && cost == other.cost;

            public static bool operator ==(Product x, Product y) => x.Equals(y);

            public static bool operator !=(Product x, Product y) => !(x == y);

        }
    }
}
