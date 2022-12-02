using AutoMapper;
using Contracts.BloodDonationCenterDtos;
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
            var bloodDonationCenters = _repositoryManager.BloodDonationCenters.GetAllBloodDonationCenters();
            var mappedDonationCenters = _mapper.Map<IEnumerable<BloodDonationCenterReadDto>>(bloodDonationCenters);

            return mappedDonationCenters;
        }

        public BloodDonationCenterReadDto GetBloodDonationCenterById(int id)
        {
            var donationCenterFromRepo = _repositoryManager.BloodDonationCenters.GetBloodDonationCenterById(id);
            var mappedDonationCenter = _mapper.Map<BloodDonationCenterReadDto>(donationCenterFromRepo);

            return mappedDonationCenter;
        }
    }
}
