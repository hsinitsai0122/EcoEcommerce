using DAL_EcoEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_EcoEcommerce.Repositories;
using Microsoft.Extensions.Configuration;
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
                        while (reader.Read()) yield return reader.ToOrderItem();
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
                    command.CommandText = "SELECT * FROM [OrderItem] WHERE [Id_OrderItem] = @id_OrderItem";
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

        public IEnumerable<OrderItem> GetAllItemsByIdCart(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection; // Assign the connection to the command
                    command.CommandText = "SELECT * FROM [OrderItem] WHERE [Id_Cart]= @id_Cart";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("id_Cart", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) yield return reader.ToOrderItem();
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
                        throw new ArgumentException(nameof(entity.Id_Cart), $"Order Item Id {entity.Id_OrderItem} not found");
                }
            }
        }
        public void UpdateOrderItemQuantity(int id_orderItem, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [OrderItem] SET [Quantity] = @Quantity WHERE [Id_OrderItem] = @Id_OrderItem";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Id_OrderItem", id_orderItem);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                        throw new ArgumentException(nameof(id_orderItem), $"OrderItem Id {id_orderItem} not found");
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [OrderItem] WHERE [Id_OrderItem] = @id_OrderItem";
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
