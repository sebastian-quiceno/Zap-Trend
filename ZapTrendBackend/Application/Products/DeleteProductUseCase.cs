using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;

namespace ZapTrendBackend.Application.Products
{
    public class DeleteProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IAuthorizationService authorizationService;

        public DeleteProductUseCase(IProductRepository productRepository, IAuthorizationService authorizationService)
        {
            this.productRepository = productRepository;
            this.authorizationService = authorizationService;
        }

        public async Task Execute(Guid id, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.Products.Delete, cancellationToken);

            await productRepository.DeleteByIdAsync(id, cancellationToken);
        }
    }
}
