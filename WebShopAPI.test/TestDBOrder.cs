using System;
using System.Collections.Generic;
using System.Text;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class TestDBOrder : IOrderService
    {

        public Order CreateOrder(string Authorization, List<ShoppingCart> shoppingCart)
        {
            throw new NotImplementedException();
        }

        public bool CreateOrderItems(Order o, List<ShoppingCart> cart)
        {
            throw new NotImplementedException();
        }
    }
}
