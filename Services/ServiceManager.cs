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
        private readonly Lazy<IHospitalService> _lazyHospitalService;
        private readonly Lazy<IBloodDonorService> _lazyBloodDonorService;
        private readonly Lazy<IPatientService> _lazyPatientService;
        private readonly Lazy<IBloodDonationCenterService> _lazyBloodDonationCenterService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyHospitalService = new Lazy<IHospitalService>(() => new HospitalService(repositoryManager));
        }

        public IBloodDonorService BloodDonors => throw new NotImplementedException();

        public IHospitalService Hospitals => _lazyHospitalService.Value;

        public IPatientService Patients => throw new NotImplementedException();

        public IBloodDonationCenterService BloodDonationCenters => throw new NotImplementedException();
    }
}
