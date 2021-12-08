using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebshopAPI.Data;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService _service)
        {
            this._service = _service;
        }

        [Route("/[controller]/order")]
        [HttpPost]
        [Authorize]
        public bool CreateOrder([FromHeader] string Authorization, [FromBody] object[] shoppingCart)
        {
            var handler = new JwtSecurityTokenHandler();
            string[] tokenSplit = Authorization.Split(" ");
            var jwtSecurityToken = handler.ReadJwtToken(tokenSplit[1]);
            List<ShoppingCart> producten = new List<ShoppingCart>();
            foreach (object obj in shoppingCart)
            {
                producten.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ShoppingCart>(Convert.ToString(obj)));
            }
            string userId = null;
            foreach (Claim c in jwtSecurityToken.Claims)
            {
                if (c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            Order order = _service.CreateOrder(userId);
            return _service.CreateOrderItems(order, producten);
        }
    }
}
