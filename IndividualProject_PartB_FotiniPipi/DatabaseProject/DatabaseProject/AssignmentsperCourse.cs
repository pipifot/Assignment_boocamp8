using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class AssignmentsperCourse
    {
        Assignment a2 = new Assignment();
        Course c4 = new Course();
        dbmanager db = new dbmanager();

        public void ViewAssignmentsperCourse()
        {
            Console.WriteLine("Provide Course Id to view assignments of it");
            int answer;
            bool result = Int32.TryParse(Console.ReadLine(), out answer);
            while (result == false)
            {
                Console.WriteLine("Wrong Input");
                result = Int32.TryParse(Console.ReadLine(), out answer);
            }
            List<Assignment> al2 = db.GetAssignmentsperCourse(answer);
            foreach (var item in al2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
