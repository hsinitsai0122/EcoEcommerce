using DAL_EcoEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class OrderItem
    {
        private Product _product;

        public int Id_OrderItem { get; private set; }

        public int Quantity { get; private set; }
        public decimal ItemPrice => _product != null ? _product.Price * Quantity : 0;
        public int Id_Product { get; private set; }

        public int Id_Cart { get; private set; }

        public OrderItem(int id_OrderItem, int quantity, int id_Product, int id_Cart)
        {
            Id_OrderItem = id_OrderItem;
            Quantity = quantity;
            Id_Product = id_Product;
            Id_Cart = id_Cart;
        }

        public OrderItem(int id_OrderItem, int quantity, int id_Product)
        {
            Id_OrderItem = id_OrderItem;
            Quantity = quantity;
            Id_Product = id_Product;
        }

    }
}
