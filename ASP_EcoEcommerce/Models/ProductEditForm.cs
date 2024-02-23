using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BLL = BLL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP_EcoEcommerce.Models
{
    public class ProductEditForm
    {
        
        [Required(ErrorMessage ="Id Product is required!")]
        public int Id_Product { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required!")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Product Description is required!")]
        public string Description { get; set; }

        [DisplayName("Product Category")]
        [Required(ErrorMessage = "Product Category is required!")]
        public BLL.Category ProCateg { get; set; }

        [DisplayName("EcoScore Level")]
        [Required(ErrorMessage = "EcoScore of Product is required!")]
        public BLL.EcoScore EcoCriteria { get; set; }

        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "Product Price is required!")]
        public decimal Price { get; set; }
    }
}
