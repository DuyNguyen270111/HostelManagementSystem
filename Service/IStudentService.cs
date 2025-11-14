using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService
    {
        List<Student> getAllStudent();
        Student getStudentById(int id);
        void editStudentById(Student s);
        void deleteStudentById(Student s);
    }
}
