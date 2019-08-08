using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class StudentsperCourse
    {
        Student s2 = new Student();
        Course c2 = new Course();
        dbmanager ex = new dbmanager();

        public void ViewStudentsPerCourse()
        {
            Console.WriteLine("Please provide the id of the course you would like to see the students of");
            int answer;
            bool result = Int32.TryParse(Console.ReadLine(), out answer);
            while (result == false)
            {
                Console.WriteLine("Wrong Input");
                result = Int32.TryParse(Console.ReadLine(), out answer);

            }
            List<Student> sl2 = ex.GetStudentsPerCourse(answer);
            foreach (var item in sl2)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
