using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ProductType> SaveAsync(ProductType productType, CancellationToken cancellationToken);
        Task<ProductType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<ProductType>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> deleteByID(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistByName(Name name, CancellationToken cancellationToken);
        
    }
}
