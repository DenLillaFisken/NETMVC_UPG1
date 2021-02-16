//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MVCUpg1.Services.Identity;
//using NETMVC_Upg1.Data;
//using NETMVC_Upg1.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NETMVC_Upg1.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class UsersController : Controller
//    {
//        private readonly IIdentityService _identityService;

//        public UsersController(IIdentityService identityService)
//        {
//            _identityService = identityService;
//        }

//        public async Task<IActionResult> Index()
//        {
//            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
//            ViewBag.Roles = _identityService.GetAllRoles();

//            return View();
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateUserViewModel model)
//        {
//            var user = new AppUser()
//            {
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//                Email = model.Email,
//                UserName = model.Email
//            };

//            await _identityService.CreateNewUserAsync(user, model.Password);

//            return RedirectToAction("Index");
//        }
//    }
//}
