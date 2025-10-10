using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {

        public ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepositor) 
        { 

            _CategoryRepository = CategoryRepositor;
        }

        public Category? Get(string categoryname)
        {
            return _CategoryRepository.Get(categoryname);
        }

        public Category? Get(int id)
        {
            return _CategoryRepository.Get(id);
        }


        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }
    }
}
