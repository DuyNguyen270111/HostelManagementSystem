using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;    
using DataAccessObject;
using HostelManagement.BusinessObject;
using Service;

namespace HostelManagement.Controllers
{
    public class HostelUsersController : Controller
    {
        private readonly ProjectttContext _context;
        private readonly IConfiguration _config;
        private readonly IAccountService iac; 
        public HostelUsersController(IConfiguration config)
        {
            _config = config;
            iac = new AccountService();
        }

        // GET: HostelUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HostelUsers.ToListAsync());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            userName = Request.Form["username"];
            password = Request.Form["password"];
            var account = iac.GetAccountByEmailAndPassword(userName, password);
            if (account == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }
            var adminRole = _config.GetValue<string>("Roles:AdminRole");
            
            HttpContext.Session.SetString("UserRole", account.Role);
            HttpContext.Session.SetInt32("UserId", account.UserId);
            HttpContext.Session.SetString("UserName", account.Username);
            if (account.Role.Equals("AdminRole"))
            {
                HttpContext.Session.SetString("UserRoleName", "Admin");
            }
            else if (account.Role.Equals("WardenRole"))  
            {
                HttpContext.Session.SetString("UserRoleName", "Warden");
            }
            else if (account.Role.Equals("StudentRole"))
            {
                HttpContext.Session.SetString("UserRoleName", "Student");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: HostelUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostelUser = await _context.HostelUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (hostelUser == null)
            {
                return NotFound();
            }

            return View(hostelUser);
        }

        // GET: HostelUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostelUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Role")] HostelUser hostelUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostelUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostelUser);
        }

        // GET: HostelUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostelUser = await _context.HostelUsers.FindAsync(id);
            if (hostelUser == null)
            {
                return NotFound();
            }
            return View(hostelUser);
        }

        // POST: HostelUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,Role")] HostelUser hostelUser)
        {
            if (id != hostelUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostelUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelUserExists(hostelUser.UserId))
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
            return View(hostelUser);
        }

        // GET: HostelUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostelUser = await _context.HostelUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (hostelUser == null)
            {
                return NotFound();
            }

            return View(hostelUser);
        }

        // POST: HostelUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostelUser = await _context.HostelUsers.FindAsync(id);
            if (hostelUser != null)
            {
                _context.HostelUsers.Remove(hostelUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelUserExists(int id)
        {
            return _context.HostelUsers.Any(e => e.UserId == id);
        }
    }
}
