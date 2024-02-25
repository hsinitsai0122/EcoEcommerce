using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP_EcoEcommerce.Models
{
    public class CartDetailsViewModel
    {
        [ScaffoldColumn(false)]
        public int Id_Cart { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        // Nested view model for order items
        public IEnumerable<OrderItemListItemViewModel> OrderItems { get; set; }
    }
}
