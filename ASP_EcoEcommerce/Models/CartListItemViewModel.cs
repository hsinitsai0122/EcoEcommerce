using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ASP_EcoEcommerce.Models
{
    public class CartListItemViewModel
    {
        [ScaffoldColumn(false)]
        public int Id_Cart { get; set; }
        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderItemListItemViewModel> OrderItems { get; set; }
        
    }
}
