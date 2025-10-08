using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categoryList;
        public CategoryRepository()
        {
            categoryList = new List<Category>
            {
                new Category(1, "Fruits & Vegetables"),
                new Category(2, "Dairy & Eggs"),
                new Category(3, "Meat & Seafood"),
                new Category(4, "Baked goods"),
                new Category(5, "Snacks & Sweets"),
                new Category(6, "Frozen Foods"),
                new Category(7, "Personal Care")
            };
        }
        public Category? Get(int id)
        {
            Category? category = categoryList.FirstOrDefault(c => c.Id == id);
            return category;
        }
        public List<Category> GetAll()
        {
            return categoryList;
        }
    }
}
