using DataAccessObject;
using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management.Repository
{
    public class StudentRepo : IStudentRepo
    {
        public void deleteStudentById(Student s)
        {
            StudentDAO.deleteStudentById(s);
        }

        public void editStudentById(Student s)
        {
            StudentDAO.editStudentById(s);
        }

        public List<Student> getAllStudent()
        {
            return StudentDAO.getAllStudent();
        }
        public Student getStudentById(int id)
        {
            return StudentDAO.getStudentById(id);
        }
    }
}
