using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Models
{
    public class ProductListItemViewModel
    {

        [ScaffoldColumn(false)]
        public int Id_Product { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Category")]
        public BLL.Category ProCateg { get; set; }

        [DisplayName("EcoScore Level")]
        public BLL.EcoScore EcoCriteria { get; set; }

        [DisplayName("Unit Price")]
        public decimal Price { get; set; }

    }
}
