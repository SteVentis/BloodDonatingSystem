using Contracts.HospitalDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;
using AutoMapper;

namespace Services
{
    internal sealed class HospitalService : IHospitalService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public HospitalService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<HospitalReadDto> GetAllHospitals()
        {
            var hospitalsFromRepo = _repositoryManager.Hospitals.GetAllHospitals();
            var mappedHospitals = _mapper.Map<IEnumerable<HospitalReadDto>>(hospitalsFromRepo);

            return mappedHospitals;

        }

        public HospitalReadDto GetHospitalById(int id)
        {
            var hospital = _repositoryManager.Hospitals.GetHospitalById(id);

            var hospitalDto = _mapper.Map<HospitalReadDto>(hospital);

            return hospitalDto;
        }

        public void InsertHospital(HospitalCreateDto hospitalCreateDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalCreateDto);

            _repositoryManager.Hospitals.InsertHospital(hospital);

        }
       
    }
}
