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
    public class MediaService : BaseService, IMediaRepository<Media>
    {
        public MediaService(IConfiguration configuration) : base(configuration, "DB_EcoEcommerce")
        {
        }

        public IEnumerable<Media> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Media]";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToMedia();
                        }
                    }
                }
            }
        }

        public Media GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Media] WHERE [Id_Media] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Id_Media", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToMedia();
                        throw new ArgumentException(nameof(id), $"Media Id {id} not found");
                    }
                }
            }

        }
        public IEnumerable<Media> GetMediaForProduct(int id_Product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Media] WHERE [Id_Product] = @id_Product";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_Product", id_Product);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToMedia();
                        }
                    }
                }
            }
        }

        public Media GetSingleImageForProduct(int id_Product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT TOP 1 * FROM [Media] WHERE [Id_Product] = @id_Product";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_Product", id_Product);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToMedia();
                        }
                    }
                }
            }
            return null; 
        }




        public int Insert(Media entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Media_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ImgUrl", entity.ImgUrl);
                    command.Parameters.AddWithValue("Id_Product", entity.Id_Product);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Media entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Media_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Media", entity.Id_Media);
                    command.Parameters.AddWithValue("ImgUrl", entity.ImgUrl);
                    command.Parameters.AddWithValue("Id_Product", entity.Id_Product);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(entity.Id_Media), $"Media Id {entity.Id_Media} not found");
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Media] WHERE [Id_Media] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_Media", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(id), $"Media Id {id} not found");
                }
            }
        }

        public void DeleteByProductId(int id_Product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Media] WHERE [Id_Product] = @id_Product";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_Product", id_Product);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(id_Product), $"Media for Product Id {id_Product} not found");
                }
            }
        }


    }
}
