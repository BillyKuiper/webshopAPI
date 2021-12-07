using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Models
{
    public class OrderProduct
    {
        public int orderProductId { get; set; }
        public int OrderId { get; set; }
        public int productId { get; set; }
        public int amount { get; set; }
    }
}
