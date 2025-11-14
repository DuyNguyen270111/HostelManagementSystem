
using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management.Repository
{
    public interface IStudentRepo
    {
        Student getStudentById(int id);
        List<Student> getAllStudent();
        void editStudentById(Student s);
        void deleteStudentById(Student s);
    }
}
