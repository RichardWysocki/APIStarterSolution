using System;
using System.Collections.Generic;
using System.Linq;

namespace APIStarterSolution.DataAccess
{
    public class DbContext : IDbContext
    { 
        private List<Customer> _customers = new List<Customer>();

        public DbContext()
        {
            _customers.Add(new Customer()
                {Id = 1, FirstName = "Luke", LastName = "Skywalker", Weapon = "Lightsaber", HomePlanet = "Tatooine" });
            _customers.Add(new Customer()
                {Id = 2, FirstName = "Han", LastName = "Solo", Weapon = "DL-44 heavy blaster", HomePlanet = "Corellia" });
            _customers.Add(new Customer()
                {Id = 3, FirstName = "Darth", LastName = "Vader", Weapon = "Lightsaber", HomePlanet = "Tatooine" });
            _customers.Add(new Customer()
                {Id = 4, FirstName = "Obi-Wan", LastName = "Kenobi", Weapon = "Lightsaber", HomePlanet = "Stewjon " });
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(int Id)
        {
            return _customers.Find(c => c.Id == Id);
        }

        public void DeleteCustomer(int Id)
        {
            if (_customers.Find(c => c.Id == Id) != null)
                _customers.RemoveAll(x => x.Id == Id);
            else
            {
                throw new Exception("No Customers to Remove.");
            }
        }

        public void UpdateCustomer(Customer result)
        {
            if (_customers.Find(c => c.Id == result.Id) != null)
            {
                _customers.RemoveAll(x => x.Id == result.Id);
                _customers.Add(result);
            }
            else
            {
                throw new Exception("No Customers to Remove.");
            }
        }

        public Customer AddCustomer(Customer customer)
        {
            var maxInt = _customers.Max(x => x.Id) + 1;
            var sampleCustomer = new Customer()
                { Id = maxInt, FirstName = customer.FirstName, LastName = customer.LastName, Weapon = customer.Weapon };
            _customers.Add(sampleCustomer);
            return sampleCustomer;
        }
    }

}
