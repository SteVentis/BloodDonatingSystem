using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IBloodDonationCenterRepository
    {
        IEnumerable<BloodDonationCenter> GetAllBloodDonationCenters();
        BloodDonationCenter GetBloodDonationCenterById(int id);
        
    }
}
