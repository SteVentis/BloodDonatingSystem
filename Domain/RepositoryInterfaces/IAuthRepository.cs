using Domain.Entities.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IAuthRepository
    {
        void Register(User user);
        User AuthenticateUserWithUserNameOrEmail(string userName);
        void UpdateUsersJWTToken(User user);
        void UpdateRefreshToken(User user);

    }
}
