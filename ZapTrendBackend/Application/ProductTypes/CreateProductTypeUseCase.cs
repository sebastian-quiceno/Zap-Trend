using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Adapters.Repositories;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;
using ZapTrendBackend.Domain.Exceptions.ProductType;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.ProductTypes
{
    public class CreateProductTypeUseCase
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IAuthorizationService authorizationService;

        public CreateProductTypeUseCase(IProductTypeRepository productTypeRepository, IAuthorizationService authorizationService)
        {
            this.productTypeRepository = productTypeRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Name name, Description description, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.ProductTypes.Create);

            if (await productTypeRepository.ExistByName(name, cancellationToken))
                throw new ProductTypeNameAlreadyExistException($"El nombre para el tipo de producto {name.ToString} ya existe");
            

            ProductType productType = ProductType.Create(name, description);

            await productTypeRepository.SaveAsync(productType, cancellationToken);
        }
    }
}
