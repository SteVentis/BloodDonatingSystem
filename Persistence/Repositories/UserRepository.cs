using Dapper;
using Domain.DomainExceptions.Contracts;
using Domain.Entities.Models.IdentityModels;
using Domain.RepositoryInterfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly DapperContext _dbContext;
        private readonly ILoggerManager _logger;
        public UserRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Register(User user)
        {
            var query = $"INSERT INTO Users(Id, UserName, Email, PasswordHash, Token, RefreshToken, Role_Id)" +
                $"VALUES(@Id, @UserName, @Email, @PasswordHash, @Token, @RefreshToken, @Role_Id)";

            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id, DbType.Guid);
            parameters.Add("Username", user.Email, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("PasswordHash", user.PasswordHash, DbType.String);
            parameters.Add("Token", user.Token, DbType.String);
            parameters.Add("RefreshToken", user.RefreshToken, DbType.String);
            parameters.Add("Role_Id", user.Role_Id, DbType.Int32);

            using(var connection = _dbContext.CreateConnection())
            {
                var userRegistration = connection.Execute(query, parameters);
            }
        }
    }
}
