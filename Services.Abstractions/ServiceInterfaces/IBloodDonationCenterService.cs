using Contracts.BloodDonatioCenterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.ServiceInterfaces
{
    public interface IBloodDonationCenterService
    {
        IEnumerable<BloodDonationCenterReadDto> GetAllBloodDonationCenters();
        BloodDonationCenterReadDto GetBloodDonationCenterById(int id);
    }
}
