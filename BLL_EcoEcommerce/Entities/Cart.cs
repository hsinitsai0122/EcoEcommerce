using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class Cart
    {
        public List<OrderItem> _orderItems;
        public int Id_Cart { get; private set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDate { get; private set; }
        
        public OrderItem? this[int index]
        { 
           get
            { 
                return _orderItems.SingleOrDefault(d => d.Id_OrderItem == index);
            }   
         }
        public OrderItem[] OrderItems
        {
            get
            {
                return _orderItems.ToArray();
            }
        }
        public Cart(int id_Cart, string orderNumber, DateTime orderDate)
        {
            Id_Cart = id_Cart;
            OrderNumber = orderNumber;
            OrderDate = DateTime.Now;
        }

        public Cart(int id_Cart, string orderNumber, DateTime orderDate, List<OrderItem> orderItems)
        {
            Id_Cart = id_Cart;
            OrderNumber = orderNumber;
            OrderDate = DateTime.Now;
            _orderItems = orderItems;
        }
        public Cart()
        {
            _orderItems = new List<OrderItem>();
        }

        public void AddToCart(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        public void RemoveFromCart(int id_OrderItem)
        {
            _orderItems.Remove(_orderItems.SingleOrDefault(d => d.Id_OrderItem == id_OrderItem));
        }

        public void ClearCart()
        {
            _orderItems.Clear();
        }

        public decimal CartTotal()
        {
            decimal cartTotal = 0;
            foreach (OrderItem orderItem in _orderItems)
            {
                cartTotal += orderItem.ItemPrice;
            }
            return cartTotal;
        }



    }
}
