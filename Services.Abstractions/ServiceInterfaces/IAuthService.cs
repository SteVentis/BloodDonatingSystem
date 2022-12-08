using Contracts.Identitydtos;
using Domain.Entities.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.ServiceInterfaces
{
    public interface IAuthService
    {
        void Register(RegistrationModelDto dto);
        User Login(LoginModelDto dto);
    }
}
