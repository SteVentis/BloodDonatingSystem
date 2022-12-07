using Domain.Entities.Models.IdentityModels;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void Register(User user)
        {
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
                //new Claim(ClaimTypes.Role, user.Role.Name)
            };
            var accessToken = TokenGenerator.GenerateAccessToken(claims);
            user.Token = accessToken;
            var refreshToken = TokenGenerator.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            string salt = SecurityHelper.GenerateSalt(70);
            string pwdHash = SecurityHelper.HashPassword(user.PasswordHash, salt, 10101, 70);
            user.PasswordHash = pwdHash;

            _repositoryManager.Users.Register(user);

        }
    }
}
