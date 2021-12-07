using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext dc;

        public ProductService(DataContext dc)
        {
            this.dc = dc;
        }

        public List<Product> GetAll()
        {
            List<Product> products = dc.Products.ToList();
            return products;
        }

        public List<Product> GetHome()
        {
            List<Product> producten = (from Product in dc.Products
                                  where Product.productId <= 4
                                  select Product).ToList();
            return producten;
        }

        public List<Product> GetHome(int id)
        {
            List<Product> producten = (from Product in dc.Products
                        where Product.productId == id
                        select Product).ToList();
            return producten;
        }
    }
}
