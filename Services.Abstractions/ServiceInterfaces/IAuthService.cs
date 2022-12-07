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
        void Register(User User);
        User Login(LoginModelDto dto);
    }
}
