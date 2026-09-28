using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public  interface IBrandRepository
    {
        Task<Brand> SaveAsync(Brand brand);

        Task<Brand?> GetByIdAsync(Guid id);

        Task<IEnumerable<Brand>> GetAllAsync();

        Task<bool> DeleteAsync(Guid id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
