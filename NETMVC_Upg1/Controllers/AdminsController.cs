using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCUpg1.Services.Identity;
using NETMVC_Upg1.Data;
using NETMVC_Upg1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityService _identityService;

        public AdminsController(ApplicationDbContext context, UserManager<AppUser> userManager, IIdentityService identityService)
        {
            _context = context;
            _userManager = userManager;
            _identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
           
            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
            ViewBag.Roles = _identityService.GetAllRoles();

            return View(await _context.Classes.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }
        public IActionResult Classes()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
