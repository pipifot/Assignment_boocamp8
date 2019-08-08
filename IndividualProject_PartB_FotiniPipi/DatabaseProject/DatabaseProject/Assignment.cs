using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class Assignment
    {

        #region Ass Properties
        public int AssignmentID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime subDateTime { get; set; }
        public decimal oralMark { get; set; }
        public decimal totalMark { get; set; }
        dbmanager db = new dbmanager();
        
        #endregion
        #region Constructors
        public Assignment(string Title, string Description, DateTime SubDateTime, decimal Oralmark, decimal Totalmark)
        {
            title = Title;
            description = Description;
            subDateTime = SubDateTime;
            oralMark = Oralmark;
            totalMark = Totalmark;
        }
        public Assignment()
        {

        }
        #endregion
        public void NewAssignment()
        {
            Console.WriteLine("Enter Assignment's Title");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter Assignment's Description");
            string Description=Console.ReadLine();
            Console.WriteLine("When you have to turn in the assignment");
            bool result0 = DateTime.TryParse(Console.ReadLine(), out DateTime subDateTime);
            while (result0 == false && subDateTime < Convert.ToDateTime((2019, 01, 01)))
            {
                Console.WriteLine("Wrong Input");
                result0 = DateTime.TryParse(Console.ReadLine(), out subDateTime);
            }
            Console.WriteLine("Provide Oral Mark");
            decimal oralmark=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Provide Total Mark");
            decimal totalmark = Convert.ToDecimal(Console.ReadLine());
            db.AddAssignment(Title, Description, subDateTime, oralmark, totalmark);
            db.GetAId(Title);
            Console.WriteLine("Would you like to add this Assignment to a Student?");
            Console.WriteLine("If yes press 'Y'");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine(db.GetCId(Title)); Console.WriteLine("Provide the Student ID for Course to be added to");
                int id = Convert.ToInt32(Console.ReadLine());
                db.AddAssignmenttoStudent(db.GetAId(Title), id);
            }
            Console.WriteLine("Would you like to add this Assignment to a Course?");
            Console.WriteLine("If yes press 'Y'");
            string answer1 = Console.ReadLine();
            if(answer1=="Y")
            {
                Console.WriteLine(db.GetCId(Title)); Console.WriteLine("Provide the Course ID for Course to be added to");
                int id = Convert.ToInt32(Console.ReadLine());
                db.AddAssignmenttoStudent(db.GetAId(Title), id);
            }

        }
        public override string ToString()
        {
            return $"{AssignmentID}, {title},{description},{subDateTime},{oralMark},{totalMark}";
        }

    }
}
