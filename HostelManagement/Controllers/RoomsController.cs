using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostelManagement.BusinessObject;
using HostelManagement.Models;
<<<<<<< HEAD
using DataAccessObject;
=======
using Service;
>>>>>>> 7e29fa935e0f593dd78eb1c934e1e2fc414d880a

namespace HostelManagement.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ProjectttContext _context;
        private readonly IRoomService roomService;
        public RoomsController()
        {
            _context = new ProjectttContext();
            roomService = new RoomService();
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            int wardenId = 2;
            var roomList = roomService.GetRoomsByWardenId(wardenId);
            ViewBag.HostelName = _context.Wardens
                                        .Include(w => w.Hostel)
                                        .Where(w => w.WardenId == wardenId)
                                        .Select(w => w.Hostel.Name)
                                        .FirstOrDefault();
            return View(roomList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string statusFilter, string searchString, string action)
        {
            int wardenId = 2;
            var roomList = roomService.GetRoomsByWardenId(wardenId).AsQueryable();
            if (action == "filter" && !string.IsNullOrEmpty(statusFilter))
            {
                roomList = roomList.Where(r => r.Status.Equals(statusFilter));
            }else if (action == "search" && !string.IsNullOrEmpty(searchString))
            {
                roomList = roomList.Where(r => r.RoomNumber.Contains(searchString));
            }
            ViewBag.HostelName = _context.Wardens
                                            .Include(w => w.Hostel)
                                            .Where(w => w.WardenId == wardenId)
                                            .Select(w => w.Hostel.Name)
                                            .FirstOrDefault();

            return View(roomList.ToList());
        }
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            int wardenId = 2;
            var hostel = roomService.GetHostelByWardenId(wardenId);
            ViewBag.Hostel = hostel;
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,HostelId,RoomNumber,Capacity,Occupied,Status,Type")] Room room)
        {
            int wardenId = 2;
            if (!ModelState.IsValid)
            {
                ViewBag.Hostel  = roomService.GetHostelByWardenId(wardenId);
                return View(room);
            }
            try
            {
                roomService.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            catch(InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Hostel = roomService.GetHostelByWardenId(wardenId);
                return View(room);
            }

        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            int wardenId = 2;
            if (id == null)
            {
                return NotFound();
            }

            var room = roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            var hostel = roomService.GetHostelByWardenId(wardenId);
            ViewBag.Hostel = hostel;
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,HostelId,RoomNumber,Capacity,Occupied,Status,Type")] Room room)
        {
            int wardenId = 2;
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Hostel = roomService.GetHostelByWardenId(wardenId);
                return View(room);
            }
            try
            {
                roomService.EditRoomById(room);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Hostel = roomService.GetHostelByWardenId(wardenId);
                return View(room);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            try
            {
                roomService.ToggleStatus(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
