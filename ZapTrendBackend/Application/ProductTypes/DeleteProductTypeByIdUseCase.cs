using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;

namespace ZapTrendBackend.Application.ProductTypes
{
    public class DeleteProductTypeByIdUseCase
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IAuthorizationService authorizationService;

        public DeleteProductTypeByIdUseCase(IProductTypeRepository productTypeRepository, IAuthorizationService authorizationService)
        {
            this.productTypeRepository = productTypeRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.ProductTypes.Delete, cancellationToken);

            await productTypeRepository.deleteByID(id, cancellationToken);
        }
    }
}
