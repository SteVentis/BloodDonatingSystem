using Domain.Entities.Models.IdentityModels;
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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsBloodDonationCenter { get; set; }
        public string User_Id { get; set; }
        public User User { get; set; }
    }
}
