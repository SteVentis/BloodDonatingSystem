using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string NameOfHospital { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsBloodDonationCenter { get; set; }
    }
}
