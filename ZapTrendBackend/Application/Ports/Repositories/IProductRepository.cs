using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductRepository 
    {
        Task<Product> SaveAsync(Product product, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistByNameAndBrand(Name name, Brand brand, CancellationToken cancellationToken);
        
    }
}
