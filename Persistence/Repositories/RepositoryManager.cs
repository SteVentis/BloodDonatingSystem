using Domain.DomainExceptions.Contracts;
using Domain.DomainExceptions.LoggerService;
using Domain.RepositoryInterfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public IHospitalRepository Hospitals { get; }

        public IPatientRepository Patients { get; }

        public IBloodDonationCenterRepository BloodDonationCenters { get; }

        public IBloodDonorRepository BloodDonors { get; }
        public ILoggerManager Logger { get; }

        public IAuthRepository AuthUsers { get; }

        public RepositoryManager(DapperContext dbContext,ILoggerManager logger)
        {
            Logger = logger;
            Hospitals = new HospitalRepository(dbContext,logger);
            Patients = new PatientRepository(dbContext,logger);
            BloodDonationCenters = new BloodDonationCenterRepository(dbContext,logger);
            BloodDonors = new BloodDonorRepository(dbContext, logger);
            AuthUsers = new AuthRepository(dbContext, logger);
        }
    }
}
