using Contracts.PatientDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.ServiceInterfaces
{
    public interface IPatientService
    {
        IEnumerable<PatientReadDto> GetAllPatients();
        PatientReadDto GetPatientById(int id);
        void InsertPatient(int hospitalId);

    }
}
