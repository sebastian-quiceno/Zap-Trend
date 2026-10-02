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
    public class UpdateProductTypeUseCase
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly  IAuthorizationService authorizationService;

        public UpdateProductTypeUseCase(IProductTypeRepository productTypeRepository, IAuthorizationService authorizationService)
        {
            this.productTypeRepository = productTypeRepository;
            this.authorizationService = authorizationService;
        }

        public async Task ExecuteAsync(Guid id, Name? name, Description? description, CancellationToken cancellationToken) {
            await authorizationService.AuthorizeAsync(Permissions.ProductTypes.Update, cancellationToken);

            ProductType productType= await productTypeRepository.GetByIdAsync(id, cancellationToken);

            if (productType is null)
                throw new ProductTypeNotFoundException($"No se encontro el tipo de producto con el id {id}");

            if (name is not null)
                productType.ChangeName(name);

            if (description is not null)
                productType.ChangeDescription(description);

            await productTypeRepository.SaveAsync(productType, cancellationToken);

        }
    }
}
