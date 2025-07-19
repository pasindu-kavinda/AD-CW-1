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
    class AssistantRepository : IAssistantRepository
    {
        public List<AssistantModel> GetAllAssistants()
        {
            List<AssistantModel> assistants = new List<AssistantModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM assistants ORDER BY created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    assistants.Add(new AssistantModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : null,
                        Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : null,
                        Status = reader["status"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                    });
                }
            }

            return assistants;
        }

        public AssistantModel GetAssistantById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM assistants WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new AssistantModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
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

        public bool AddAssistant(AssistantModel assistant)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO assistants (name, phone, address, status) 
                                    VALUES (@name, @phone, @address, @status)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", assistant.Name);
                    command.Parameters.AddWithValue("@phone", assistant.Phone);
                    command.Parameters.AddWithValue("@address", assistant.Address);
                    command.Parameters.AddWithValue("@status", assistant.Status);

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

        public bool UpdateAssistant(AssistantModel assistant)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE assistants SET name = @name, phone = @phone, 
                                    address = @address, status = @status WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", assistant.Id);
                    command.Parameters.AddWithValue("@name", assistant.Name);
                    command.Parameters.AddWithValue("@phone", assistant.Phone);
                    command.Parameters.AddWithValue("@address", assistant.Address);
                    command.Parameters.AddWithValue("@status", assistant.Status);

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

        public bool DeleteAssistant(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM assistants WHERE id = @id";
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
