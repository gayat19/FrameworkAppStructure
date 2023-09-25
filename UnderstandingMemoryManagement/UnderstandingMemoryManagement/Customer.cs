using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingMemoryManagement
{
    class Customer :IDisposable
    {
        public Customer()
        {
            Console.WriteLine("Constructor Invoked");
        }
        public int Id { get; set; }
        public string Name { get; set; }
        ~Customer()
        {
            Console.WriteLine("Customer gone");
        }

        public void Dispose()
        {
            Console.WriteLine("customer disposed");
        }
    }
}
