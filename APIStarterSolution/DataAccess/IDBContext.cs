using System.Collections.Generic;

namespace APIStarterSolution.DataAccess
{
    public interface IDbContext
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer result);
        Customer AddCustomer(Customer customer);
    }
}