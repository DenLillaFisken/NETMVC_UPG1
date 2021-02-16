using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Data
{
    public class SchoolClass
    {
        public SchoolClass(string nameOfClass)
        {
            NameOfClass = nameOfClass;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string NameOfClass { get; set; }

    }
}
