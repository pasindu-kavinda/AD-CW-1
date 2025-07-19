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
    class JobRepository : IJobRepository
    {
        public List<JobModel> GetAllJobs()
        {
            List<JobModel> jobs = new List<JobModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT j.*, c.name as customer_name, tu.unit_number as transport_unit_number
                                FROM jobs j
                                LEFT JOIN customers c ON j.customer_id = c.id
                                LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                                ORDER BY j.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jobs.Add(new JobModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobNumber = reader["job_number"].ToString(),
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        PickupLocation = reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"].ToString(),
                        RequestDate = Convert.ToDateTime(reader["request_date"]),
                        ScheduledDate = reader["scheduled_date"] != DBNull.Value ? Convert.ToDateTime(reader["scheduled_date"]) : (DateTime?)null,
                        CompletionDate = reader["completion_date"] != DBNull.Value ? Convert.ToDateTime(reader["completion_date"]) : (DateTime?)null,
                        Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                        EstimatedCost = Convert.ToDecimal(reader["estimated_cost"]),
                        ActualCost = reader["actual_cost"] != DBNull.Value ? Convert.ToDecimal(reader["actual_cost"]) : (decimal?)null,
                        Status = reader["status"].ToString(),
                        TransportUnitId = reader["transport_unit_id"] != DBNull.Value ? Convert.ToInt32(reader["transport_unit_id"]) : (int?)null,
                        Notes = reader["notes"] != DBNull.Value ? reader["notes"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        CustomerName = reader["customer_name"] != DBNull.Value ? reader["customer_name"].ToString() : null,
                        TransportUnitNumber = reader["transport_unit_number"] != DBNull.Value ? reader["transport_unit_number"].ToString() : null
                    });
                }
            }

            return jobs;
        }

        public JobModel GetJobById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT j.*, c.name as customer_name, tu.unit_number as transport_unit_number
                                FROM jobs j
                                LEFT JOIN customers c ON j.customer_id = c.id
                                LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                                WHERE j.id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new JobModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobNumber = reader["job_number"].ToString(),
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        PickupLocation = reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"].ToString(),
                        RequestDate = Convert.ToDateTime(reader["request_date"]),
                        ScheduledDate = reader["scheduled_date"] != DBNull.Value ? Convert.ToDateTime(reader["scheduled_date"]) : (DateTime?)null,
                        CompletionDate = reader["completion_date"] != DBNull.Value ? Convert.ToDateTime(reader["completion_date"]) : (DateTime?)null,
                        Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                        EstimatedCost = Convert.ToDecimal(reader["estimated_cost"]),
                        ActualCost = reader["actual_cost"] != DBNull.Value ? Convert.ToDecimal(reader["actual_cost"]) : (decimal?)null,
                        Status = reader["status"].ToString(),
                        TransportUnitId = reader["transport_unit_id"] != DBNull.Value ? Convert.ToInt32(reader["transport_unit_id"]) : (int?)null,
                        Notes = reader["notes"] != DBNull.Value ? reader["notes"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        CustomerName = reader["customer_name"] != DBNull.Value ? reader["customer_name"].ToString() : null,
                        TransportUnitNumber = reader["transport_unit_number"] != DBNull.Value ? reader["transport_unit_number"].ToString() : null
                    };
                }
            }

            return null;
        }

        public int AddJob(JobModel job)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO jobs (job_number, customer_id, pickup_location, delivery_location, 
                                    request_date, scheduled_date, description, estimated_cost, status, notes) 
                                    VALUES (@job_number, @customer_id, @pickup_location, @delivery_location, 
                                    @request_date, @scheduled_date, @description, @estimated_cost, @status, @notes);
                                    SELECT LAST_INSERT_ID();";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@job_number", job.JobNumber);
                    command.Parameters.AddWithValue("@customer_id", job.CustomerId);
                    command.Parameters.AddWithValue("@pickup_location", job.PickupLocation);
                    command.Parameters.AddWithValue("@delivery_location", job.DeliveryLocation);
                    command.Parameters.AddWithValue("@request_date", job.RequestDate);
                    command.Parameters.AddWithValue("@scheduled_date", job.ScheduledDate);
                    command.Parameters.AddWithValue("@description", job.Description);
                    command.Parameters.AddWithValue("@estimated_cost", job.EstimatedCost);
                    command.Parameters.AddWithValue("@status", job.Status);
                    command.Parameters.AddWithValue("@notes", job.Notes);

                    connection.Open();
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    return id;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool UpdateJob(JobModel job)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE jobs SET job_number = @job_number, customer_id = @customer_id, 
                                    pickup_location = @pickup_location, delivery_location = @delivery_location, 
                                    request_date = @request_date, scheduled_date = @scheduled_date, 
                                    completion_date = @completion_date, description = @description, 
                                    estimated_cost = @estimated_cost, actual_cost = @actual_cost, 
                                    status = @status, transport_unit_id = @transport_unit_id, notes = @notes 
                                    WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", job.Id);
                    command.Parameters.AddWithValue("@job_number", job.JobNumber);
                    command.Parameters.AddWithValue("@customer_id", job.CustomerId);
                    command.Parameters.AddWithValue("@pickup_location", job.PickupLocation);
                    command.Parameters.AddWithValue("@delivery_location", job.DeliveryLocation);
                    command.Parameters.AddWithValue("@request_date", job.RequestDate);
                    command.Parameters.AddWithValue("@scheduled_date", job.ScheduledDate);
                    command.Parameters.AddWithValue("@completion_date", job.CompletionDate);
                    command.Parameters.AddWithValue("@description", job.Description);
                    command.Parameters.AddWithValue("@estimated_cost", job.EstimatedCost);
                    command.Parameters.AddWithValue("@actual_cost", job.ActualCost);
                    command.Parameters.AddWithValue("@status", job.Status);
                    command.Parameters.AddWithValue("@transport_unit_id", job.TransportUnitId);
                    command.Parameters.AddWithValue("@notes", job.Notes);

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

        public bool DeleteJob(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM jobs WHERE id = @id";
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

        public List<JobModel> GetJobsByCustomerId(int customerId)
        {
            List<JobModel> jobs = new List<JobModel>();
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT j.*, c.name as customer_name, tu.unit_number as transport_unit_number
                                FROM jobs j
                                LEFT JOIN customers c ON j.customer_id = c.id
                                LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                                WHERE j.customer_id = @customerId
                                ORDER BY j.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", customerId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jobs.Add(new JobModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobNumber = reader["job_number"].ToString(),
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        PickupLocation = reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"].ToString(),
                        RequestDate = Convert.ToDateTime(reader["request_date"]),
                        ScheduledDate = reader["scheduled_date"] != DBNull.Value ? Convert.ToDateTime(reader["scheduled_date"]) : (DateTime?)null,
                        CompletionDate = reader["completion_date"] != DBNull.Value ? Convert.ToDateTime(reader["completion_date"]) : (DateTime?)null,
                        Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                        EstimatedCost = Convert.ToDecimal(reader["estimated_cost"]),
                        ActualCost = reader["actual_cost"] != DBNull.Value ? Convert.ToDecimal(reader["actual_cost"]) : (decimal?)null,
                        Status = reader["status"].ToString(),
                        TransportUnitId = reader["transport_unit_id"] != DBNull.Value ? Convert.ToInt32(reader["transport_unit_id"]) : (int?)null,
                        Notes = reader["notes"] != DBNull.Value ? reader["notes"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        CustomerName = reader["customer_name"] != DBNull.Value ? reader["customer_name"].ToString() : null,
                        TransportUnitNumber = reader["transport_unit_number"] != DBNull.Value ? reader["transport_unit_number"].ToString() : null
                    });
                }
            }
            return jobs;

        }
    }
}
