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
        Task<Product> SaveAsync(Product product, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> DeleteByIDAsync(int id, CancellationToken cancellationToken);
        Task<Product> ExistByNameAndBrand(string name, Brand brand, CancellationToken cancellationToken);
        
    }
}
