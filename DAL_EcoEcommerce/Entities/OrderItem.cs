using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Entities
{
    public class OrderItem
    {
        public int Id_OrderItem { get; set; }

        public int Quantity { get; set; }
        public int Id_Product { get; set; }

        public int Id_Cart { get; set; }

    }
}
