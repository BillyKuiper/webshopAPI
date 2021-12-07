using System;
using System.Collections.Generic;
using System.Text;
using WebshopAPI.Models;
using WebshopAPI.Services;

namespace WebShopAPI.test
{
    public class TestDB : IProductService
    {
        List<Product> alleProducten = new List<Product>();
        public TestDB()
        {
            Product p = new Product();
            p.productId = 1;
            p.productName = "Coal";
            p.productPrice = Convert.ToDecimal(23.99);
            p.productDescription = "-";
            p.productImage = null;
            p.productAddingDate = DateTime.Now;

            Product p2 = new Product();
            p2.productId = 1;
            p2.productName = "Stone";
            p2.productPrice = Convert.ToDecimal(80.99);
            p2.productDescription = "-";
            p2.productImage = null;
            p2.productAddingDate = DateTime.Now;

            Product p3 = new Product();
            p3.productId = 1;
            p3.productName = "Grass";
            p3.productPrice = Convert.ToDecimal(48.99);
            p3.productDescription = "-";
            p3.productImage = null;
            p3.productAddingDate = DateTime.Now;

            Product p4 = new Product();
            p4.productId = 1;
            p4.productName = "Grass";
            p4.productPrice = Convert.ToDecimal(48.99);
            p4.productDescription = "-";
            p4.productImage = null;
            p4.productAddingDate = DateTime.Now;

            Product p5 = new Product();
            p5.productId = 1;
            p5.productName = "Grass";
            p5.productPrice = Convert.ToDecimal(48.99);
            p5.productDescription = "-";
            p5.productImage = null;
            p5.productAddingDate = DateTime.Now;

            Product p6 = new Product();
            p6.productId = 1;
            p6.productName = "Grass";
            p6.productPrice = Convert.ToDecimal(48.99);
            p6.productDescription = "-";
            p6.productImage = null;
            p6.productAddingDate = DateTime.Now;

            alleProducten.Add(p);
            alleProducten.Add(p2);
            alleProducten.Add(p3);
            alleProducten.Add(p4);
            alleProducten.Add(p5);
            alleProducten.Add(p6);
        }

        public List<Product> GetAll()
        {
            return alleProducten;
        }

        public List<Product> GetHome()
        {
            List<Product> first4 = new List<Product>();

            first4 = alleProducten.GetRange(1, 4);
            return first4;
        }

        public List<Product> GetHome(int id)
        {
            foreach(Product p in alleProducten)
            {
                if(p.productId == id)
                {
                    List<Product> products = new List<Product>();
                    products.Add(p);
                    return products;
                }
            }
            return null;
        }
    }
}
