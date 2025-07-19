using AD_CW_1.Database;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Services
{
    class UserRepository : IUserRepository
    {
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM users";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Role = reader["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = reader["updated_at"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated_at"])
                    });
                }
            }

            return users;
        }

        public UserModel GetUserById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM users WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Role = reader["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = reader["updated_at"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated_at"])
                    };
                }
            }

            return null;
        }

        public UserModel GetUserByUsername(string username)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM users WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Role = reader["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        //UpdatedAt = reader["updated_at"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated_at"])
                    };
                }
            }

            return null;
        }

        public int AddUser(UserModel user)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO users (username, password, role, created_at) 
                 VALUES (@username, @password, @role, @createdAt);
                 SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", user.Username);
                        command.Parameters.AddWithValue("@password", user.Password);
                        command.Parameters.AddWithValue("@role", user.Role);
                        command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                        connection.Open();
                        int id = Convert.ToInt32(command.ExecuteScalar());
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("User creation failed.");
            }
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE users SET username = @username, password = @password, role = @role, updated_at = @updatedAt WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@role", user.Role);
                    command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("User update failed.");
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM users WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("User deletion failed.");
            }
        }

        public UserModel GetUserByCredentials(string username, string password)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Role = reader["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = reader["updated_at"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated_at"])
                    };
                }
            }

            return null;
        }
    }
}
