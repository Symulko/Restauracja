using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Model.Entities;

namespace Restaurant.UI.Data
{
    public interface ICustomersRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid customerId);
        Task<Customer> GetCustomerAsync(Guid id);
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> UpdateCustomerAsync(Customer customer);
    }
}