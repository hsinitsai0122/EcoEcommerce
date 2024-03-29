﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_EcoEcommerce.Models
{
    public class OrderItemListItemViewModel
    {
        [ScaffoldColumn(false)]
        public int Id_OrderItem { get; set; }

        //[DisplayName("Product Name")]
        //public string ProductName { get; set; }

        [DisplayName("Order Quantity")]
        public int Quantity { get; set; }

        [HiddenInput]
        public int Id_Product { get; set; }

        [HiddenInput]
        public int Id_Cart { get; set; }
    }
}
