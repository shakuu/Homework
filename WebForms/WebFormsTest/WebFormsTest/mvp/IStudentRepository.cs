using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTest.mvp
{
    public interface IStudentRepository
    {
        IList<Student> GetAllStudents();

        Student Find(int id);
    }
}