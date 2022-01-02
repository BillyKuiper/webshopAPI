using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext dc;

        public OrderService(DataContext dc)
        {
            this.dc = dc;
        }

        public Order CreateOrder(string userId)
        {
            Order o = new Order();
            o.userId = Convert.ToInt32(userId);
            o.orderDate = DateTime.Now;
            dc.Orders.Add(o);
            dc.SaveChanges();
            return o;
        }

        public bool CreateOrderItems(Order o, List<ShoppingCart> cart)
        {
            foreach (ShoppingCart sc in cart)
            {
                OrderProduct op = new OrderProduct();
                op.amount = sc.amount;
                op.productId = sc.product.productId;
                op.OrderId = o.orderId;

                dc.OrderProducts.Add(op);
            }
            dc.SaveChanges();
            return true;
        }

        public bool deleteOrders(int orderId)
        {
            try
            {
                Order o = (from Order in dc.Orders
                           where Order.orderId == orderId
                           select Order).FirstOrDefault();
                dc.Orders.Remove(o);
                dc.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Order> getOrders(string userId)
        {
            List<Order> orders = (from Order in dc.Orders
                                 where Order.userId == Convert.ToInt32(userId)
                                 select Order).ToList();
     
            return orders;
            
        }
    }
    
}
