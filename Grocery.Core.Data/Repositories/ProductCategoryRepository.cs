using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories; 
        public ProductCategoryRepository() {
       
            productCategories = new List<ProductCategory>();
        }

        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public ProductCategory? Get(int id)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(c => c.Id == id);
            return productCategory;
        }
    }
}
