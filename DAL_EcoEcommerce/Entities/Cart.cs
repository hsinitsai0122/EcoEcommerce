﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Entities
{
    public class Cart
    {
        public int Id_Cart { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }
        public int Id_Product { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
