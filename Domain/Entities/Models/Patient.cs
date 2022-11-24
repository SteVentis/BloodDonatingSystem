using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public int UnitsOfBloodNeeded { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsEmergency { get; set; }

        //Navigation Properties
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
