using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using Microsoft.Extensions.Configuration;
using WebshopAPI.Data;
using Newtonsoft.Json;

namespace WebshopAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext dc;
        public ProductController(DataContext dc)
        {
            this.dc = dc;
        }
        
        [HttpGet]
        public string Get()
        {
            var products = dc.Products.ToList();

            var returnableProducts = JsonConvert.SerializeObject(products);
            return returnableProducts;
        }
    }
}
