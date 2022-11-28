using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.PatientDtos
{
    public class PatientReadDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public int UnitsOfBloodNeeded { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsEmergency { get; set; }
        public int HospitalId { get; set; }
    }
}
