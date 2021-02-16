using NETMVC_Upg1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Models
{
    public class CombineClassesViewModel
    {
        [Key]
        public int Id { get; set; }
        public SchoolClassViewModel CurrentClass { get; set; }
        public IEnumerable<AppUser> CurrentUsers { get; set; }
    }
}
