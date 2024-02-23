using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EcoEcommerce.Entities
{
    public class Media
    {
        
        public int Id_Media { get; set; }
        public string ImgUrl { get; set; }
        public int Id_Product { get; set; }
    }
}
