using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_EcoEcommerce.Repositories
{
    public interface ICRUDRepository<TEntity, TId> 
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(TId id);
        public TId Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TId id);
    }
}
