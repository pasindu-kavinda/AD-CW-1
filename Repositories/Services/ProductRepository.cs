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
    class ProductRepository : IProductRepository
    {
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM products ORDER BY created_at DESC";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Weight = reader["weight"] != DBNull.Value ? Convert.ToDecimal(reader["weight"]) : (decimal?)null,
                        Dimensions = reader["dimensions"] != DBNull.Value ? reader["dimensions"].ToString() : "",
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                    });
                }
            }

            return products;
        }

        public ProductModel GetProductById(int id)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM products WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ProductModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Weight = reader["weight"] != DBNull.Value ? Convert.ToDecimal(reader["weight"]) : (decimal?)null,
                        Dimensions = reader["dimensions"] != DBNull.Value ? reader["dimensions"].ToString() : "",
                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                    };
                }
            }

            return null;
        }

        public bool AddProduct(ProductModel product)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO products (name, weight, dimensions)   
                                       VALUES (@name, @weight, @dimensions)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@weight", product.Weight);
                    command.Parameters.AddWithValue("@dimensions", product.Dimensions);

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

        public bool UpdateProduct(ProductModel product)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE products SET name = @name, weight = @weight, dimensions = @dimensions   
                                       WHERE id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", product.Id);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@weight", product.Weight);
                    command.Parameters.AddWithValue("@dimensions", product.Dimensions);

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

        public bool DeleteProduct(int id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM products WHERE id = @id";
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
