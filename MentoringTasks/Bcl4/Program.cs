using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl4
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new TrueBirthDate();
            temp.BirthTime = DateTime.Now;
            Console.WriteLine($"value {temp.BirthTime}");
            temp.BirthTime = DateTime.MinValue;
            Console.WriteLine($"value {temp.BirthTime}");
            Console.Read();
        }

        class TrueBirthDate
        {
            private DateTime? _date;
            public DateTime? BirthTime
            {
                get { return _date; }
                set 
                {
                    if (value != null && (value.Value.Year < 1900 || value.Value.Year > 2017)) _date = null;
                    else _date = value;
                }
            }
        }
    }
}
