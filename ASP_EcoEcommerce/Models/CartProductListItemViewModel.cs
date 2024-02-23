using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Models
{
    public class CartProductListItemViewModel
    {
        [HiddenInput]
        public int Id_Product { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Unit Price")]
        public decimal Price { get; set; }
    }
}
