
namespace Homework3.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;
    using TimedEvent;

    public static class TimerTesting
    {
        public static void TimedEventTest()
        {
            var timer = new Timer(5);

            var myStudents = new ClassOfStudents();

            // Student has a constuctor for testing 
            // subscribing to the testing event TimedEvent
            // printing first and last name on event
            myStudents.AddStudent(new Student("1", "1", timer));
            myStudents.AddStudent(new Student("2", "2"));
            myStudents.AddStudent(new Student("3", "3", timer));

            timer.Run();
        }
    }
}
