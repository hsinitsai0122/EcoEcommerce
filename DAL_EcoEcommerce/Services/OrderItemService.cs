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
    public class OrderItemService : BaseService, IOrderItemRepository<OrderItem>
    {
        public OrderItemService(IConfiguration configuration) : base(configuration, "DB_EcoEcommerce")
        {
        }

        public IEnumerable<OrderItem> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [OrderItem]";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToOrderItem();
                        }
                    }
                }
            }
        }

        public OrderItem GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [OrderItem] WHERE [Id_OrderItem] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Id_OrderItem", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToOrderItem();
                        throw new ArgumentException(nameof(id), $"OrderItem Id {id} not found");
                    }
                }
            }
        }

        public int Insert(OrderItem entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_OrderItem_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Quantity", entity.Quantity);
                    command.Parameters.AddWithValue("Id_Product", entity.Id_Product);
                    command.Parameters.AddWithValue("Id_Cart", entity.Id_Cart);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(OrderItem entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_OrderItem_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_OrderItem", entity.Id_OrderItem);
                    command.Parameters.AddWithValue("Quantity", entity.Quantity);
                    command.Parameters.AddWithValue("Id_Product", entity.Id_Product);
                    command.Parameters.AddWithValue("Id_Cart", entity.Id_Cart);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(entity.Id_Cart), $"OrderItem Id {entity.Id_OrderItem} not found");
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [OrderItem] WHERE [Id_OrderItem] = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("Id_OrderItem", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(id), $"OrderItem Id {id} not found");
                }
            }
        }

    }
}
