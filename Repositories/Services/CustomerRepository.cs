using AD_CW_1.Database;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    });
                }
            }

            return customers;
        }

        public CustomerModel GetCustomerById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    };
                }
            }

            return null;
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers WHERE email = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    };
                }
            }

            return null;
        }

        public CustomerModel GetCustomerByCredentials(string customerNumber, string password)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers WHERE customer_number = @customerNumber AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerNumber", customerNumber);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    };
                }
            }

            return null;
        }

        public bool AddCustomer(CustomerModel customer)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO customers (customer_number, name, address, phone, email, user_id, created_at) 
                                    VALUES (@customerNumber, @name, @address, @phone, @email,@userId, @CreatedAt)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerNumber", customer.CustomerNumber);
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@userId", customer.UserId);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE customers SET name = @name, address = @address, 
                                    phone = @phone, email = @email WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@email", customer.Email);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM customers WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CustomerModel GetCustomerByUserId(int userId)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers WHERE user_id = @userId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    };
                }
            }

            return null;
        }
    }
}
