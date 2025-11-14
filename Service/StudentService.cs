using Hostel_Management.Repository;
using HostelManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo iac;
        public StudentService()
        {
            iac = new StudentRepo();
        }

        public void deleteStudentById(Student s)
        {
            iac.deleteStudentById(s);
        }

        public void editStudentById(Student s)
        {
            iac.editStudentById(s);
        }

        public List<Student> getAllStudent()
        {
            return iac.getAllStudent();
        }

        public Student getStudentById(int id)
        {
            return iac.getStudentById(id);
        }
    }
}
