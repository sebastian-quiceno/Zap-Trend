using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Authentication
{
    public record SignInRequestDTO(
        string Username,
        string Password
    );
}
