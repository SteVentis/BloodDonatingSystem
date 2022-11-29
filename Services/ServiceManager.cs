using Domain.RepositoryInterfaces;
using Services.Abstractions;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        public IHospitalService Hospitals { get; }

        public IPatientService Patients { get; }

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            Hospitals = new HospitalService(repositoryManager);
            Patients = new PatientService(repositoryManager);
            
        }

        public IBloodDonorService BloodDonors => throw new NotImplementedException();

        public IBloodDonationCenterService BloodDonationCenters => throw new NotImplementedException();
    }
}
