using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTest.mvp
{

    public class LookupStudentModel
    {
        public bool ShowResults { get; set; }

        public IList<Student> Students { get; set; }
    }
}