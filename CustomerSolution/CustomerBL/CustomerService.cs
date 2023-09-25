using CustomerDALibrary;
using CustomerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBL
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Customer> _repository;

        public CustomerService(IRepository<int,Customer> repository)
        {
            _repository = repository;
        }
        public async Task<Customer> AddNew(Customer customer)
        {
            if (customer != null)
            {
                if(customer.Name.Length>3 && customer.Age>18)
                {
                    return await _repository.Add(customer);
                }
            }
            throw new UnableToAddCustomerException("Invalid customer property ");
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return (await _repository.GetAll()).ToList();
        }

        public async Task<List<Customer>> GetAllCustomersWithinRange(int min, int max)
        {
            List<Customer> customers = await GetAllCustomers();
            if(customers != null && customers.Count>0)
            {
                customers = customers.Where(c => c.Age >= min && c.Age <= max).OrderBy(c=>c.Age).ToList();
                return customers;
            }
            throw new NoCustomerAvailableException();
        }
    }
}
