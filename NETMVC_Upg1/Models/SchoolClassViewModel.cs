using NETMVC_Upg1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Models
{
    public class SchoolClassViewModel
    {
        [Required]
        [Key]
        public string Id { get; set; }

        public AppUser User { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}
