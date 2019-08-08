using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    enum Menustart
    {
        ViewData=1,
        AddData,
        Exit
    }
    enum View
    {
        ViewStudents=1,
        ViewCourses,
        ViewTrainers,
        ViewAssignments,
        ViewSperC,
        ViewTperC,
        ViewAperC,
        ViewAperCperS,
        ViewSinmorethanC,
        Exit
    }
    enum Add
    {
        AddStudent=1,
        AddCourse,
        AddTrainer,
        AddAssignment,
        Exit
    }
    class Menu
    {
        static List<string> StartMenu = new List<string> { "1.View Data", "2.Add Data", "3.Exit" };
        public static List<string> startmenu()
        {
            foreach (var item in StartMenu)
            {
                Console.WriteLine(item);
            }
            return Menu.StartMenu;
        }

        static List<string> ViewData = new List<string>() {"1.View Students","2.View Courses","3.View Trainers",
                                                          "4.View Assignments","5.View Students per Course",
                                                          "6 View Trainers per Course","7.View Assignments per Course",
                                                          "8.View Assignements per Course per Student",
                                                          "9. View all Courses of a Student","10.Exit"
        };
        public static List<string> PrintStart()
        {
            foreach (var item in StartMenu)
            {
                Console.WriteLine(item);
            }
            return Menu.StartMenu;
        }
        public static List<string> PrintView()
        {
            foreach (var item in ViewData)
            {
                Console.WriteLine(item);
            }
            return Menu.ViewData;
        }
        static List<string> addmenu = new List<string>() { "1.Add Student", "2.Add Course", "3.Add Trainer", "4.Add Assignment", "5.Exit" };
        public static List<string> PrintAdd()
        {
            foreach (var item in addmenu)
            {
                Console.WriteLine(item);
            }
            return Menu.addmenu;
        }
       
             
    }
}
