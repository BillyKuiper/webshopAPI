using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebshopAPI.Models;

namespace WebshopAPI
{
    public class StartUpScript
    {
        private readonly DataContext dc;
        public StartUpScript(DataContext dc)
        {
            this.dc = dc;
            save();
        }
        public void save()
        {
            dc.Database.ExecuteSqlRaw("TRUNCATE TABLE [Products]");
            Product p = new Product();
            p.productName = "Coal";
            p.productPrice = Convert.ToDecimal(99.99);
            p.productAddingDate = DateTime.Today;
            p.productImage = "coal.png";
            p.productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            Product p2 = new Product();
            p2.productName = "Emerald";
            p2.productPrice = Convert.ToDecimal(99.99);
            p2.productAddingDate = DateTime.Today;
            p2.productImage = "emerald.png";
            p2.productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            Product p3 = new Product();
            p3.productName = "Gold";
            p3.productPrice = Convert.ToDecimal(99.99);
            p3.productAddingDate = DateTime.Today;
            p3.productImage = "gold.png";
            p3.productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            Product p4 = new Product();
            p4.productName = "Water";
            p4.productPrice = Convert.ToDecimal(99.99);
            p4.productAddingDate = DateTime.Today;
            p4.productImage = "water.png";
            p4.productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            dc.Products.Add(p);
            dc.Products.Add(p2);
            dc.Products.Add(p3);
            dc.Products.Add(p4);
            dc.SaveChanges();
        }
    }
}
