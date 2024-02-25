using BLL_EcoEcommerce.Entities;
using BLL_EcoEcommerce.Mappers;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DAL_EcoEcommerce.Entities;

namespace BLL_EcoEcommerce.Services
{
    public class OrderItemService : IOrderItemRepository<OrderItem>
    {
        private readonly IOrderItemRepository<DAL.OrderItem> _orderItemRepository;
        private readonly ICartRepository<DAL.Cart> _cartRepository;

        public OrderItemService(IOrderItemRepository<DAL.OrderItem> orderItemRepository, ICartRepository<DAL.Cart> cartRepository)
        {
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _orderItemRepository.GetAll().Select(d => d.ToBLL());
        }

        public OrderItem GetById(int id)
        {
            OrderItem entity = _orderItemRepository.GetById(id).ToBLL();
            if(!(entity is null))
            {
                return entity;
            }
            else
            {
                throw new Exception("OrderItem not found");
            }
        }
        public IEnumerable<OrderItem> GetAllItemsByIdCart(int id)
        {
            return _orderItemRepository.GetAllItemsByIdCart(id).Select(d => d.ToBLL());
        }
        public void UpdateOrderItemQuantity(int Id_orderItem, int quantity)
        {
            _orderItemRepository.UpdateOrderItemQuantity(Id_orderItem, quantity);
        }


        public int Insert(OrderItem entity)
        {
            return _orderItemRepository.Insert(entity.ToDAL());
        }

        public void Update(OrderItem entity)
        {
            _orderItemRepository.Update(entity.ToDAL());
        }

        public void Delete(int id_OrderItem)
        {
            _orderItemRepository.Delete(id_OrderItem);
        }


    }
}
