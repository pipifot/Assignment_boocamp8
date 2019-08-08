using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class TrainersperCourse
    {
        Trainer t2 = new Trainer();
        Course c3 = new Course();
        dbmanager ex1 = new dbmanager();

        public void ViewTrainersperCourse()
        {
            Console.WriteLine("Enter Course ID you would like to view its trainers");
            int choice;
            bool result = Int32.TryParse(Console.ReadLine(), out choice);
            while (result == false)
            {
                Console.WriteLine("Wrong Input");
                result = Int32.TryParse(Console.ReadLine(), out choice);

            }
            List<Trainer> tl2 = ex1.GetTrainersperCourse(choice);
            foreach (var item in tl2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
