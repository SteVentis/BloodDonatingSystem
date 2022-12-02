using AutoMapper;
using Contracts.BloodDonorDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class BloodDonorService : IBloodDonorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BloodDonorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<BloodDonorReadDto> GetAllDonors()
        {
            var donors = _repositoryManager.BloodDonors.GetAllBloodDonors();
            var donorsDtos = _mapper.Map<IEnumerable<BloodDonorReadDto>>(donors);

            return donorsDtos;
        }

        public BloodDonorReadDto GetDonorById(int id)
        {
            var donor = _repositoryManager.BloodDonors.GetDonorByid(id);
            var mappedDonor = _mapper.Map<BloodDonorReadDto>(donor);

            return mappedDonor;

        }
    }
}
