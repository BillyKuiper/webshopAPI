using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopAPI.Controllers;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class OrderTest
    {
        private IOrderService _service;

        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            _service = new TestDBOrder();
        }

        [Test]
        public void CreateOrder()
        {
            //Arrange
            var controller = new OrderController(_service);

            //Act

            //Assert
        }

    }
}
