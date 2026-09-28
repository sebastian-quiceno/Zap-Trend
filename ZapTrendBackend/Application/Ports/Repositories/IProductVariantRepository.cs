using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant> SaveAsync(ProductVariant productVariant);
        Task<ProductVariant> GetByIdAsync(int id);
        Task<List<ProductVariant>> GetAllASync();
        Task<bool> DeleteByIDAsync(int id);


    }
}
