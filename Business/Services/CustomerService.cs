using AD_CW_1.Business.Interface;
using AD_CW_1.Models;
using AD_CW_1.Repositories;
using AD_CW_1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Services
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public bool AddCustomer(CustomerModel customer)
        {
            return _repo.AddCustomer(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _repo.DeleteCustomer(id);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public CustomerModel GetCustomerByCredentials(string customerNumber, string password)
        {
            return _repo.GetCustomerByCredentials(customerNumber, password);
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public CustomerModel GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);
        }

        public CustomerModel GetCustomerByUserId(int userId)
        {
            return _repo.GetCustomerByUserId(userId);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            return _repo.UpdateCustomer(customer);
        }
    }
}
