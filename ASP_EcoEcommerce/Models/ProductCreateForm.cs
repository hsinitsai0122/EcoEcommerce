using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Models
{
    public class ProductCreateForm
    {

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

        [DisplayName("Product Images")]
        [Required(ErrorMessage ="Product Images are required!")]
        public List<IFormFile> Medias { get; set; }


    }
}
