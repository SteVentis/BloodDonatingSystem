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
        private readonly IHospitalService _hospitalService;
        

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _hospitalService = new HospitalService(repositoryManager);
            
        }

        public IBloodDonorService BloodDonors => throw new NotImplementedException();

        public IHospitalService Hospitals => _hospitalService;

        public IPatientService Patients => throw new NotImplementedException();

        public IBloodDonationCenterService BloodDonationCenters => throw new NotImplementedException();
    }
}
