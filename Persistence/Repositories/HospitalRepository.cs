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
    internal sealed class HospitalRepository : IHospitalRepository
    {
        private readonly DapperContext _dbContext;
        private readonly ILoggerManager _logger;
        public HospitalRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<Hospital> GetAllHospitals()
        {
            string query = "SELECT * FROM Hospitals";

            using (var connection = _dbContext.CreateConnection())
            {
                _logger.LogInfo("Fetching all the Hospitals from database");

                var hospitals = connection.Query<Hospital>(query);              

                return hospitals.ToList();
                
            }
           
        }

        public Hospital GetHospitalById(int id)
        {
            string query = "SELECT * FROM Hospitals WHERE Id = @Id";

            using(var connection = _dbContext.CreateConnection())
            {
                var hospital = connection.QuerySingleOrDefault<Hospital>(query, new { id });

                return hospital;
            }
        }
    }
}
