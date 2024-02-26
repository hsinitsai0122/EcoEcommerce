using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class Cart
    {

        private List<OrderItem> _orderItems;
    
        public int Id_Cart { get; private set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDate { get; private set; }

        public IEnumerable<OrderItem> OrderItems
        {
            get { return _orderItems; }
        }

        public Cart(int id_Cart, string orderNumber, DateTime orderDate)
        {
            Id_Cart = id_Cart;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            if (_orderItems.Contains(orderItem))
            {
                throw new InvalidOperationException("OrderItem already exists");
            }
            _orderItems.Add(orderItem);
            //orderItem.SetCart(this); // Associate the order item with this cart
        }

        public void AddGroupOrderItems(IEnumerable<OrderItem> orderItems)
        {
            if (orderItems == null)
            {
                throw new ArgumentNullException(nameof(orderItems));
            }
            foreach (var orderItem in orderItems)
            {
                AddOrderItem(orderItem);
            }
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            if (!_orderItems.Contains(orderItem))
            {
                throw new InvalidOperationException("OrderItem not found");
            }
            _orderItems.Remove(orderItem);
            orderItem.SetCart(null); // Disassociate the order item from any cart
        }
    }

    //public OrderItem? this[int index]
    //{
    //    get
    //    {
    //        return _orderItems.SingleOrDefault(d => d.Id_OrderItem == index);
    //    }
    //}

    //public OrderItem[] OrderItems
    //{
    //    get
    //    {
    //        return _orderItems?.ToArray(); /*?? new OrderItem[0];*/
    //    }
    //}


    //public Cart(int id_Cart, string orderNumber, DateTime orderDate)
    //{
    //    Id_Cart = id_Cart;
    //    OrderNumber = orderNumber;
    //    OrderDate = DateTime.Now;

    //}


    //public void AddOrderItem(OrderItem orderItem)
    //{
    //    if(orderItem is null) throw new ArgumentNullException(nameof(orderItem));
    //    if(_orderItems.Contains(orderItem)) throw new InvalidOperationException("OrderItem already exists");
    //    _orderItems??= new List<OrderItem>();
    //    _orderItems.Add(orderItem);
    //}

}

