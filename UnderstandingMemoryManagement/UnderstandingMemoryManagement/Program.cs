using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingMemoryManagement
{
    class Program
    {
        void SampleMethod()
        {
            int num1 = 100;
            using (Customer customer = new Customer() { Id = 101, Name = "Ramu" })
            {
                Console.WriteLine("Within using");
            }
                //CheckLive(customer);
                //customer = null;
                GC.Collect();

        }

        private void CheckLive()
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            new Program().SampleMethod();
            Console.ReadKey();
        }
    }
}
