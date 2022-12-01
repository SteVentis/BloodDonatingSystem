using AutoMapper;
using Contracts.PatientDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        public PatientService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<PatientReadDto> GetAllPatients()
        {
            var patients = _repositoryManager.Patients.GetAllPatients();

            var patientsDto = _mapper.Map<IEnumerable<PatientReadDto>>(patients);

            
            return patientsDto;
        }

        public PatientReadDto GetPatientById(int id)
        {
            var patient = _repositoryManager.Patients.GetPatientById(id);

            var patientDto = _mapper.Map<PatientReadDto>(patient);

            return patientDto; 
        }

        public void InsertPatient(int hospitalId,PatientCreateDto dto)
        {
            throw new NotImplementedException();
        }

        
    }
}
