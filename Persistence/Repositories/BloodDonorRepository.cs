using Dapper;
using Domain.DomainExceptions.Contracts;
using Domain.Entities.Models;
using Domain.RepositoryInterfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class BloodDonorRepository : IBloodDonorRepository
    {
        private readonly DapperContext _dbContext;
        private readonly ILoggerManager _logger;

        public BloodDonorRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<BloodDonor> GetAllBloodDonors()
        {
            string query = "SELECT * FROM BloodDonors";
            
            using(var connection = _dbContext.CreateConnection())
            {
                _logger.LogInfo("Fetching all Donors from the database.");

                var bloodDonors = connection.Query<BloodDonor>(query);

                return bloodDonors.ToList();
            }
        }

        public BloodDonor GetDonorByid(int id)
        {
            string query = "SELECT * FROM BloodDonors WHERE Id = @id";

            using(var connection = _dbContext.CreateConnection())
            {
                _logger.LogInfo($"Fetch Donor with Id = {id}");

                var donor = connection.QuerySingleOrDefault<BloodDonor>(query, new { id });

                return donor;
            }
        }
    }
}
