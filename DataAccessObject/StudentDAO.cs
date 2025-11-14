using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.BusinessObject;
using Microsoft.EntityFrameworkCore;


namespace DataAccessObject;

public class StudentDAO
{


    public static List<Student> getAllStudent()
    {
        using (var _context = new ProjectttContext())
        {
            return _context.Students.ToList();
        }

    }
    public static Student getStudentById(int id)
    {
        using (var _context = new ProjectttContext())
        {
            return _context.Students.FirstOrDefault(x => x.StudentId == id);
        }

    }
    public static void editStudentById(Student s)
    {

        using (var _context = new ProjectttContext())
        {
            var existing = _context.Students.FirstOrDefault(x => x.StudentId == s.StudentId);
            if (existing != null)
            {
                // Copy tất cả giá trị từ p sang existing
                //_context.Entry(existing).CurrentValues.SetValues(s);
                //_context.SaveChanges();
                if (s.Name != null) existing.Name = s.Name;
                if (s.Gender != null) existing.Gender = s.Gender;
                if (s.Dob != DateOnly.MinValue) existing.Dob = s.Dob;
                if (s.Course != null) existing.Course = s.Course;
                if (s.Phone != null) existing.Phone = s.Phone;
                if (s.Email != null) existing.Email = s.Email;
                if (s.Address != null) existing.Address = s.Address;
                if (s.Status != null) existing.Status = s.Status;


                _context.SaveChanges();
            }
        }

    }
    public static void deleteStudentById(Student s)
    {
        using (var _context = new ProjectttContext())
        {
            var student = _context.Students.FirstOrDefault(x => x.StudentId == s.StudentId);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

    }
    public static void addStudent(Student s)
    {
        using (var _context = new ProjectttContext())
        {
            var student = _context.Students.Add(s);
            _context.SaveChanges();
        }

    }
}
