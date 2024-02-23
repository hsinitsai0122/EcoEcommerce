using DAL_EcoEcommerce.Entities;
using Microsoft.Extensions.Configuration;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_EcoEcommerce.Mappers;

namespace DAL_EcoEcommerce.Services
{
    public class CartService : BaseService, ICartRepository<Cart>
    {
        public CartService(IConfiguration configuration) : base(configuration, "DB_EcoEcommerce")
        {
        }

        public IEnumerable<Cart> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Cart]";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCart();
                        }
                    }
                }
            }
        }

        public Cart GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Cart] WHERE [Id_Cart] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Id_Cart", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToCart();
                        throw new ArgumentException(nameof(id), $"Cart Id {id} not found");
                    }
                }
            }
        }

        public int Insert(Cart entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cart_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("OrderNumber", entity.OrderNumber);
                    command.Parameters.AddWithValue("OrderDate", entity.OrderDate);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Cart entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cart_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Cart", entity.Id_Cart);
                    command.Parameters.AddWithValue("OrderNumber", entity.OrderNumber);
                    command.Parameters.AddWithValue("OrderDate", entity.OrderDate);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(entity.Id_Cart), $"Cart Id {entity.Id_Cart} not found");
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Cart] WHERE [Id_Cart] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_Cart", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(id), $"Cart Id {id} not found");
                }
            }
        }

    }
}
