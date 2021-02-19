using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMVC_Upg1.Data;
using NETMVC_Upg1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SchoolClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public SchoolClassesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SchoolClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: SchoolClasses/Details/5
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

        // GET: SchoolClasses/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: SchoolClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SchoolClassViewModel schoolClass)
        {
            var tests = await _context.Classes.ToListAsync();
            foreach(var test in tests) {
                if (test.Id == schoolClass.Id)
                {
                    ViewBag.ErrorMessage = "Klassnamnet finns redan";

                    return View("Create", schoolClass);
                } 
            }

            if (ModelState.IsValid)
            {
                _context.Add(schoolClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.Classes.FindAsync(id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            var viewModel = new CombineClassesViewModel() //inte säker??
            {
                CurrentClass = schoolClass,
                CurrentUsers = _userManager.Users
            };

            return View(viewModel); ;
        }

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] SchoolClassViewModel schoolClass)
        {
            if (id != schoolClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassExists(schoolClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolClass = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(schoolClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassExists(string id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
