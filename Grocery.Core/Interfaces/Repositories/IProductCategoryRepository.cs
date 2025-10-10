using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {

        public ProductCategory? Get(int id);
        public List<ProductCategory> GetAll();

        public ProductCategory Add(ProductCategory item);

    }
}
