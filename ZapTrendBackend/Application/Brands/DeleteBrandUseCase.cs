using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Exceptions.Brand;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Brands
{
    public class DeleteBrandUseCase
    {
        private readonly IBrandRepository brandRepository;
        private readonly IAuthorizationService authorizationService;

        public DeleteBrandUseCase(IBrandRepository brandRepository, IAuthorizationService authorizationService)
        {
            this.brandRepository = brandRepository;
            this.authorizationService = authorizationService;
        }

        public async Task Execute(Guid id, CancellationToken cancellationToken)
        {
            await authorizationService.AuthorizeAsync(Permissions.Brand.Delete, cancellationToken);

            await brandRepository.DeleteByIdAsync(id);
        }
    }
}
