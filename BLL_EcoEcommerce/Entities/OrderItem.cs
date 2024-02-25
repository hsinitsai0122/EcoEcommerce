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
        //private Product _product;
        private List<Product> _products;
        private List<Cart> _carts;

        public int Id_OrderItem { get; private set; }

        public int Quantity { get; private set; }
       
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

        public Cart[] Carts
        {
            get
            {
                return _carts?.ToArray() ?? new Cart[0];
            }
        }

        public Product[] Products
        {
            get
            {
                return _products?.ToArray() ?? new Product[0];
            }
        }

        public void AddToCart(Cart cart)
        {
            _carts ??= new List<Cart>();
            if(cart is null) throw new ArgumentNullException(nameof(cart));
            if (_carts.Contains(cart)) throw new InvalidOperationException("Cart already exists");
            _carts.Add(cart);
        }

        public void AddGroupCarts(IEnumerable<Cart> carts)
        {
            if(carts is null) throw new ArgumentNullException(nameof(carts));
            foreach(var cart in carts)
            {
                AddToCart(cart);
            }
        }

        public void RemoveFromCart(Cart cart)
        {
            if(cart is null) throw new ArgumentNullException(nameof(cart));
            if(!_carts.Contains(cart)) throw new InvalidOperationException("Cart not found");
            _carts.Remove(cart);
        }

    }
}
