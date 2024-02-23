using DAL_EcoEcommerce.Entities;
using DAL_EcoEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Mappers
{
    internal static class Mapper
    {
        public static Product ToProduct(this IDataRecord record)
        {
            if (record is null) return null;
            return new Product
            {
                Id_Product = (int)record["Id_Product"],
                Name = (string)record["Name"],
                Description = (string)record["Description"],
                Price = (decimal)record["Price"],
                ProCateg = (string)record["ProCateg"],
                EcoCriteria = (string)record["EcoCriteria"]
            };
        }
        public static Media ToMedia(this IDataRecord record)
        {
            if (record is null) return null;
            return new Media
            {
                Id_Media = (int)record["Id_Media"],
                ImgUrl = (string)record["ImgUrl"],
                Id_Product = (int)record["Id_Product"]
            };
        }

        public static Cart ToCart(this IDataRecord record)
        {
            if (record is null) return null;
            return new Cart
            {
                Id_Cart = (int)record["Id_Cart"],
                OrderNumber = (string)record["OrderNumber"],
                OrderDate = (DateTime)record["OrderDate"]
            };
        }

        public static OrderItem ToOrderItem(this IDataRecord record)
        {
            if (record is null) return null;
            return new OrderItem
            {
                Id_OrderItem = (int)record["Id_OrderItem"],
                Quantity = (int)record["Quantity"],
                Id_Product = (int)record["Id_Product"],
                Id_Cart = (int)record["Id_Cart"]
            };
        }
    }
}
