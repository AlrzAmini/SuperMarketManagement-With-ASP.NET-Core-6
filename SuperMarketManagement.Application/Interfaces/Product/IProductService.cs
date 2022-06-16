using SuperMarketManagement.Application.DTOs.Product;

namespace SuperMarketManagement.Application.Interfaces.Product;

public interface IProductService
{
    Task<CreateProductResult> CreateProduct(CreateProductDto createProductDto);
}