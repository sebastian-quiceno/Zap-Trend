using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IUserRepository
    {

        Task<User> SaveAsync(User user, CancellationToken cancellationToken);
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User> GetByUserNameAsync(string username, CancellationToken cancellationToken);
        Task<List<User>> GetAllASync(CancellationToken cancellationToken);
        Task<bool> deleteByID(int id, CancellationToken cancellationToken);
        Task<bool> ExistByUsername(string username, CancellationToken cancellationToken);
        Task<bool> ExistByEmail(string mail, CancellationToken cancellationToken);
        Task<bool> ExistByDocument(string document, DocumentType documentType, CancellationToken cancellationToken);

    }
}
