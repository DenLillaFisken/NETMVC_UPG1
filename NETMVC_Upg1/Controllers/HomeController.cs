using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUpg1.Services.Identity;
using NETMVC_Upg1.Data;
using NETMVC_Upg1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityService _identityService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<AppUser> userManager, IIdentityService identityService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _identityService = identityService;
        }

        

        public async Task<IActionResult> Index()
        {
            await _identityService.CreateRootAccountAsync();
            return View(_context.Users.ToList());
        }

        [Authorize(Roles = "User")]
        public IActionResult Courses()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Grades()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Schedule()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Litterature()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult LIA()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
