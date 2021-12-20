using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using WebshopAPI.Controllers;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class Tests
    {
        private IProductService _service;
        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            _service = new TestDB();
        }

        [Test]
        public void GetAllProducts()
        {
            //Arrange
            var controller = new ProductController(_service);

            //Act
            var resultString = controller.GetAll();

            //Assert
            Assert.IsNotNull(resultString);
        }

        [Test]
        public void GetProductsForHomepage()
        {
            //Arrange
            var controller = new ProductController(_service);

            //Act
            var resultString = controller.GetHome();

            //Assert
            Assert.IsNotNull(resultString);
            
        }

        [Test]
        public void getSingleProduct()
        {
            //Arrange
            var controller = new ProductController(_service);

            //Act
            var resultString = controller.GetHome(1);
            var model = JsonConvert.DeserializeObject(resultString);
            //Assert
            Assert.IsNotNull(model);
        }

        [Test]
        public void getSingleProductNoId()
        {
            //Arrange
            var controller = new ProductController(_service);
            int x = 0;

            //Act
            var resultString = controller.GetHome(x);
            var model = JsonConvert.DeserializeObject(resultString);

            //Assert
            Assert.IsNull(model);
        }
    }
}