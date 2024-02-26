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
        

        public int Id_OrderItem { get; private set; }

        public int Quantity { get; private set; }
       
        public int Id_Product { get; private set; }

        public int Id_Cart { get; private set; }

        public Cart Cart { get; set; }

        public OrderItem( int quantity, int id_Product, int id_Cart)
        {
            Quantity = quantity;
            Id_Product = id_Product;
            Id_Cart = id_Cart;
        }

    

        public OrderItem(int id_OrderItem, int quantity, int id_Product, int id_Cart) : this(quantity, id_Product, id_Cart)
        {
            Id_OrderItem = id_OrderItem;
        }

        public OrderItem(int id_OrderItem, int quantity, int id_Product, int id_Cart, Cart cart)
        {
            Id_OrderItem = id_OrderItem;
            Quantity = quantity;
            Id_Product = id_Product;
            Id_Cart = id_Cart;
            Cart.AddOrderItem(this);
        }


        public void SetCart(Cart cart)
        {
            Cart = cart;
        }

        //public Product[] Products
        //{
        //    get
        //    {
        //        return _products?.ToArray() ?? new Product[0];
        //    }
        //}

        //public void AddProduct(Product product)
        //{
        //    _products ??= new List<Product>();
        //    if(product is null) throw new ArgumentNullException(nameof(product));
        //    if (_products.Contains(product)) throw new InvalidOperationException("Product already exists");
        //    _products.Add(product);
        //}

        //public void AddGroupProducts(IEnumerable<Product> products)
        //{
        //    if(products is null) throw new ArgumentNullException(nameof(products));
        //    foreach(var product in products)
        //    {
        //        AddProduct(product);
        //    }
        //}

        //public void RemoveProduct(Product product)
        //{
        //    if(product is null) throw new ArgumentNullException(nameof(product));
        //    if(!_products.Contains(product)) throw new InvalidOperationException("Product not found");
        //    _products.Remove(product);
        //}



        //public void AddToCart(Cart cart)
        //{
        //    _carts ??= new List<Cart>();
        //    if (cart is null) throw new ArgumentNullException(nameof(cart));
        //    if (_carts.Contains(cart)) throw new InvalidOperationException("Cart already exists");
        //    _carts.Add(cart);
        //}

        //public void AddGroupCarts(IEnumerable<Cart> carts)
        //{
        //    if (carts is null) throw new ArgumentNullException(nameof(carts));
        //    foreach (var cart in carts)
        //    {
        //        AddToCart(cart);
        //    }
        //}

        //public void RemoveFromCart(Cart cart)
        //{
        //    if (cart is null) throw new ArgumentNullException(nameof(cart));
        //    if (!_carts.Contains(cart)) throw new InvalidOperationException("Cart not found");
        //    _carts.Remove(cart);
        //}

    }
}
