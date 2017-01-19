using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace WebFormsTest.mvp
{
    public class LookupStudentPresenter : Presenter<ILookupStudentView>
    {
        private readonly IStudentRepository _studentRepository;

        //public LookupStudentPresenter(ILookupStudentView view) : this(view, new StudentRepository())
        //{
        //}

        public LookupStudentPresenter(ILookupStudentView view, IStudentRepository studentRepository) : base(view)
        {       
            _studentRepository = studentRepository;
            View.Finding += Finding;
            view.GetAll += GetAllStudents;
            View.Model.Students = new List<Student>();
        }

        private void GetAllStudents(object sender, GetAllStudentsArgs e)
        {
            IList<Student> allStudents = _studentRepository.GetAllStudents();
            View.Model.Students = allStudents;
            View.Model.ShowResults = true;
        }

        private void Finding(object sender, FindStudentEventArgs e)
        {
            if ((!e.Id.HasValue || e.Id <= 0) && String.IsNullOrEmpty(e.Name))
                return;
            if (e.Id.HasValue && e.Id > 0)
            {
                Student student = _studentRepository.Find((int)e.Id);
                View.Model.Students.Add(student);
            }
            View.Model.ShowResults = true;
        }
    }
}