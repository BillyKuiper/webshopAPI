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
using Microsoft.EntityFrameworkCore;

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
            StartUpScript start = new StartUpScript(dc);
        }
        
        [HttpGet]
        public string GetAll()
        {
            var products = dc.Products.ToList();

            var returnableProducts = JsonConvert.SerializeObject(products);
            return returnableProducts;
        }

        [Route("/[controller]/home")]
        [HttpGet]
        public string GetHome()
        {
            var query = from Product in dc.Products
                        where Product.productId <= 4
                        select Product;
            return JsonConvert.SerializeObject(query);
        }

        [Route("/[controller]/{id}")]
        [HttpGet]
        public string GetHome(int id)
        {
            var query = from Product in dc.Products
                        where Product.productId == id
                        select Product;
            return JsonConvert.SerializeObject(query);
        }
    }
}
