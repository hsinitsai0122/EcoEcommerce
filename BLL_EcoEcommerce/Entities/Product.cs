using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class Product
    {

        public int Id_Product { get;  private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Category ProCateg { get; private set; }

        public EcoScore EcoCriteria { get; private set; }

        public Product(int id_Product, string name, string description, decimal price, Category proCateg, EcoScore ecoCriteria)
        {
            Id_Product = id_Product;
            Name = name;
            Description = description;
            Price = price;
            ProCateg = proCateg;
            EcoCriteria = ecoCriteria;
        }

    }
}
