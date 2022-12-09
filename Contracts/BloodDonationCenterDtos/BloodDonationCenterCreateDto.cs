using Contracts.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BloodDonationCenterDtos
{
    public class BloodDonationCenterCreateDto 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Role_Id { get; set; }
    }
}
