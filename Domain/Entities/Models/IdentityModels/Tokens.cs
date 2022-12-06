using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.IdentityModels
{
    public class Tokens
    {
        public string User_Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
