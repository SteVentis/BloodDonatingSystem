using Contracts.HospitalDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;

namespace Services
{
    internal sealed class HospitalService : IHospitalService
    {
        private readonly IRepositoryManager _repositoryManager;
        public HospitalService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<HospitalReadDto> GetAllHospitals()
        {
            var hospitalsFromRepo = _repositoryManager.Hospitals.GetAllHospitals();

            var mappedHospitals = new List<HospitalReadDto>();
            
            foreach (var hospital in hospitalsFromRepo)
            {
                var hospitalDto = new HospitalReadDto()
                {
                    Name = hospital.Name,
                    Address = hospital.Address,
                    Email = hospital.Email,
                    Phone = hospital.Phone,
                    IsBloodDonationCenter = hospital.IsBloodDonationCenter
                };
                mappedHospitals.Add(hospitalDto);
            }

            return mappedHospitals;

        }

        public HospitalReadDto GetHospitalById(int id)
        {
            var hospital = _repositoryManager.Hospitals.GetHospitalById(id);

            var dto = new HospitalReadDto
            {
                Name = hospital.Name,
                Address = hospital.Address,
                Phone = hospital.Phone,
                Email = hospital.Email,
                IsBloodDonationCenter = hospital.IsBloodDonationCenter
            };

            return dto;
        }

       
    }
}
