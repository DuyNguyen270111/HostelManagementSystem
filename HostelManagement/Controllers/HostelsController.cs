using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostelManagement.BusinessObject;
using HostelManagement.Models;
using Service;
using DataAccessObject;

namespace HostelManagement.Controllers
{
    public class HostelsController : Controller
    {
        private readonly ProjectttContext _context;
        private readonly IHostelService hostelService;

        public HostelsController()
        {
            _context = new ProjectttContext();
            hostelService = new HostelService();
        }

        // GET: Hostels
        public async Task<IActionResult> Index()
        {
            var hostels = hostelService.GetAllHostel();
            return View(hostels);
        }

        // GET: Hostels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(m => m.HostelId == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // GET: Hostels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HostelId,Name,Location,TotalRooms,Status,Type")] Hostel hostel)
        {
            if (!ModelState.IsValid)
            {
                return View(hostel);
            }
            try
            {
                hostelService.AddHostel(hostel);
                return RedirectToAction(nameof(Index));
            }
            catch(InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(hostel);
            }
    
        }

        // GET: Hostels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = hostelService.GetHostelById(id.Value);
            if (hostel == null)
            {
                return NotFound();
            }
            return View(hostel);
        }

        // POST: Hostels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HostelId,Name,Location,TotalRooms,Status,Type")] Hostel hostel)
        {
            if (id != hostel.HostelId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(hostel);
            }
            try
            {
                hostelService.EditHostelById(hostel);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(hostel);
            }
            return View(hostel);
        }

        private bool HostelExists(int id)
        {
            return _context.Hostels.Any(e => e.HostelId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            try
            {
                hostelService.ToggleStatus(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
