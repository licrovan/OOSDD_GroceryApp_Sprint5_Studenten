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

            productCategories = new List<ProductCategory>
            {
                new ProductCategory(1, "", 1, 2), // melk in dairy
                new ProductCategory(2, "", 2, 2), // kaas in dairy
                new ProductCategory(3, "", 3, 4), // brood in baked goods
                new ProductCategory(4, "", 4, 5)  // cornflakes in snacks
            };
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

        public ProductCategory Add(ProductCategory item)
        {
            int newId = productCategories.Max(c => c.Id) + 1;
            ProductCategory newProductCategory = new(newId, item.Name, item.ProductId, item.CategoryId);
            productCategories.Add(newProductCategory);
            return newProductCategory;
        }
    }
}
