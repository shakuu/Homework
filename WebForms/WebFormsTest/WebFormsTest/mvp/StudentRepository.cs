using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTest.mvp
{
    public class StudentRepository : IStudentRepository
    {
        public Student Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}