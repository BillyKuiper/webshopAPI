using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Models;

namespace WebshopAPI.Services
{
    public interface IOrderService
    {
        public Order CreateOrder(string userId);
        public bool CreateOrderItems(Order o, List<ShoppingCart> cart);
    }
}
