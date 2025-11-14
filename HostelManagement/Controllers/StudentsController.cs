using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObject;
using HostelManagement.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service;

namespace HostelManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ProjectttContext _context;
        private readonly IStudentService ist;
        public StudentsController()
        {
            //_context = context;
            ist = new StudentService();
            _context = new ProjectttContext();
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {

            return View(ist.getAllStudent());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = ist.getStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Gender,Dob,Course,Phone,Email,Address,Status")] Student student)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(student);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = ist.getStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Gender,Dob,Course,Phone,Email,Address")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ist.editStudentById(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Lock(int id)
        {
            var student = ist.getStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái
            student.Status = student.Status == "Active" ? "Inactive" : "Active";

             ist.editStudentById(student); // hoặc context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
