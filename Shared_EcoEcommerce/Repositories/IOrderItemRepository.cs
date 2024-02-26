using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_EcoEcommerce.Repositories
{
    public interface IOrderItemRepository<TEntity>:ICRUDRepository<TEntity, int>
    {


        public IEnumerable<TEntity> GetAllItemsByIdCart(int id_Cart);

        public void UpdateOrderItemQuantity(int id_OrderItem, int quantity);

     



    }
}
