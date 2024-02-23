using BLL_EcoEcommerce.Mappers;
using BLL_EcoEcommerce.Entities;
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

        public OrderItemService(IOrderItemRepository<DAL.OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _orderItemRepository.GetAll().Select(d => d.ToBLL());
        }

        public OrderItem GetById(int id)
        {
            OrderItem entity = _orderItemRepository.GetById(id).ToBLL();
            if (!(entity.Id_OrderItem == 0))
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public int Insert(OrderItem entity)
        {
            return _orderItemRepository.Insert(entity.ToDAL());
        }

        public void Update(OrderItem entity)
        {
            _orderItemRepository.Update(entity.ToDAL());
        }
        public void Delete(int id)
        {
            _orderItemRepository.Delete(id);
        }


    }
}