using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Interface
{
    interface ICustomerRepository
    {
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int id);
        CustomerModel GetCustomerByEmail(string email);
        CustomerModel GetCustomerByUserId(int userId);
        CustomerModel GetCustomerByCredentials(string customerNumber, string password);
        bool AddCustomer(CustomerModel customer);
        bool UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(int id);
    }
}
