using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Application.Authentication
{
    public record SignUpRequestDTO(
        string Username,
        string Password,
        string Name,
        string SecondName,
        DocumentType DocumentType,
        string Document,
        DateTime Birthday,
        string Phone,
        string Mail,
        Association? Association
    ); 
}
