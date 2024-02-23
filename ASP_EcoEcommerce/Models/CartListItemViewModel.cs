using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_EcoEcommerce.Models
{
    public class CartListItemViewModel
    {
        public int Id_Cart { get; set; }

        public DateTime OrderDate { get; set; }

        public int Id_Product { get; set; }


        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Unit Price")]
        public decimal Price { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Total Price")]
        public decimal ItemPrice { get; set; }


    }
}
