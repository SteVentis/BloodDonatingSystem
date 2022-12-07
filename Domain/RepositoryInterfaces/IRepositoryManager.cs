using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        IHospitalRepository Hospitals { get; }

        IPatientRepository Patients { get; }

        IBloodDonationCenterRepository BloodDonationCenters { get; }

        IBloodDonorRepository BloodDonors { get; }

        IUserRepository Users { get; }
    }
}
