using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Domain.Interfaces.Product;
using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        public Task<List<ProductGroup>> GetAllProductGroups()
        {
            throw new NotImplementedException();
        }

        public Task<ProductGroup> GetProductGroupById(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddProductGroup(ProductGroup productGroup)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductGroup(ProductGroup productGroup)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductGroup(ProductGroup productGroup)
        {
            throw new NotImplementedException();
        }
    }
}
