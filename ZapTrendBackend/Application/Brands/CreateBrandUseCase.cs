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

        public async Task Execute(CreateBrandRequestDTO dto, CancellationToken cancellationToken) {

            AuthorizationResponseDTO authorized = await authorizationService.AuthorizeAsync(Permissions.Brand.Create, cancellationToken);

            if (!authorized)
                throw new UnauthorizedAccessException("");

            if (await brandRepository.ExistsByNameAsync(dto.Name))
                throw new BrandNameAlreadyExistException("El nombre de la marca ya existe");
            
            Name name = new Name(dto.Name);
            Brand brand = Brand.Create(name);

            await brandRepository.SaveAsync(brand);
        }
    }
}
