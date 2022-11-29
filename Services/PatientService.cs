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

        public PatientService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<PatientReadDto> GetAllPatients()
        {
            var patients = _repositoryManager.Patients.GetAllPatients();

            var patientsDto = new List<PatientReadDto>();

            foreach(var patient in patients)
            {
                var dto = new PatientReadDto()
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    BloodType = patient.BloodType,
                    UnitsOfBloodNeeded = patient.UnitsOfBloodNeeded,
                    IsEmergency = patient.IsEmergency,
                    ExpiresAt = patient.ExpiresAt,
                    HospitalId = patient.Hospital_Id
                };
                patientsDto.Add(dto);
            }

            return patientsDto;
        }

        public PatientReadDto GetPatientById(int id)
        {
            var patient = _repositoryManager.Patients.GetPatientById(id);

            var dto = new PatientReadDto()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                BloodType = patient.BloodType,
                UnitsOfBloodNeeded = patient.UnitsOfBloodNeeded,
                IsEmergency = patient.IsEmergency,
                ExpiresAt = patient.ExpiresAt,
                HospitalId = patient.Hospital_Id
            };

            return dto;
        }

        public void InsertPatient(int hospitalId,PatientCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public void InsertPatient(int hospitalId)
        {
            throw new NotImplementedException();
        }
    }
}
