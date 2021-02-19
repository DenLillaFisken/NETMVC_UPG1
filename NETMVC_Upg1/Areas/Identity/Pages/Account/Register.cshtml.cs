using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using NETMVC_Upg1.Data;
using NETMVC_Upg1.Models;

namespace NETMVC_Upg1.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public List<SchoolClassViewModel> SchoolClass { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public int ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string Role { get; set; }

            [Required]
            [Display(Name = "Class name")]
            public string ClassName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            SchoolClass = _context.Classes.ToList(); 

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            SchoolClass = _context.Classes.ToList();
            var _roleName = "User";

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByEmailAsync(Input.Email);
                var teachers = _userManager.Users.Where(u => u.Role == "Teacher" && u.ClassName == Input.ClassName);

                if (!teachers.Any() && Input.Role != "Teacher")
                {
                    ModelState.AddModelError("Error", "Det finns ingen lärare i klassen");
                    return Page();
                }
                var user = new AppUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    ClassName = Input.ClassName,
                    Role = Input.Role
                };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!_roleManager.Roles.Any())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _roleManager.CreateAsync(new IdentityRole("User"));
                    }

                    if (_userManager.Users.Count() == 1)
                        await _userManager.AddToRoleAsync(user, "Admin");
                    else
                        await _userManager.AddToRoleAsync(user, "User");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
