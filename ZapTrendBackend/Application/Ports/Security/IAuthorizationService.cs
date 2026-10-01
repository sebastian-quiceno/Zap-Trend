using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Application.Authorization;
using ZapTrendBackend.Application.Ports.Security;

namespace ZapTrendBackend.Application.Ports.Security
{
    public interface IAuthorizationService
    {
        Task AuthorizeAsync(string permission, CancellationToken cancellationToken = default);
    }
}
