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
    internal sealed class BloodDonationCenterRepository : IBloodDonationCenterRepository
    {
        private readonly DapperContext _dbContext;
        private ILoggerManager _logger;

        public BloodDonationCenterRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<BloodDonationCenter> GetAllBloodDonationCenters()
        {
            string query = "SELECT * FROM BloodDonationCenter";

            using(var connection = _dbContext.CreateConnection())
            {
                _logger.LogInfo("Fetching all the Blood Donation Centers from database");

                var bloodCenters = connection.Query<BloodDonationCenter>(query);

                return bloodCenters.ToList();
            }
        }

        public BloodDonationCenter GetBloodDonationCenterById(int id)
        {
            string query = "SELECT * FROM BloodDonationCenter WHERE Id = @id";

            using(var connection = _dbContext.CreateConnection())
            {
                _logger.LogInfo($"Fetch Blood Donation Center with Id={id}");

                var bloodCenter = connection.QuerySingleOrDefault<BloodDonationCenter>(query, new { id });

                return bloodCenter;
            }
        }
    }
}
