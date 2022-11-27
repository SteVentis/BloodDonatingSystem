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

        public RepositoryManager(DapperContext dbContext)
        {
            Hospitals = new HospitalRepository(dbContext);
        }
    }
}
