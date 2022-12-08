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

        public User Login(LoginModelDto dto)
        {

            var user = _repositoryManager.AuthUsers.AuthenticateUserWithUserNameOrEmail(dto.UserName);

            return user;
            
        }

        public void Register(RegistrationModelDto dto)
        {
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, dto.UserName)
            };

            var accessToken = TokenGenerator.GenerateAccessToken(claims);
            dto.Token = accessToken;
            var refreshToken = TokenGenerator.GenerateRefreshToken();
            dto.RefreshToken = refreshToken;
            string pwdHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);
            dto.PasswordHash = pwdHash;
            dto.RefreshTokensExpires = DateTime.Now.AddDays(7);
            var user = _mapper.Map<User>(dto);

            _repositoryManager.AuthUsers.Register(user);

        }
    }
}
