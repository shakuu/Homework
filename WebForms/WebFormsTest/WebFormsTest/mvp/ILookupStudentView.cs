using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace WebFormsTest.mvp
{
    public interface ILookupStudentView : IView<LookupStudentModel>
    {
        event EventHandler<FindStudentEventArgs> Finding;
        event EventHandler<GetAllStudentsArgs> GetAll;
    }

    public class GetAllStudentsArgs : EventArgs
    {
        public GetAllStudentsArgs()
        {
        }

        public GetAllStudentsArgs(IList<Student> allStudents)
        {
            AllStudents = allStudents;
        }

        public IList<Student> AllStudents { get; set; }
    }

    public class FindStudentEventArgs : EventArgs
    {
        public FindStudentEventArgs()
        {
        }

        public FindStudentEventArgs(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}