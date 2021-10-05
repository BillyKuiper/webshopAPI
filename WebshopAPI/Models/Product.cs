using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Models
{
    
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal productPrice { get; set; }
        public string productImage { get; set; }
        public DateTime productAddingDate { get; set; }
        public string description { get; set; }
    }
}
