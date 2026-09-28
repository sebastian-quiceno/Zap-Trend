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
        Task<Size> SaveAsync(User user);
        Task<Size> GetByIdAsync(int id);
        Task<List<Size>> GetAllASync();
        Task<bool> DeleteByIDAsync(int id); 

    }
}
