using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Application.DTOs.Product;
using SuperMarketManagement.Application.Interfaces.Product;
using SuperMarketManagement.Domain.Interfaces.Product;
using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<CreateProductResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto.GroupId == default)
            {
                return CreateProductResult.GroupError;
            }


            var product = new Domain.Models.Product.Product
            {
                Title = createProductDto.Title,
                Price = createProductDto.Price,
                GroupId = createProductDto.GroupId,
                Weight = createProductDto.Weight,
                Description = createProductDto.Description,
                Size = new ProductSize
                {
                    Height = createProductDto.Height,
                    Length = createProductDto.Length,
                    Width = createProductDto.Width
                }
            };

            if (await _productRepository.AddProduct(product))
            {
                return CreateProductResult.Success;
            }

            return CreateProductResult.Error;
        }
    }
}
