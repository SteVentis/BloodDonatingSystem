using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Identitydtos
{
    public class LoginModelDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
