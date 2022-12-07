using AutoMapper;
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
        public IBloodDonationCenterService BloodDonationCenters { get; }
        public IBloodDonorService BloodDonors { get; }
        public IAuthService AuthUsers { get; }

        private readonly IMapper _mapper;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            Hospitals = new HospitalService(repositoryManager, mapper);
            Patients = new PatientService(repositoryManager, mapper);
            BloodDonationCenters = new BloodDonationCenterService(repositoryManager, mapper);
            BloodDonors = new BloodDonorService(repositoryManager, mapper);
            AuthUsers = new AuthService(repositoryManager);
        }

        

        
    }
}
