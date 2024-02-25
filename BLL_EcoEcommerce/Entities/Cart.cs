using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class Cart
    {


    
        public int Id_Cart { get; private set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDate { get; private set; }
        



        public Cart(int id_Cart, string orderNumber, DateTime orderDate)
        {
            Id_Cart = id_Cart;
            OrderNumber = orderNumber;
            OrderDate = DateTime.Now;
          
        }
       
    }
}
