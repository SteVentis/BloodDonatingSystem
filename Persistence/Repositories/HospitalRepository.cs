using Dapper;
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
    public class HospitalRepository : IHospitalRepository
    {
        private readonly DapperContext _dbContext;
        public HospitalRepository(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Hospital> GetAllHospitals()
        {
            string query = "SELECT * FROM Hospitals";

            using (var connection = _dbContext.CreateConnection())
            {
                var hospitals = connection.Query<Hospital>(query);

                return hospitals.ToList();
            }
        }
    }
}
