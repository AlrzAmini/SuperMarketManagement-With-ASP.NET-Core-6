using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Domain.Interfaces.Product;

public interface IProductRepository
{
    #region product group

    Task<List<ProductGroup>> GetAllProductGroups();

    Task<ProductGroup> GetProductGroupById(int groupId);

    Task<bool> AddProductGroup(ProductGroup productGroup);

    Task<bool> UpdateProductGroup(ProductGroup productGroup);

    Task<bool> DeleteProductGroup(ProductGroup productGroup);

    #endregion

    #region product



    #endregion

    #region product size



    #endregion
}