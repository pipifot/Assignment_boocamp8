using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class Student
    {
        #region Properties
        public int StudentID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime dateofbirth { get; set; }
        public decimal tuitionfee { get; set; }
        public Course many { get; set; }
        public Assignment todo { get; set; }
        
        dbmanager first = new dbmanager();
        #endregion


        public void CreateStudent()
        {
            Console.WriteLine("Enter your FirstName");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter your LastName");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter your Date of Birth");
            bool input = DateTime.TryParse(Console.ReadLine(), out DateTime dateofbirth);
            while (input == false && dateofbirth < Convert.ToDateTime((2015, 01, 01)))
            {
                Console.WriteLine("Wrong Input");
                input = DateTime.TryParse(Console.ReadLine(), out dateofbirth);
            }
            Console.WriteLine("Enter Tuition Fees");
            bool result = decimal.TryParse(Console.ReadLine(),out decimal tuitionfee);
            while(result == false)
            {
                Console.WriteLine("Wrong Input");
                result = decimal.TryParse(Console.ReadLine(), out tuitionfee);
            }
            first.AddStudent(FirstName,LastName,dateofbirth,tuitionfee);
            Console.WriteLine("Successful Entry");
            Console.WriteLine(first.GetId(FirstName, LastName));         
        }
        public void ViewStudentsinmultipleCourses()
        {
            List<Student> stu = first.GetStudentsinmultipleCourses();
            foreach (var item in stu)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintID()
        {
            Console.WriteLine("Find the Student ID by entering your First and Last name");
            Console.WriteLine("Enter FirstName");
            string Firstname = Console.ReadLine();
            Console.WriteLine("Enter your LastName");
            string Lastname = Console.ReadLine();
            Console.WriteLine(first.GetId(Firstname, Lastname));
           
        }
        
        public Student(string Firstname, string Lastname, DateTime dob, decimal tuifee)
        {
            
            firstname = Firstname;
            lastname = Lastname;
            dateofbirth = dob;
            tuitionfee = tuifee;
        }
        public Student()
        {

        }        
       
       

        public override string ToString()
        {
            return $"{StudentID},  {firstname},  {lastname},  {dateofbirth}, {tuitionfee}";
        }

    }
}
