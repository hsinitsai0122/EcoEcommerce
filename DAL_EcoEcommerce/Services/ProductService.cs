using DAL_EcoEcommerce.Entities;
using Microsoft.Extensions.Configuration;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_EcoEcommerce.Mappers;

namespace DAL_EcoEcommerce.Services
{
    public class ProductService : BaseService, IProductRepository<Product>
    {
        public ProductService(IConfiguration configuration) : base(configuration, "DB_EcoEcommerce")
        {
        }

        public IEnumerable<Product> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToProduct();
                        }
                    }
                }
            }
        }

        public Product GetById(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Product", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read()) return reader.ToProduct();
                        throw new ArgumentException(nameof(id), $"Product with id {id} not found");
                    }
                }
            }
        }


        public string GetProductNameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Name] FROM [Product] WHERE [Id_Product] = @id_Product";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id_Product", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.GetString(0); // Retrieve the product name as a string
                        throw new ArgumentException(nameof(id), $"Product with id {id} not found");
                    }
                }
            }
        }

        public IEnumerable<Product> FilterByPopularity()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_FilterByPopularity";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToProduct();
                        }
                    }
                }
            }
        }

        public IEnumerable<Product> FilterByName (string name)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_FilterByName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", name);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToProduct();
                        }
                    }
                }
            }
        }

        public IEnumerable<Product> FilterByCateg(string proCateg)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_FilterByCateg";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("proCateg", proCateg); // Correct parameter name
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToProduct();
                        }
                    }
                }
            }
        }


        public IEnumerable<Product> FilterByEcoScore(string ecoCriteria)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_FilterByEcoScore";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EcoCriteria", ecoCriteria);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToProduct();
                        }
                    }
                }
            }
        }

        public int Insert(Product entity)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Name", entity.Name);
                    command.Parameters.AddWithValue("Description", entity.Description);
                    command.Parameters.AddWithValue("Price", entity.Price);
                    command.Parameters.AddWithValue("ProCateg", entity.ProCateg);
                    command.Parameters.AddWithValue("EcoCriteria", entity.EcoCriteria);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Product entity)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Product", entity.Id_Product);
                    command.Parameters.AddWithValue("Name", entity.Name);
                    command.Parameters.AddWithValue("Description", entity.Description);
                    command.Parameters.AddWithValue("Price", entity.Price);
                    command.Parameters.AddWithValue("ProCateg", entity.ProCateg);
                    command.Parameters.AddWithValue("EcoCriteria", entity.EcoCriteria);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentException(nameof(entity.Id_Product), $"Product with id {entity.Id_Product} not found");
                }
            }
        }
        public void Delete(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Product_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Product", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentException(nameof(id), $"Product with id {id} not found");
                }
            }
        }


    }
}
