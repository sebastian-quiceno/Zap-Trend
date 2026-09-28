using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Application.Authorization
{
    public record AuthorizationResponseDTO(
        bool Succeeded,
        bool IsAuthenticated
    );
}
