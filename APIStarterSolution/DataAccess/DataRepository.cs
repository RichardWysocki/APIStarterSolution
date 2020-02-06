using System;
using System.Collections.Generic;
using System.Linq;

namespace APIStarterSolution.DataAccess
{
    public class DataRepository : IDataRepository
    {
        private readonly IDbContext _sampleContext;

        public DataRepository(IDbContext sampleContext)
        {
            _sampleContext = sampleContext;
        }


        public List<Customer> GetAllCustomers()
        {
            return _sampleContext.GetAllCustomers();
        }

        public Customer CreateCustomer(Customer customer)
        {
            var newCustomer = _sampleContext.AddCustomer(customer);
            return newCustomer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var result = _sampleContext.GetAllCustomers().SingleOrDefault(b => b.Id == customer.Id);
            if (result != null)
            {
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                _sampleContext.UpdateCustomer(result);
                return true;
            }
            return false;
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerByCustomerId(id);
            _sampleContext.DeleteCustomer(id);
        }

        public Customer GetCustomerByCustomerId(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Parameter");
            var customer = _sampleContext.GetAllCustomers().SingleOrDefault(Customer => Customer.Id == id);
            if (customer == null)
                throw new Exception("Error getting Customer record.");
            return customer;
        }
    }
}
