using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Services
{
    public class BaseService
    {
        protected readonly string _connectionString;

        public BaseService(IConfiguration configuration, string dbname)
        {
            _connectionString = configuration.GetConnectionString(dbname) ?? throw new ArgumentNullException(nameof(dbname));
        }
    }
}
