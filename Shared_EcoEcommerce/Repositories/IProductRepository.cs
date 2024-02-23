using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_EcoEcommerce.Repositories
{
    public interface IProductRepository<TEntity> : ICRUDRepository <TEntity, int> 
    {
        public IEnumerable<TEntity> FilterByPopularity();
        
        public IEnumerable<TEntity> FilterByName(string name);

        public IEnumerable<TEntity> FilterByCateg(string proCateg);

        public IEnumerable<TEntity> FilterByEcoScore(string ecoCriteria);


    }
}
