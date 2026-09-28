using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ProductType> SaveAsync(ProductType productType);
        Task<ProductType> GetByIdAsync(int id);
        Task<List<ProductType>> GetAllASync();
        Task<bool> deleteByID(int id);
        Task<bool> ExistByName(string name);
        
    }
}
