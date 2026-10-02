using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface ISizeRepository
    {
        Task<Size> SaveAsync(User user, CancellationToken cancellationToken);
        Task<Size> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Size>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> DeleteByIDAsync(int id, CancellationToken cancellationToken); 

    }
}
