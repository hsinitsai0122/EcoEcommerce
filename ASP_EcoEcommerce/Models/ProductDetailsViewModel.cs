using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BLL = BLL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ASP_EcoEcommerce.Models
{
    public class ProductDetailsViewModel
    {
        [HiddenInput]
        public int Id_Product { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Category")]
        public BLL.Category ProCateg { get; set; }

        [DisplayName("EcoScore Level")]
        public BLL.EcoScore EcoCriteria { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }

        [DisplayName("Unit Price")]
        public decimal Price { get; set; }
    }
}
