using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Models;

namespace WebshopAPI.Services
{
    public interface IOrderService
    {
        public Order CreateOrder(string Authorization, List<ShoppingCart> shoppingCart);
        public bool CreateOrderItems(Order o, List<ShoppingCart> cart);
    }
}
