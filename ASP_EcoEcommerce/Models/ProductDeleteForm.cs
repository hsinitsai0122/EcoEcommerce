using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Models
{
    public class ProductDeleteForm
    {

        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Id Product is required!")]
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
