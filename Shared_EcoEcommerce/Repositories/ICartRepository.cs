using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_EcoEcommerce.Repositories
{
    public interface ICartRepository<TEntity> : ICRUDRepository<TEntity, int>
    {

    }
}
