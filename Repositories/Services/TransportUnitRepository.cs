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
    class TransportUnitRepository : ITransportUnitRepository
    {
        public List<TransportUnitModel> GetAllTransportUnits()
        {
            List<TransportUnitModel> units = new List<TransportUnitModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT tu.*, t.truck_number, d.name as driver_name, a.name as assistant_name
                                FROM transport_units tu
                                LEFT JOIN trucks t ON tu.truck_id = t.id
                                LEFT JOIN drivers d ON tu.driver_id = d.id
                                LEFT JOIN assistants a ON tu.assistant_id = a.id
                                ORDER BY tu.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    units.Add(new TransportUnitModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        UnitNumber = reader["unit_number"].ToString(),
                        TruckId = Convert.ToInt32(reader["truck_id"]),
                        DriverId = Convert.ToInt32(reader["driver_id"]),
                        AssistantId = reader["assistant_id"] != DBNull.Value ? Convert.ToInt32(reader["assistant_id"]) : (int?)null,
                        Status = reader["status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        TruckNumber = reader["truck_number"] != DBNull.Value ? reader["truck_number"].ToString() : null,
                        DriverName = reader["driver_name"] != DBNull.Value ? reader["driver_name"].ToString() : null,
                        AssistantName = reader["assistant_name"] != DBNull.Value ? reader["assistant_name"].ToString() : null
                    });
                }
            }

            return units;
        }

        public TransportUnitModel GetTransportUnitById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT tu.*, t.truck_number, d.name as driver_name, a.name as assistant_name
                                FROM transport_units tu
                                LEFT JOIN trucks t ON tu.truck_id = t.id
                                LEFT JOIN drivers d ON tu.driver_id = d.id
                                LEFT JOIN assistants a ON tu.assistant_id = a.id
                                WHERE tu.id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new TransportUnitModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        UnitNumber = reader["unit_number"].ToString(),
                        TruckId = Convert.ToInt32(reader["truck_id"]),
                        DriverId = Convert.ToInt32(reader["driver_id"]),
                        AssistantId = reader["assistant_id"] != DBNull.Value ? Convert.ToInt32(reader["assistant_id"]) : (int?)null,
                        Status = reader["status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        TruckNumber = reader["truck_number"] != DBNull.Value ? reader["truck_number"].ToString() : null,
                        DriverName = reader["driver_name"] != DBNull.Value ? reader["driver_name"].ToString() : null,
                        AssistantName = reader["assistant_name"] != DBNull.Value ? reader["assistant_name"].ToString() : null
                    };
                }
            }

            return null;
        }

        public bool AddTransportUnit(TransportUnitModel transportUnit)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO transport_units (unit_number, truck_id, driver_id, assistant_id, status) 
                                    VALUES (@unit_number, @truck_id, @driver_id, @assistant_id, @status)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@unit_number", transportUnit.UnitNumber);
                    command.Parameters.AddWithValue("@truck_id", transportUnit.TruckId);
                    command.Parameters.AddWithValue("@driver_id", transportUnit.DriverId);
                    command.Parameters.AddWithValue("@assistant_id", transportUnit.AssistantId);
                    command.Parameters.AddWithValue("@status", transportUnit.Status);

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

        public bool UpdateTransportUnit(TransportUnitModel transportUnit)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE transport_units SET unit_number = @unit_number, truck_id = @truck_id, 
                                    driver_id = @driver_id, assistant_id = @assistant_id, status = @status 
                                    WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", transportUnit.Id);
                    command.Parameters.AddWithValue("@unit_number", transportUnit.UnitNumber);
                    command.Parameters.AddWithValue("@truck_id", transportUnit.TruckId);
                    command.Parameters.AddWithValue("@driver_id", transportUnit.DriverId);
                    command.Parameters.AddWithValue("@assistant_id", transportUnit.AssistantId);
                    command.Parameters.AddWithValue("@status", transportUnit.Status);

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

        public bool DeleteTransportUnit(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM transport_units WHERE id = @id";
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
