using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            dbmanager first = new dbmanager();
            Student s1 = new Student();
            Course c = new Course();
            Trainer t = new Trainer();
            Assignment a = new Assignment();
            StudentsperCourse sc = new StudentsperCourse();
            TrainersperCourse tc = new TrainersperCourse();
            AssignmentsperCourse ac = new AssignmentsperCourse();
           

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("------------------------------------------");
                Menu.PrintStart();
                int answer;
                bool result0 = int.TryParse(Console.ReadLine(), out answer);

                while (result0 != true || (answer > 3 || answer <= 0))
                {
                    Console.WriteLine("Wrong Input. Select a number between 1-4");
                    result0 = int.TryParse(Console.ReadLine(), out answer);
                }
                Console.Clear();
                Menustart G = (Menustart)answer;
                switch (G)
                {
                    case Menustart.ViewData:
                        Console.WriteLine("What would you like to view?");
                        Menu.PrintView();
                        int print;
                        bool result1 = int.TryParse(Console.ReadLine(), out print);
                        while (result1 != true || (print > 10 || print <= 0))
                        {
                            Console.WriteLine("Wrong Input. Select a number between 1-8");
                            result1 = int.TryParse(Console.ReadLine(), out print);
                        }
                        View H = (View)print;
                        switch (H)
                        {
                            case View.ViewStudents:
                                List<Student> sl1 = first.GetStudents();
                                foreach (var item in sl1)
                                {
                                    Console.WriteLine(item);
                                }                                
                                break;
                            case View.ViewCourses:
                                List<Course> cl1 = first.GetÇourses();
                                foreach (var item in cl1)
                                {
                                    Console.WriteLine(item);
                                }                                
                                break;
                            case View.ViewTrainers:
                                List<Trainer> tl1 = first.GetTrainers();
                                foreach (var item in tl1)
                                {
                                    Console.WriteLine(item);
                                }                                
                                break;
                            case View.ViewAssignments:
                                List<Assignment> al1 = first.GetAssignments();
                                foreach (var item in al1)
                                {
                                    Console.WriteLine(item);
                                }                                
                                break;
                            case View.ViewSperC:
                                sc.ViewStudentsPerCourse();
                                break;
                            case View.ViewTperC:
                                tc.ViewTrainersperCourse();
                                break;
                            case View.ViewAperC:
                                ac.ViewAssignmentsperCourse();
                                break;
                            case View.ViewAperCperS:
                                first.GetAssperStudentperCourse();
                                break;
                            case View.ViewSinmorethanC:
                                s1.ViewStudentsinmultipleCourses();
                                break;
                            case View.Exit:
                                break;
                            default:
                                break;
                        }
                        break;
                    case Menustart.AddData:
                        Console.WriteLine("What would you like to add");
                        Menu.PrintAdd();
                        int answer1;
                        bool result = int.TryParse(Console.ReadLine(), out answer1);

                        while (result != true || (answer1 > 5 || answer1 <= 0))
                        {
                            Console.WriteLine("Wrong Input. Select a number between 1-5");
                            result = int.TryParse(Console.ReadLine(), out answer1);
                        }
                        Add want = (Add)answer1;
                        switch (want)
                        {
                            case Add.AddStudent:                                
                                s1.CreateStudent();                                
                                break;
                            case Add.AddCourse:
                                c.NewCourse();
                                break;
                            case Add.AddTrainer:
                                t.Newtrainer();
                                break;
                            case Add.AddAssignment:
                                a.NewAssignment();
                                break;
                            case Add.Exit:
                                break;
                            default:
                                break;
                        }
                        break;
                    case Menustart.Exit:
                        Environment.Exit(3);
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            }   
           
            
            
                //        s1.CreateStudent();
                        
                        
                        
                //    case 5:
                //        Console.WriteLine("Fill out the details");
                //        Console.WriteLine("Which Student Id would you like to add this course?");

                //        int ID = Convert.ToInt32(Console.ReadLine());
                //        first.AddStudenttoCourse(ID);

                //        string Title = Console.ReadLine();
                //        string Stream= Console.ReadLine();
                //        string Type = Console.ReadLine();
                //        DateTime StartDate = Convert.ToDateTime(Console.ReadLine());
                //        DateTime EndDate = Convert.ToDateTime(Console.ReadLine());
                //        first.AddCourse(Title, Stream, Type, StartDate,EndDate);
                        
                //        break;
                //    case 0:
                //        Environment.Exit(0);
                //        break;

                //}
;
            
            
        }
    }
}
