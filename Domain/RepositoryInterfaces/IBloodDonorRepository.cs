using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IBloodDonorRepository
    {
        IEnumerable<BloodDonor> GetAllBloodDonors();
        BloodDonor GetDonorByid(int id);
    }
}
