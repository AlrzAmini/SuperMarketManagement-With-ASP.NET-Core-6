using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Domain.Interfaces.Product;

public interface IProductRepository
{
    #region product group

    Task<List<ProductGroup>> GetAllProductGroups();

    Task<ProductGroup?> GetProductGroupById(int groupId);

    Task<bool> AddProductGroup(ProductGroup productGroup);

    Task<bool> UpdateProductGroup(ProductGroup productGroup);

    Task<bool> DeleteProductGroup(ProductGroup productGroup);

    #endregion

    #region product

    Task<List<Models.Product.Product>> GetAllProduct();

    Task<Models.Product.Product?> GetProductById(int productId);

    Task<bool> AddProduct(Models.Product.Product product);

    Task<bool> UpdateProduct(Models.Product.Product product);

    Task<bool> DeleteProduct(Models.Product.Product product);

    #endregion

    #region product size

    Task<List<ProductSize>> GetAllProductSizes();

    Task<ProductSize?> GetProductSizeById(int productSizeId);

    Task<int> AddProductSize(ProductSize productSize);

    Task<bool> UpdateProductSize(ProductSize productSize);

    Task<bool> DeleteProductSize(ProductSize productSize);

    #endregion
}