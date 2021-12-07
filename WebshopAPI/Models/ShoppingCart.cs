using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Models
{
    public class ShoppingCart
    {
        public Product product { get; set; }
        public int amount { get; set; }
    }
}
