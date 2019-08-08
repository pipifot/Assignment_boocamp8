using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class Course
    {
        #region Properties
        public int CourseID { get; set; }
        public string title1 { get; set; }
        public string stream { get; set; }
        public string type { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        dbmanager db = new dbmanager();
        
        #endregion
        public Course(string Title, string Stream, string Type, DateTime StartDate, DateTime EndDate)

        {
            title1 = Title;
            stream = Stream;
            type = Type;
            startdate = StartDate;
            enddate = EndDate;

        }
        public Course()
        {

        }
        public void NewCourse()
        {
            Console.WriteLine("Enter Course's title");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter Course's stream");
            string Stream = Console.ReadLine();
            Console.WriteLine("Enter Course's type");
            string Type = Console.ReadLine();
            Console.WriteLine("Enter Course's Start Date");
            bool result= DateTime.TryParse(Console.ReadLine(),out DateTime startdate);
            while (result == false && startdate < Convert.ToDateTime((2018, 09, 11)))
            {
                Console.WriteLine("Wrong Input");
                result = DateTime.TryParse(Console.ReadLine(), out startdate);
            }
            Console.WriteLine("Enter Course's end date");
            bool result0 = DateTime.TryParse(Console.ReadLine(), out DateTime enddate);
            while (result0 == false && enddate < Convert.ToDateTime((2019, 01, 01)))
            {
                Console.WriteLine("Wrong Input");
                result0 = DateTime.TryParse(Console.ReadLine(), out enddate);
            }
            db.AddCourse(Title, Stream, Type, startdate, enddate);
            Console.WriteLine("Would you like to add this course to a Student?");
            Console.WriteLine("If yes press 'Y'");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine(db.GetCId(Title)); Console.WriteLine("Provide the Student ID for Course to be added to");
                int id = Convert.ToInt32(Console.ReadLine());
                db.AddStudenttoCourse(db.GetCId(Title), id);
            }
            

        }
        public override string ToString()
        {
            return $"{CourseID}, {title1}, {stream}, {type}, {startdate}, {enddate}";
        }


    }
}
