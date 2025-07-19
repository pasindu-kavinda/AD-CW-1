using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Interface
{
    interface IUserRepository
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        UserModel GetUserByUsername(string username);
        UserModel GetUserByCredentials(string username, string password);
        int AddUser(UserModel user);
        bool UpdateUser(UserModel user);
        bool DeleteUser(int id);
    }
}
