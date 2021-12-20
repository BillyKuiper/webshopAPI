using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopAPI.Controllers;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class OrderTest
    {
        private IOrderService _service;
        public object[] productToOrder;

        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            _service = new TestDBOrder();

            //MockData Product
            Product p = new Product();
            p.productId = 1;
            p.productName = "Coal";
            p.productPrice = Convert.ToDecimal(23.99);
            p.productDescription = "-";
            p.productImage = null;
            p.productAddingDate = DateTime.Now;
            ShoppingCart sc1 = new ShoppingCart();
            sc1.product = p;
            sc1.amount = 2;

            Product p2 = new Product();
            p2.productId = 1;
            p2.productName = "Stone";
            p2.productPrice = Convert.ToDecimal(80.99);
            p2.productDescription = "-";
            p2.productImage = null;
            p2.productAddingDate = DateTime.Now;
            ShoppingCart sc2 = new ShoppingCart();
            sc1.product = p2;
            sc1.amount = 3;

            Product p3 = new Product();
            p3.productId = 1;
            p3.productName = "Grass";
            p3.productPrice = Convert.ToDecimal(48.99);
            p3.productDescription = "-";
            p3.productImage = null;
            p3.productAddingDate = DateTime.Now;
            ShoppingCart sc3 = new ShoppingCart();
            sc3.product = p3;
            sc3.amount = 4;

            //MockData OrderItems
            object[] test = { JsonConvert.SerializeObject(sc1), JsonConvert.SerializeObject(sc2), JsonConvert.SerializeObject(sc3) };
            productToOrder = test;
            
        }

        [Test]
        public void CreateOrder()
        {
            //Arrange
            var controller = new OrderController(_service);
            string Auth = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";

            //Act
            var result = controller.CreateOrder(Auth, productToOrder);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateOrderNoToken()
        {
            //Arrange
            var controller = new OrderController(_service);
            string Auth = null;

            //Act
            var result = controller.CreateOrder(Auth, productToOrder);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateOrderNoCart()
        {
            //Arrange
            var controller = new OrderController(_service);
            string Auth = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";

            //Act
            var result = controller.CreateOrder(Auth, null);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateOrderNoCartNoToken()
        {
            //Arrange
            var controller = new OrderController(_service);
            string Auth = null;

            //Act
            var result = controller.CreateOrder(Auth, null);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
