using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IBloodDonorService BloodDonors { get; }

        IHospitalService Hospitals { get; }

        IPatientService Patients { get; }

        IBloodDonationCenterService BloodDonationCenters { get; }

        IUserService Users { get; }
    }
}
