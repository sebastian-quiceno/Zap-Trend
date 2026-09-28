using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Adapters.Repositories
{
    public interface IUserRepository
    {

        Task<User> SaveAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string username);
        Task<List<User>> GetAllASync();
        Task<bool> deleteByID(int id);
        Task<bool> ExistByUsername(string username);
        Task<bool> ExistByEmail(string mail);
        Task<bool> ExistByDocument(string document, DocumentType documentType);

    }
}
