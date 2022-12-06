using Dapper;
using Domain.DomainExceptions.Contracts;
using Domain.Entities.Models.IdentityModels;
using Domain.RepositoryInterfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
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
            var query = "INSERT INTO Users(Username, Email, PasswordHash,Phone, Role_Id)";

            var parameters = new DynamicParameters();
            parameters.Add("Username", user.Email);
            parameters.Add("Email", user.Email);
            parameters.Add("PasswordHash", user.PasswordHash);
            parameters.Add("Phone", user.Phone);
            parameters.Add("Role_Id", user.Role_Id);

            using(var connection = _dbContext.CreateConnection())
            {
                var userRegistration = connection.Execute(query, parameters);
            }
        }
    }
}
