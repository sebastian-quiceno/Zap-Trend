using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Application.Ports.Security
{
    public interface ICurrentUser
    {
        //Revisar si esta bien implementada la interfaz
        bool IsAuthenticated { get; }

        Guid? UserId { get; }

        IReadOnlyCollection<string> Permissions { get; }

        bool HasPermission(string permission);
    }
}
