using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IProductRepository 
    {
        Task<Product> SaveAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllASync();
        Task<bool> DeleteByIDAsync(int id);
        Task<Product> ExistByNameAndBrand(string name, Brand brand);
        
    }
}
