using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Data.Context;
using SuperMarketManagement.Domain.Interfaces.Product;
using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly SuperMarketDbContext _context;

        public ProductRepository(SuperMarketDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<ProductGroup>> GetAllProductGroups()
        {
            return await _context.ProductGroups.ToListAsync();
        }

        public async Task<ProductGroup?> GetProductGroupById(int groupId)
        {
            return await _context.ProductGroups.FindAsync(groupId);
        }

        public async Task<bool> AddProductGroup(ProductGroup productGroup)
        {
            try
            {
                await _context.ProductGroups.AddAsync(productGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductGroup(ProductGroup productGroup)
        {
            try
            {
                _context.ProductGroups.Update(productGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductGroup(ProductGroup productGroup)
        {
            productGroup.IsDeleted = true;
            return await UpdateProductGroup(productGroup);
        }

        public async Task<List<Domain.Models.Product.Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Domain.Models.Product.Product?> GetProductById(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<bool> AddProduct(Domain.Models.Product.Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(Domain.Models.Product.Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Domain.Models.Product.Product product)
        {
            product.IsDeleted = true;
            return await UpdateProduct(product);
        }

        public async Task<List<ProductSize>> GetAllProductSizes()
        {
            return await _context.ProductSizes.ToListAsync();
        }

        public async Task<ProductSize?> GetProductSizeById(int productSizeId)
        {
            return await _context.ProductSizes.FindAsync(productSizeId);
        }

        public async Task<int> AddProductSize(ProductSize productSize)
        {
            try
            {
                await _context.ProductSizes.AddAsync(productSize);
                await _context.SaveChangesAsync();
                return productSize.Id;
            }
            catch
            {
                return default;
            }
        }

        public async Task<bool> UpdateProductSize(ProductSize productSize)
        {
            try
            {
                _context.ProductSizes.Update(productSize);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductSize(ProductSize productSize)
        {
            productSize.IsDeleted = true;
            return await UpdateProductSize(productSize);
        }
    }
}
