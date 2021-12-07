using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class TestDBOrder : IOrderService
    {
        List<Order> allOrders = new List<Order>();
        List<ShoppingCart> allorderedProducts = new List<ShoppingCart>();


        public Order CreateOrder(string userId)
        {
            Order o = new Order();
            o.userId = Convert.ToInt32(userId);
            o.orderDate = DateTime.Today;
            o.orderId = 1;
            return o;
        }

        public bool CreateOrderItems(Order o, List<ShoppingCart> cart)
        {
            allOrders.Add(o);
            foreach(ShoppingCart item in cart)
            {
                allorderedProducts.Add(item);
            }
            return true;
        }
    }
}
