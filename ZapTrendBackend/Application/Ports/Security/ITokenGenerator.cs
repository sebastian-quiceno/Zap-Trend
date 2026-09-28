using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Entities;

namespace ZapTrendBackend.Application.Ports.Security
{
    public interface ITokenGenerator
    {
        //TENER EN CUENTA: es mejor solicitar un dto antes que la entidad
        string Generate(User user);
    }
}
