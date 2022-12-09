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
    internal sealed class AuthRepository : IAuthRepository
    {
        private readonly DapperContext _dbContext;
        private readonly ILoggerManager _logger;
        public AuthRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Register(User user)
        {
            var query = $"INSERT INTO Users(Id, UserName, Email, PasswordHash, RefreshToken, RefreshTokenExpires, Role_Id)" +
                $"VALUES(@Id, @UserName, @Email, @PasswordHash, @RefreshToken, @RefreshTokenExpires,  @Role_Id)";

            user.Id = Guid.NewGuid();

            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id, DbType.Guid);
            parameters.Add("UserName", user.Email, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("PasswordHash", user.PasswordHash, DbType.String);
            parameters.Add("RefreshToken", user.RefreshToken, DbType.String);
            parameters.Add("RefreshTokenExpires", user.RefreshTokensExpires, DbType.DateTime);
            parameters.Add("Role_Id", user.Role_Id, DbType.Int32);

            using(var connection = _dbContext.CreateConnection())
            {
                var userRegistration = connection.Execute(query, parameters);
            }
        }

        public User AuthenticateUserWithUserNameOrEmail(string userName)
        {
            var query = "SELECT * FROM Users WHERE UserName=@userName OR Email=@userName";

            var param = new { Username = userName };

            using(var connection = _dbContext.CreateConnection())
            {
                var user = connection.QuerySingle<User>(query,param);
                
                return user;
            }
        }

        public void UpdateUsersJWTToken(User user)
        {
            var query = "UPDATE Users SET Token = @Token WHERE Id=@Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id, DbType.Guid);
            parameters.Add("Token", user.Token, DbType.String);
            

            using(var connection = _dbContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void UpdateRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
