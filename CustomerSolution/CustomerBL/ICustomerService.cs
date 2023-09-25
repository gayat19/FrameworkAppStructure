using CustomerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBL
{
    public interface ICustomerService
    {
        Task<Customer> AddNew(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetAllCustomersWithinRange(int min,int max);
    }
}
