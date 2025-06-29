using AD_CW_1.Database;
using AD_CW_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories
{
    class CustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM customers";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["created_date"])
                    });
                }
            }

            return customers;
        }

        public Customer GetCustomerById(int id)
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
                    return new Customer
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["created_date"])
                    };
                }
            }

            return null;
        }

        public Customer GetCustomerByCredentials(string customerNumber, string password)
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
                    return new Customer
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerNumber = reader["customer_number"].ToString(),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["created_date"])
                    };
                }
            }

            return null;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO customers (customer_number, name, address, phone, email, password, created_date) 
                                VALUES (@customerNumber, @name, @address, @phone, @email, @password, @createdDate)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerNumber", customer.CustomerNumber);
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@password", customer.Password);
                    command.Parameters.AddWithValue("@createdDate", DateTime.Now);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
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
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
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
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }
    }
}
