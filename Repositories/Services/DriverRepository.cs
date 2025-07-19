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
    class DriverRepository : IDriverRepository
    {
        public List<DriverModel> GetAllDrivers()
        {
            List<DriverModel> drivers = new List<DriverModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM drivers ORDER BY created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drivers.Add(new DriverModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        LicenseNumber = reader["license_number"].ToString(),
                        Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : null,
                        Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : null,
                        Status = reader["status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                    });
                }
            }

            return drivers;
        }

        public DriverModel GetDriverById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM drivers WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new DriverModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        LicenseNumber = reader["license_number"].ToString(),
                        Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : null,
                        Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : null,
                        Status = reader["status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                    };
                }
            }

            return null;
        }

        public bool AddDriver(DriverModel driver)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO drivers (name, license_number, phone, address, status) 
                                    VALUES (@name, @license_number, @phone, @address, @status)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", driver.Name);
                    command.Parameters.AddWithValue("@license_number", driver.LicenseNumber);
                    command.Parameters.AddWithValue("@phone", driver.Phone);
                    command.Parameters.AddWithValue("@address", driver.Address);
                    command.Parameters.AddWithValue("@status", driver.Status);

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

        public bool UpdateDriver(DriverModel driver)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE drivers SET name = @name, license_number = @license_number, 
                                    phone = @phone, address = @address, status = @status WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", driver.Id);
                    command.Parameters.AddWithValue("@name", driver.Name);
                    command.Parameters.AddWithValue("@license_number", driver.LicenseNumber);
                    command.Parameters.AddWithValue("@phone", driver.Phone);
                    command.Parameters.AddWithValue("@address", driver.Address);
                    command.Parameters.AddWithValue("@status", driver.Status);

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

        public bool DeleteDriver(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM drivers WHERE id = @id";
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
    }
}
