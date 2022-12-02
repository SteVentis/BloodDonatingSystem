using Contracts.BloodDonorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.ServiceInterfaces
{
    public interface IBloodDonorService
    {
        IEnumerable<BloodDonorReadDto> GetAllDonors();
        BloodDonorReadDto GetDonorById(int id);
    }
}
