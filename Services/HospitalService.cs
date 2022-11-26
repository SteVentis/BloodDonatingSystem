using AutoMapper;
using Contracts.HospitalDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HospitalService : IHospitalService
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
    }
}
