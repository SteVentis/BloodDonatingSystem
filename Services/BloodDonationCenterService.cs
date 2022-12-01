using AutoMapper;
using Contracts.BloodDonatioCenterDtos;
using Domain.RepositoryInterfaces;
using Services.Abstractions.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class BloodDonationCenterService : IBloodDonationCenterService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public BloodDonationCenterService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<BloodDonationCenterReadDto> GetAllBloodDonationCenters()
        {
            throw new NotImplementedException();
        }

        public BloodDonationCenterReadDto GetBloodDonationCenterById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
