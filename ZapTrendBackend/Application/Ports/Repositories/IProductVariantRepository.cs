using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant> SaveAsync(ProductVariant productVariant, CancellationToken cancellationToken);
        Task<ProductVariant> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<ProductVariant>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> DeleteByIDAsync(int id, CancellationToken cancellationToken);


    }
}
