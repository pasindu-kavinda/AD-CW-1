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
    class LoadRepository : ILoadRepository
    {
        public List<LoadModel> GetAllLoads()
        {
            List<LoadModel> loads = new List<LoadModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT l.*, j.job_number 
                                FROM loads l
                                LEFT JOIN jobs j ON l.job_id = j.id
                                ORDER BY l.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    loads.Add(new LoadModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        LoadNumber = reader["load_number"].ToString(),
                        JobId = Convert.ToInt32(reader["job_id"]),
                        Description = reader["description"].ToString(),
                        Weight = Convert.ToDecimal(reader["weight"]),
                        Volume = Convert.ToDecimal(reader["volume"]),
                        Instructions = reader["instructions"] != DBNull.Value ? reader["instructions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    });
                }
            }

            return loads;
        }

        public LoadModel GetLoadById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT l.*, j.job_number 
                                FROM loads l
                                LEFT JOIN jobs j ON l.job_id = j.id
                                WHERE l.id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new LoadModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        LoadNumber = reader["load_number"].ToString(),
                        JobId = Convert.ToInt32(reader["job_id"]),
                        Description = reader["description"].ToString(),
                        Weight = Convert.ToDecimal(reader["weight"]),
                        Volume = Convert.ToDecimal(reader["volume"]),
                        Instructions = reader["instructions"] != DBNull.Value ? reader["instructions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    };
                }
            }

            return null;
        }

        public List<LoadModel> GetLoadsByJobId(int jobId)
        {
            List<LoadModel> loads = new List<LoadModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT l.*, j.job_number 
                                FROM loads l
                                LEFT JOIN jobs j ON l.job_id = j.id
                                WHERE l.job_id = @jobId
                                ORDER BY l.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@jobId", jobId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    loads.Add(new LoadModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        LoadNumber = reader["load_number"].ToString(),
                        JobId = Convert.ToInt32(reader["job_id"]),
                        Description = reader["description"].ToString(),
                        Weight = Convert.ToDecimal(reader["weight"]),
                        Volume = Convert.ToDecimal(reader["volume"]),
                        Instructions = reader["instructions"] != DBNull.Value ? reader["instructions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    });
                }
            }

            return loads;
        }

        public LoadModel GetLoadByLoadNumber(string loadNumber)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT l.*, j.job_number 
                                FROM loads l
                                LEFT JOIN jobs j ON l.job_id = j.id
                                WHERE l.load_number = @loadNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@loadNumber", loadNumber);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new LoadModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        LoadNumber = reader["load_number"].ToString(),
                        JobId = Convert.ToInt32(reader["job_id"]),
                        Description = reader["description"].ToString(),
                        Weight = Convert.ToDecimal(reader["weight"]),
                        Volume = Convert.ToDecimal(reader["volume"]),
                        Instructions = reader["instructions"] != DBNull.Value ? reader["instructions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    };
                }
            }

            return null;
        }

        public bool AddLoad(LoadModel load)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO loads (load_number, job_id, description, weight, volume, instructions) 
                                    VALUES (@load_number, @job_id, @description, @weight, @volume, @instructions)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@load_number", load.LoadNumber);
                    command.Parameters.AddWithValue("@job_id", load.JobId);
                    command.Parameters.AddWithValue("@description", load.Description);
                    command.Parameters.AddWithValue("@weight", load.Weight);
                    command.Parameters.AddWithValue("@volume", load.Volume);
                    command.Parameters.AddWithValue("@instructions", load.Instructions);

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

        public bool UpdateLoad(LoadModel load)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE loads SET load_number = @load_number, job_id = @job_id, 
                                    description = @description, weight = @weight, volume = @volume, 
                                    instructions = @instructions WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", load.Id);
                    command.Parameters.AddWithValue("@load_number", load.LoadNumber);
                    command.Parameters.AddWithValue("@job_id", load.JobId);
                    command.Parameters.AddWithValue("@description", load.Description);
                    command.Parameters.AddWithValue("@weight", load.Weight);
                    command.Parameters.AddWithValue("@volume", load.Volume);
                    command.Parameters.AddWithValue("@instructions", load.Instructions);

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

        public bool DeleteLoad(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM loads WHERE id = @id";
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

        public bool DeleteLoadsByJobId(int jobId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM loads WHERE job_id = @jobId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@jobId", jobId);

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
