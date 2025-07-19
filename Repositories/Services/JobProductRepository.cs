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
    class JobProductRepository : IJobProductRepository
    {
        public List<JobProductModel> GetAllJobProducts()
        {
            List<JobProductModel> jobProducts = new List<JobProductModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT jp.*, p.name as product_name, j.job_number 
                                FROM job_products jp
                                LEFT JOIN products p ON jp.product_id = p.id
                                LEFT JOIN jobs j ON jp.job_id = j.id
                                ORDER BY jp.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jobProducts.Add(new JobProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobId = reader["job_id"] != DBNull.Value ? Convert.ToInt32(reader["job_id"]) : (int?)null,
                        ProductId = reader["product_id"] != DBNull.Value ? Convert.ToInt32(reader["product_id"]) : (int?)null,
                        Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt32(reader["quantity"]) : (int?)null,
                        CustomWeight = reader["custom_weight"] != DBNull.Value ? Convert.ToDecimal(reader["custom_weight"]) : (decimal?)null,
                        CustomDimensions = reader["custom_dimensions"] != DBNull.Value ? reader["custom_dimensions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        ProductName = reader["product_name"] != DBNull.Value ? reader["product_name"].ToString() : null,
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    });
                }
            }

            return jobProducts;
        }

        public JobProductModel GetJobProductById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT jp.*, p.name as product_name, j.job_number 
                                FROM job_products jp
                                LEFT JOIN products p ON jp.product_id = p.id
                                LEFT JOIN jobs j ON jp.job_id = j.id
                                WHERE jp.id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new JobProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobId = reader["job_id"] != DBNull.Value ? Convert.ToInt32(reader["job_id"]) : (int?)null,
                        ProductId = reader["product_id"] != DBNull.Value ? Convert.ToInt32(reader["product_id"]) : (int?)null,
                        Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt32(reader["quantity"]) : (int?)null,
                        CustomWeight = reader["custom_weight"] != DBNull.Value ? Convert.ToDecimal(reader["custom_weight"]) : (decimal?)null,
                        CustomDimensions = reader["custom_dimensions"] != DBNull.Value ? reader["custom_dimensions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        ProductName = reader["product_name"] != DBNull.Value ? reader["product_name"].ToString() : null,
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    };
                }
            }

            return null;
        }

        public List<JobProductModel> GetJobProductsByJobId(int jobId)
        {
            List<JobProductModel> jobProducts = new List<JobProductModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT jp.*, p.name as product_name, j.job_number 
                                FROM job_products jp
                                LEFT JOIN products p ON jp.product_id = p.id
                                LEFT JOIN jobs j ON jp.job_id = j.id
                                WHERE jp.job_id = @jobId
                                ORDER BY jp.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@jobId", jobId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jobProducts.Add(new JobProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobId = reader["job_id"] != DBNull.Value ? Convert.ToInt32(reader["job_id"]) : (int?)null,
                        ProductId = reader["product_id"] != DBNull.Value ? Convert.ToInt32(reader["product_id"]) : (int?)null,
                        Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt32(reader["quantity"]) : (int?)null,
                        CustomWeight = reader["custom_weight"] != DBNull.Value ? Convert.ToDecimal(reader["custom_weight"]) : (decimal?)null,
                        CustomDimensions = reader["custom_dimensions"] != DBNull.Value ? reader["custom_dimensions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        ProductName = reader["product_name"] != DBNull.Value ? reader["product_name"].ToString() : null,
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    });
                }
            }

            return jobProducts;
        }

        public List<JobProductModel> GetJobProductsByProductId(int productId)
        {
            List<JobProductModel> jobProducts = new List<JobProductModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT jp.*, p.name as product_name, j.job_number 
                                FROM job_products jp
                                LEFT JOIN products p ON jp.product_id = p.id
                                LEFT JOIN jobs j ON jp.job_id = j.id
                                WHERE jp.product_id = @productId
                                ORDER BY jp.created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@productId", productId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jobProducts.Add(new JobProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobId = reader["job_id"] != DBNull.Value ? Convert.ToInt32(reader["job_id"]) : (int?)null,
                        ProductId = reader["product_id"] != DBNull.Value ? Convert.ToInt32(reader["product_id"]) : (int?)null,
                        Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt32(reader["quantity"]) : (int?)null,
                        CustomWeight = reader["custom_weight"] != DBNull.Value ? Convert.ToDecimal(reader["custom_weight"]) : (decimal?)null,
                        CustomDimensions = reader["custom_dimensions"] != DBNull.Value ? reader["custom_dimensions"].ToString() : null,
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"]),
                        ProductName = reader["product_name"] != DBNull.Value ? reader["product_name"].ToString() : null,
                        JobNumber = reader["job_number"] != DBNull.Value ? reader["job_number"].ToString() : null
                    });
                }
            }

            return jobProducts;
        }

        public int AddJobProduct(JobProductModel jobProduct)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO job_products (job_id, product_id, quantity, custom_weight, custom_dimensions) 
                                    VALUES (@job_id, @product_id, @quantity, @custom_weight, @custom_dimensions);
                                    SELECT LAST_INSERT_ID();";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@job_id", jobProduct.JobId);
                    command.Parameters.AddWithValue("@product_id", jobProduct.ProductId);
                    command.Parameters.AddWithValue("@quantity", jobProduct.Quantity);
                    command.Parameters.AddWithValue("@custom_weight", jobProduct.CustomWeight);
                    command.Parameters.AddWithValue("@custom_dimensions", jobProduct.CustomDimensions);

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

        public bool UpdateJobProduct(JobProductModel jobProduct)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE job_products SET job_id = @job_id, product_id = @product_id, 
                                    quantity = @quantity, custom_weight = @custom_weight, custom_dimensions = @custom_dimensions 
                                    WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", jobProduct.Id);
                    command.Parameters.AddWithValue("@job_id", jobProduct.JobId);
                    command.Parameters.AddWithValue("@product_id", jobProduct.ProductId);
                    command.Parameters.AddWithValue("@quantity", jobProduct.Quantity);
                    command.Parameters.AddWithValue("@custom_weight", jobProduct.CustomWeight);
                    command.Parameters.AddWithValue("@custom_dimensions", jobProduct.CustomDimensions);

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

        public bool DeleteJobProduct(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM job_products WHERE id = @id";
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

        public bool DeleteJobProductsByJobId(int jobId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM job_products WHERE job_id = @jobId";
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
