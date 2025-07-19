using AD_CW_1.Database;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories
{
    class TruckRepository : ITruckRepository
    {
        public List<TruckModel> GetAllTrucks()
        {
            List<TruckModel> trucks = new List<TruckModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM trucks";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trucks.Add(new TruckModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TruckNumber = reader["truck_number"].ToString(),
                        Model = reader["model"].ToString(),
                        LicensePlate = reader["license_plate"].ToString(),
                        Status = reader["status"].ToString(),
                        Capacity = Convert.ToInt32(reader["capacity"]),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    });
                }
            }

            return trucks;
        }

        public TruckModel GetTruckById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM trucks WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new TruckModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TruckNumber = reader["truck_number"].ToString(),
                        Model = reader["model"].ToString(),
                        LicensePlate = reader["license_plate"].ToString(),
                        Status = reader["status"].ToString(),
                        Capacity = Convert.ToInt32(reader["capacity"]),
                        CreatedAt = Convert.ToDateTime(reader["created_at"])
                    };
                }
            }

            return null;
        }

        public bool AddTruck(TruckModel truck)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO trucks (truck_number, model, license_plate , status , capacity, created_at) 
                                    VALUES (@truckNumber, @model, @licensePlate, @status, @capacity, @createdAt )";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@truckNumber", truck.TruckNumber);
                    command.Parameters.AddWithValue("@model", truck.Model);
                    command.Parameters.AddWithValue("@licensePlate", truck.LicensePlate);
                    command.Parameters.AddWithValue("@status", truck.Status);
                    command.Parameters.AddWithValue("@capacity", truck.Capacity);
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

        public bool UpdateTruck(TruckModel truck)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE trucks SET truck_number = @truckNumber, model = @model, 
                                    license_plate = @licensePlate, status = @status, capacity = @capacity, 
                                    updated_at = @updatedAt WHERE id = @id";   

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", truck.Id);
                    command.Parameters.AddWithValue("@truckNumber", truck.TruckNumber);
                    command.Parameters.AddWithValue("@model", truck.Model);
                    command.Parameters.AddWithValue("@licensePlate", truck.LicensePlate);
                    command.Parameters.AddWithValue("@status", truck.Status);
                    command.Parameters.AddWithValue("@capacity", truck.Capacity);
                    command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

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

        public bool DeleteTruck(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM trucks WHERE id = @id";
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
