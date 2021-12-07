using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Models;

namespace WebshopAPI.Services
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public List<Product> GetHome();
        public List<Product> GetHome(int id);
    }
}
