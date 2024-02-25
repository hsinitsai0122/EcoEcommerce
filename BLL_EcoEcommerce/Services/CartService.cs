using BLL_EcoEcommerce.Entities;
using BLL_EcoEcommerce.Mappers;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DAL_EcoEcommerce.Entities;
using BLL = BLL_EcoEcommerce.Entities;

namespace BLL_EcoEcommerce.Services
{
    public class CartService : ICartRepository<Cart>
    {
        private readonly ICartRepository<DAL.Cart> _cartRepository;
   

        public CartService(ICartRepository<DAL.Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartRepository.GetAll().Select(d => d.ToBLL() );
        }

        public Cart GetById(int id)
        {
            return _cartRepository.GetById(id).ToBLL();
        }

        public int Insert(Cart entity)
        {
            return _cartRepository.Insert(entity.ToDAL());
        }

        public void Update(Cart entity)
        {
            _cartRepository.Update(entity.ToDAL());
        }
        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }

       
    }
}
