using AD_CW_1.Business.Interface;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public int AddUser(UserModel user)
        {
            return _repo.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _repo.DeleteUser(id);
        }

        public List<UserModel> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public UserModel GetUserByCredentials(string username, string password)
        {
            return _repo.GetUserByCredentials(username, password);
        }

        public UserModel GetUserById(int id)
        {
            return _repo.GetUserById(id);
        }

        public UserModel GetUserByUsername(string username)
        {
            return _repo.GetUserByUsername(username);
        }

        public bool UpdateUser(UserModel user)
        {
            return _repo.UpdateUser(user);
        }
    }
}
