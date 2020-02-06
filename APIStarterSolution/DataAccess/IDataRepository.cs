using System.Collections.Generic;

namespace APIStarterSolution.DataAccess
{
    public interface IDataRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomerByCustomerId(int id);

        Customer CreateCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        void DeleteCustomer(int id);

    }
}