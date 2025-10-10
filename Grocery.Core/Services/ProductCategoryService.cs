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
    public class ProductCategoryService : IProductCategoryService
    {

        public IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<ProductCategory> GetCategoryList(int CategoryId)
        {
            return _productCategoryRepository.GetAll().Where(pc => pc.CategoryId == CategoryId).ToList();
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }



    }
}
