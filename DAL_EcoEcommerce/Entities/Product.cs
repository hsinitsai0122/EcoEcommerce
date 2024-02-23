using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Entities
{
    public class Product
    {
        public int Id_Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public String ProCateg { get; set;}

        public String EcoCriteria { get; set; }
    }
}
