using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Domain.Exceptions.Authorization;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Exceptions.Brand;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Brands
{
    public class CreateBrandUseCase
    {
        private readonly IBrandRepository brandRepository;
        private readonly IAuthorizationService authorizationService;

        public CreateBrandUseCase(IBrandRepository brandRepository, IAuthorizationService authorizationService)
        {
            this.brandRepository = brandRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Name name, CancellationToken cancellationToken) {

            await authorizationService.AuthorizeAsync(Permissions.Brand.Create, cancellationToken);

            if (await brandRepository.ExistsByNameAsync(name.ToString(), cancellationToken))
                throw new BrandNameAlreadyExistException("El nombre de la marca ya existe");
            
            Brand brand = Brand.Create(name);

            await brandRepository.SaveAsync(brand, cancellationToken);
        }
    }
}
