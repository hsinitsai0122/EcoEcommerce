using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_EcoEcommerce.Models
{
    public class OrderItemDeleteForm
    {
        [HiddenInput]
        public int Id_OrderItem { get; set; }

        [DisplayName("Order Quantity")]
        public int Quantity { get; set; }

        [HiddenInput]
        public int Id_Product { get; set; }

        [HiddenInput]
        public int Id_Cart { get; set; }
    }
}
