using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv_c_1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        struct InfoData : IInfoData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Source
        {
            internal void CheckAndProceed(IEnumerable<IInfoData> data)
            {
                var dest = new Destination();
                dest.ProceedData(data);
            }
        }

        class Destination
        {
            internal void ProceedData(IEnumerable<IInfoData> data)
            {
                foreach (var item in data)
                {
                }
            }
        }

        public interface IInfoData
        {
            string FirstName { get; set; }
            string LastName { get; set; }
        }
    }
}
