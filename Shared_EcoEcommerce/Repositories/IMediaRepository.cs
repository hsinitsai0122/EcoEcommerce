using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_EcoEcommerce.Repositories
{
    public interface IMediaRepository<TEntity> : ICRUDRepository<TEntity, int> 
    {
        public IEnumerable<TEntity> GetMediaForProduct(int id_Product);
        public TEntity GetSingleImageForProduct(int id_Product);

        public void DeleteByProductId(int id_Product);
    }
}
