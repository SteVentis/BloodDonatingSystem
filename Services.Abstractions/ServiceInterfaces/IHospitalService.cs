using Contracts.HospitalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.ServiceInterfaces
{
    public interface IHospitalService
    {
        IEnumerable<HospitalReadDto> GetAllHospitals();

        HospitalReadDto GetHospitalById(int id);

        void InsertHospital(HospitalCreateDto hospitalCreateDto);
    }
}
