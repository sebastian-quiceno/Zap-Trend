using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Domain.Exceptions.Brand;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Brands
{
    public class UpdateBrandUseCase
    {
        private IBrandRepository brandRepository;
        private IAuthorizationService authorizationService;

        public UpdateBrandUseCase(IBrandRepository brandRepository, IAuthorizationService authorizationService) {
            this.brandRepository = brandRepository;
            this.authorizationService = authorizationService;
        }

        public async Task Excecute(Guid id, Name newName, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.Brand.Update, cancellationToken);

            Brand? brand = await brandRepository.GetByIdAsync(id);

            if (brand is null)
                throw new BrandNotFoundException("La marca no existe.");

            brand.ChangeName(newName);

            await brandRepository.UpdateAsync(brand);
        }
    }
}
