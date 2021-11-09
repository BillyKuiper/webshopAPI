using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OrderController
    {
        [Route("/[controller]/order")]
        [HttpPost]
        [Authorize]
        public void CreateOrder([FromBody] List<object> shoppingCart)
        {
            var x = 0;
            var y = 2;
        }
    }
}
