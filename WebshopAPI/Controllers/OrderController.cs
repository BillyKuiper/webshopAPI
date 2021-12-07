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

namespace WebshopAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly DataContext db;

        public OrderController(DataContext db)
        {
            this.db = db;
        }

        [Route("/[controller]/order")]
        [HttpPost]
        [Authorize]
        public void CreateOrder([FromHeader] string Authorization, [FromBody] object[] shoppingCart)
        {
            //Product Bepalen
            List<ShoppingCart> x = new List<ShoppingCart>();
            foreach (object obj in shoppingCart)
            {
                x.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ShoppingCart>(Convert.ToString(obj)));
            }
            var handler = new JwtSecurityTokenHandler();
            string[] tokenSplit = Authorization.Split(" ");
            var jwtSecurityToken = handler.ReadJwtToken(tokenSplit[1]);
            string userId = null;
            foreach(Claim c in jwtSecurityToken.Claims)
            {
                if(c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            if(userId == null)
            {
                //error , gebruiker probeert order te plaatsen zonder userId
            }
            else
            {
                //Nieuwe Order maken
                Order o = new Order();
                o.userId = Convert.ToInt32(userId);
                o.orderDate = DateTime.Now;
                DateTime orderDate = o.orderDate;
                db.Orders.Add(o);
                db.SaveChanges();
                //Nieuwe OrderItems Aanmaken
                foreach (ShoppingCart sc in x)
                {
                    Order order = db.Orders.Where(o => (o.userId == Convert.ToInt32(userId)) && (o.orderDate == orderDate)).FirstOrDefault();
                    OrderProduct op = new OrderProduct();
                    op.amount = sc.amount;
                    op.productId = sc.product.productId;
                    op.OrderId = order.orderId;
                    db.OrderProducts.Add(op);
                }
                db.SaveChanges();
            }
            
            /*
            //Order Item bepalen
            //Lijst maken van orderitems
            foreach(object item in shoppingCart)
            {

            }
            var y = 2;*/
        }
    }
}
