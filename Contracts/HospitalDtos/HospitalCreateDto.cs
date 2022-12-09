using Contracts.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.HospitalDtos
{
    public class HospitalCreateDto 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsBloodDonationCenter { get; set; }
    }
}
