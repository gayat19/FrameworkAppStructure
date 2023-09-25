using CustomerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CustomerDALibrary
{
    public class CustomerRepository : IRepository<int, Customer>,IDisposable
    {
        SqlConnection conn;

        public CustomerRepository()
        {
            conn = new SqlConnection(@"Data source=DESKTOP-1C1EU5R\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial catalog=dbCust25Sep23");
        }
        /// <summary>
        /// Adds a new customer to the customer table
        /// </summary>
        /// <param name="item">Customer object with name and age</param>
        /// <returns>the whole customer object with the generated id</returns>
        /// <exception cref="UnableToAddCustomerException"/>
        public async Task<Customer> Add(Customer item)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("proc_InsertCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cname", item.Name);
                    cmd.Parameters.AddWithValue("@cage", item.Age);
                    cmd.Parameters.Add("@cid", SqlDbType.Int);
                    cmd.Parameters[2].Direction = ParameterDirection.Output;
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if(result !=0)
                        {
                            int id;
                            
                            if(int.TryParse(cmd.Parameters[2].ToString(), out id))
                           {
                                item.Id = id;
                                return item;
                            }
                        }
                    }
                    catch(SqlException exp)
                    {
                        Debug.WriteLine(exp.Message);
                        
                    }
                }
               
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            throw new UnableToAddCustomerException();
            
        }

        public Task<Customer> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            conn = null;
        }

        public Task<Customer> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlDataAdapter da = new SqlDataAdapter("proc_GetAllCustomers",conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Customer customer = new Customer
                    {
                        Id = Convert.ToInt32(item[0].ToString()),
                        Name= item[1].ToString(),
                        Age = Convert.ToInt32(item[2].ToString())
                    };
                    customers.Add(customer);
                }
            }
            if (customers.Count == 0)
                throw new NoCustomerAvailableException();
            return customers;
        }

        public Task<Customer> Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
