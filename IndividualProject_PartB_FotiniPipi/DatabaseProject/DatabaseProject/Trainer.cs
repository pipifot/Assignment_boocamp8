using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    class Trainer
    {
        public int TrainerID { get; set; }
        public string tfirstname { get; set; }
        public string tlastname { get; set; }
        public string Subject { get; set; }

        dbmanager db = new dbmanager();

        public Trainer(string Tfirstname, string Tlastname, string subject)
        {
            tfirstname = Tfirstname;
            tlastname = Tlastname;
            Subject = subject;
        }
        public Trainer()
        {

        }
        public void Newtrainer()
        {
            Console.WriteLine("Enter Trainer's FirstName");
            string firstname = Console.ReadLine();
            Console.WriteLine("Entrer Trainer's LastName");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter subject");
            string subject = Console.ReadLine();
            db.AddTrainer(firstname, lastname, subject);
            db.GetTId(firstname,lastname);
            Console.WriteLine($"Trainer's ID is: {db.GetTId(firstname,lastname)}");
            Console.WriteLine("Would you like to add this course to a Student?");
            Console.WriteLine("If yes press 'Y'");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine("Select the Course ID you would like to enter the trainer on");
                int id = Convert.ToInt32(Console.ReadLine());
                db.AddTrainertoCourse(id, db.GetTId(firstname, lastname));
            }
                
        }
        public override string ToString()
        {
            return $"{TrainerID}, {tfirstname}, {tlastname}, {Subject}";
        }
    }
}
