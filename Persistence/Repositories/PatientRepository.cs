using Dapper;
using Domain.DomainExceptions.Contracts;
using Domain.Entities.Models;
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
    public class PatientRepository : IPatientRepository
    {
        private readonly ILoggerManager _logger;
        private readonly DapperContext _dbContext;

        public PatientRepository(DapperContext dbContext, ILoggerManager logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            string query = "SELECT * FROM Patients";

            using(var connection = _dbContext.CreateConnection())
            {
                var patients = connection.Query<Patient>(query);

                return patients.ToList();
            }
        }

        public Patient GetPatientById(int id)
        {
            string query = "SELECT * FROM Patients WHERE Id= @id";

            using(var connection = _dbContext.CreateConnection())
            {
                var patient = connection.QuerySingleOrDefault<Patient>(query, new { id });

                return patient;
            }
        }

        public void InsertPatient(int hospitalId, Patient patient)
        {
            string query = $"INSERT INTO Patients(FirstName,LastName,DateOfBirth,BloodType,UnitOfBloodNeeded,ExpiresAt,IsEmergency,Hospital_Id) " +
                $"VALUES(@FirstName, @LastName, @DateOfBirth, @BloodType, @UnitOfBloodNeeded, @ExpiresAt, @IsEmergency, @Hospital_Id)";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", patient.FirstName, DbType.String);
            parameters.Add("LastName", patient.LastName, DbType.String);
            parameters.Add("DateOfBirth", patient.DateOfBirth, DbType.Date);
            parameters.Add("BloodType", patient.BloodType, DbType.Int32);
            parameters.Add("UnitsOfBloodNeeded", patient.UnitsOfBloodNeeded, DbType.Int32);
            parameters.Add("ExpiresAt", patient.ExpiresAt, DbType.Date);
            parameters.Add("IsEmergency", patient.IsEmergency, DbType.Boolean);
            parameters.Add("Hospital_Id", hospitalId, DbType.Int32);

            using(var connection = _dbContext.CreateConnection())
            {
                var patientToBeInserted = connection.Execute(query, parameters);
            }
        }
    }
}
