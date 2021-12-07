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
using WebshopAPI.Services;
using WebshopAPI.Models;

namespace WebshopAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService _service)
        {
            this._service = _service;
            //clears database and insert basic data
            //StartUpScript start = new StartUpScript(dc);
        }

        [HttpGet]
        public string GetAll()
        {
            var products = _service.GetAll();
            //var products = dc.Products.ToList();

            var returnableProducts = JsonConvert.SerializeObject(products);
            return returnableProducts;
        }

        [Route("/[controller]/home")]
        [HttpGet]
        public string GetHome()
        {
            List<Product> producten = _service.GetHome();
            return JsonConvert.SerializeObject(producten);
        }

        [Route("/[controller]/{id}")]
        [HttpGet]
        public string GetHome(int id)
        {
            List<Product> producten = _service.GetHome(id);

            return JsonConvert.SerializeObject(producten);
        }
    }
}
