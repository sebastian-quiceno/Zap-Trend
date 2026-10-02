using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Domain.Exceptions.ProductType;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Products
{
    public class UpdateProductUseCase
    {
        private IProductRepository productRepository;
        private IAuthorizationService authorizationService;

        public UpdateProductUseCase(IProductRepository productRepository, IAuthorizationService authorizationService)
        {
            this.productRepository = productRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Guid id, Name name, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.Products.Update, cancellationToken);

            Task<Product?> productTask =  productRepository.GetByIdAsync(id, cancellationToken);

            Product? product = await productTask;

            if (product is null)
                throw new ProductTypeNotFoundException($"No se encontro el producto con el ID: {id}");

            product.ChangeName(name);

            await productRepository.SaveAsync(product, cancellationToken);
        } 
    }
}
