using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface ICustomersDataAccess
    {
        IEnumerable<Customer> GetCustomers();

        void InsertCustomer(Customer insertedCustomer);

        void UpdateCustomer(Customer updatedCustomer);

        void DeleteCustomer(int customerId);
    }
}