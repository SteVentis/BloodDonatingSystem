using AutoMapper;
using Contracts.Identitydtos;
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
    internal sealed class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public UserReadDto Login(LoginModelDto dto)
        {

            var user = _repositoryManager.AuthUsers.AuthenticateUserWithUserNameOrEmail(dto.UserName);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
                
            };

            var accessToken = TokenGenerator.GenerateAccessToken(claims);
            user.Token = accessToken;
            var refreshToken = TokenGenerator.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            string pwdHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.PasswordHash = pwdHash;
            user.RefreshTokensExpires = DateTime.Now.AddDays(7);

            _repositoryManager.AuthUsers.UpdateUsersTokens(user);

            var mappedUser = _mapper.Map<UserReadDto>(user);

            return mappedUser;
            
        }

        public void Register(RegistrationModelDto dto)
        {
            
            
            var user = _mapper.Map<User>(dto);

            _repositoryManager.AuthUsers.Register(user);

        }
    }
}
