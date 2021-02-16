using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMVC_Upg1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NETMVC_Upg1.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SchoolClassViewModel> Classes { get; set; }
    }
}
