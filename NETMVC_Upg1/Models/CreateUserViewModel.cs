using NETMVC_Upg1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Models
{
    public class CreateUserViewModel : AppUser
    {
        public string Password { get; set; }
    }
}
