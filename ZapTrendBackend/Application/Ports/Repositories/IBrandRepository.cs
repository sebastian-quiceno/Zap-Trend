using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public  interface IBrandRepository
    {
        Task<Brand> SaveAsync(Brand brand, CancellationToken cancellationToken);

        Task<Brand?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken);

        Task UpdateAsync(Brand brand, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    }
}
