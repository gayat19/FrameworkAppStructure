using CustomerDALibrary;
using CustomerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBL
{
    public class Provider:IDisposable
    {
        IRepository<int,Customer> repository;
        ICustomerService customerService;
        public Provider()
        {
            repository = new CustomerRepository();
            customerService = new CustomerService(repository);
        }

        public void Dispose()
        {
            repository = null;
            customerService = null;
        }

        public ICustomerService GetCustomerService()
        {
            return customerService;
        }
    }
}
