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
            try
            {
                var handler = new JwtSecurityTokenHandler();
                string[] tokenSplit = Authorization.Split(" ");
                var jwtSecurityToken = handler.ReadJwtToken(tokenSplit[1]);
                List<ShoppingCart> producten = new List<ShoppingCart>();
                if(shoppingCart.Count() == 0)
                {
                    return false;
                }
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
            catch
            {
                return false;
            }
            
        }

        [Route("/[controller]/allOrders")]
        [HttpGet]
        [Authorize]
        public List<Order> getOrdersByToken([FromHeader] string Authorization)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                string[] tokenSplit = Authorization.Split(" ");
                var jwtSecurityToken = handler.ReadJwtToken(tokenSplit[1]);
                string userId = "";
                foreach (Claim c in jwtSecurityToken.Claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = c.Value;
                    }
                }
                //order ophalen met nummer
                //
                return _service.getOrders(userId);
            }
            catch
            {
                return null;
            }
        }

        [Route("/[controller]/removeOrder")]
        [HttpDelete]
        [Authorize]
        public void deleteOrder(object orderNO)
        {
            Order o = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(Convert.ToString(orderNO));
            _service.deleteOrders(o.orderId);
        }
    }
}
