using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Domain.Exceptions.Brand;
using ZapTrendBackend.Domain.Exceptions.Product;
using ZapTrendBackend.Domain.Exceptions.ProductType;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Products
{
    public class CreateProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IAuthorizationService authorizationService;

        public CreateProductUseCase(IProductRepository productRepository, IBrandRepository brandRepository, IProductTypeRepository productTypeRepository, IAuthorizationService authorizationService)
        {
            this.productRepository = productRepository;
            this.brandRepository = brandRepository;
            this.productTypeRepository = productTypeRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Name name, Guid productTypeId, Guid brandId, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.Products.Create, cancellationToken);

            //Tarea Asincrona para optimizar
            Task<Brand?> brandTask = brandRepository.GetByIdAsync(brandId, cancellationToken);
            Task<ProductType?> productTypeTask = productTypeRepository.GetByIdAsync(productTypeId, cancellationToken);

            Brand? brand = await brandTask;
            ProductType? productType = await productTypeTask;

            if (brand is null)
                throw new BrandNotFoundException($"No se encontro la marca con el id {brandId}");

            if (productType is null)
                throw new ProductTypeNotFoundException($"No se encontro el tipo de producto con el id {productTypeId}");

            if (await productRepository.ExistByNameAndBrand(name, brand, cancellationToken))
                throw new ProductNameAndBrandAlreadyExist($"El Producto con el nombre {name} y el id de marca {brandId} ya existe");

            Product product = Product.Create(name, brand, productType);

            await productRepository.SaveAsync(product, cancellationToken);
        }
    }
}
