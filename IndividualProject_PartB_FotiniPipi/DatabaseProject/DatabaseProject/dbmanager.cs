using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseProject
{
    class dbmanager
    {
        private readonly string conn_string= @"Data Source=FOTINI-LAP\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #region AddStudent
        public List<Student> GetStudents()
        {
            List<Student> sl1 = new List<Student>();
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Students",conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = (int)rdr["StudentID"];
                            string Firstname = (string)rdr["FirstName"];
                            string Lastname = (string)rdr["LastName"];
                            DateTime dob = (DateTime)rdr["Date_Of_Birth"];
                            decimal Tuitionfee = (decimal)rdr["Tuition_Fees"];
                            Student s1 = new Student()
                            {
                                StudentID = id,
                                firstname = Firstname,
                                lastname = Lastname,
                                dateofbirth = dob,
                                tuitionfee = Tuitionfee
                            };
                            sl1.Add(new Student()
                            {
                                StudentID = (int)rdr["StudentID"],
                                firstname = (string)rdr["FirstName"],
                                lastname = (string)rdr["LastName"],
                                dateofbirth = (DateTime)rdr["Date_Of_Birth"],
                                tuitionfee = (decimal)rdr["Tuition_Fees"]
                            });
                            
                        }
                        
                        

                    }
                }
            }

            return sl1;
            
        }
       
        public void AddStudent(string FirstName,string LastName,DateTime DateofBirth,decimal Tuitionfees)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Students(FirstName,LastName,Date_Of_Birth,Tuition_Fees)values(@firstname,@lastname,@dateofbirth,@tuitionfee)", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("firstname", FirstName));
                    cmd.Parameters.Add(new SqlParameter("lastname", LastName));
                    cmd.Parameters.Add(new SqlParameter("dateofbirth", DateofBirth));
                    cmd.Parameters.Add(new SqlParameter("tuitionfee", Tuitionfees));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region AddCourse
        public List<Course> GetÇourses()
        {
            List<Course> cl1 = new List<Course>();
            using (SqlConnection conn1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Courses",conn1))
                {
                    conn1.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["CourseID"];
                            string title = (string)rdr["Title"];
                            string Stream = (string)rdr["Stream"];
                            string Type = (string)rdr["Type"];
                            DateTime Startdate = (DateTime)rdr["Start_Date"];
                            DateTime Enddate = (DateTime)rdr["End_date"];

                            Course C1 = new Course()
                            {
                                CourseID = ID,
                                title1 = title,
                                stream = Stream,
                                type = Type,
                                startdate = Startdate,
                                enddate = Enddate,
                            };
                            cl1.Add(new Course()
                            {
                                CourseID = (int)rdr["CourseID"],
                                title1 = (string)rdr["Title"],
                                stream = (string)rdr["Stream"],
                                type = (string)rdr["Type"],
                                startdate = (DateTime)rdr["Start_Date"],
                                enddate = (DateTime)rdr["End_Date"],
                            });

                        }

                    }
                }
            }
            return cl1;
        }
        public void AddCourse(string Title, string Stream, string Type, DateTime StartDate, DateTime EndDate)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Courses(Title,Stream,Type,Start_Date,End_Date)values(@title,@stream,@type,@startdate,@enddate)", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("Title", Title));
                    cmd.Parameters.Add(new SqlParameter("Stream", Stream));
                    cmd.Parameters.Add(new SqlParameter("type", Type));
                    cmd.Parameters.Add(new SqlParameter("startdate", StartDate));
                    cmd.Parameters.Add(new SqlParameter("enddate", EndDate));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region AddTrainer
        public List<Trainer> GetTrainers()
        {
            List<Trainer> tl1 = new List<Trainer>();
            using (SqlConnection conn1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Trainers",conn1))
                {
                    conn1.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["TrainerID"];
                            string firstname = (string)rdr["FirstName"];
                            string lastname = (string)rdr["LastName"];
                            string subject = (string)rdr["Subject"];
                            Trainer T1 = new Trainer()
                            {
                                 TrainerID= ID,
                                 tfirstname = firstname,
                                 tlastname=lastname,
                                 Subject=subject
                                
                            };
                            tl1.Add(new Trainer()
                            {
                                TrainerID = (int)rdr["TrainerID"],
                                tfirstname = (string)rdr["Firstname"],
                                tlastname = (string)rdr["Lastname"],
                                Subject = (string)rdr["Subject"],                                
                            });

                        }

                    }
                }
            }
            return tl1;
        }
        public void AddTrainer(string firstname,string lastname,string subject)
        {
            using(SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Trainers(FirstName,LastName,Subject)values(@firstname,@lastname,@subject)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("FirstName", firstname));
                    cmd.Parameters.Add(new SqlParameter("LastName", lastname));
                    cmd.Parameters.Add(new SqlParameter("Subject", subject));
                    cmd.ExecuteNonQuery();
                }

            }
        }
        #endregion
        #region AddAssignment
        public List<Assignment> GetAssignments()
        {
            List<Assignment> al1 = new List<Assignment>();
            using (SqlConnection conn1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Assignments",conn1))
                {
                    conn1.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["AssignmentID"];
                            string Title = (string)rdr["Title"];
                            string Description = (string)rdr["Description"];
                            DateTime subdate = (DateTime)rdr["subDate"];
                            decimal oralmark = (decimal)rdr["OralMark"];
                            decimal totalmark = (decimal)rdr["TotalMark"];
                            Assignment A1 = new Assignment()
                            {
                                 AssignmentID= ID,
                                 title = Title,
                                 description=Description,
                                 subDateTime=subdate,
                                 oralMark=oralmark,
                                 totalMark=totalmark,
                                
                            };
                            al1.Add(new Assignment()
                            {
                                AssignmentID = (int)rdr["AssignmentID"],
                                title = (string)rdr["Title"],
                                description = (string)rdr["Description"],
                                subDateTime = (DateTime)rdr["subDate"],
                                oralMark=(decimal)rdr["OralMark"],
                                totalMark=(decimal)rdr["TotalMark"],
                            });

                        }

                    }
                }
            }
            return al1;
        }
        public void AddAssignment(string title, string description, DateTime subdatetime, decimal oralmark,decimal totalmark)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Assignments(Title,Description,subDate,OralMark,TotalMark)values(@title,@description,@subdatetime,@oralmark,@totalmark)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("Title", title));
                    cmd.Parameters.Add(new SqlParameter("Description", description));
                    cmd.Parameters.Add(new SqlParameter("subDate", subdatetime));
                    cmd.Parameters.Add(new SqlParameter("OralMark", oralmark));
                    cmd.Parameters.Add(new SqlParameter("TotalMark", totalmark));
                    cmd.ExecuteNonQuery();
                }

            }
        }
        #endregion
        #region GetMiddleTables
        public List<Student> GetStudentsPerCourse(int courseId)
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(conn_string))
            {                

                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Students join StudentsperCourse on Students.StudentID= StudentsperCourse.StudentID WHERE StudentsperCourse.CourseID = {courseId}", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = (int)rdr["StudentID"];
                            string Firstname = (string)rdr["FirstName"];
                            string Lastname = (string)rdr["LastName"];
                            DateTime dob = (DateTime)rdr["Date_Of_Birth"];
                            decimal Tuitionfee = (decimal)rdr["Tuition_Fees"];
                            Student s1 = new Student()
                            {
                                StudentID = id,
                                firstname = Firstname,
                                lastname = Lastname,
                                dateofbirth = dob,
                                tuitionfee = Tuitionfee
                            };
                            students.Add(new Student()
                            {
                                StudentID = (int)rdr["StudentID"],
                                firstname = (string)rdr["FirstName"],
                                lastname = (string)rdr["LastName"],
                                dateofbirth = (DateTime)rdr["Date_Of_Birth"],
                                tuitionfee = (decimal)rdr["Tuition_Fees"]
                            });



                        }
                    }
                }
            }
            return students;
        }
        public List<Trainer> GetTrainersperCourse(int courseid)
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                
                using(SqlCommand cmd=new SqlCommand($"select * from Trainers join TrainersperCourse on Trainers.TrainerID=TrainersperCourse.TrainerID where TrainersperCourse.CourseID={courseid} ", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["TrainerID"];
                            string firstname = (string)rdr["FirstName"];
                            string lastname = (string)rdr["LastName"];
                            string subject = (string)rdr["Subject"];
                            Trainer T1 = new Trainer()
                            {
                                TrainerID = ID,
                                tfirstname = firstname,
                                tlastname = lastname,
                                Subject = subject

                            };
                            trainers.Add(new Trainer()
                            {
                                TrainerID = (int)rdr["TrainerID"],
                                tfirstname = (string)rdr["Firstname"],
                                tlastname = (string)rdr["Lastname"],
                                Subject = (string)rdr["Subject"],
                            });
                        }
                    }
                }
            }
            return trainers;
        }
        public List<Assignment> GetAssignmentsperCourse(int courseid)
        {
            List<Assignment> assignments = new List<Assignment>();
            using(SqlConnection conn = new SqlConnection(conn_string))
            {
                
                using (SqlCommand cmd = new SqlCommand($"select * from Assignments join AssignmentsperCourse on Assignments.AssignmentID=AssignmentsperCourse.AssignmentID where AssignmentsperCourse.CourseID={courseid}", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {                           
                            assignments.Add(new Assignment()
                            {
                                AssignmentID = (int)rdr["AssignmentID"],
                                title = (string)rdr["Title"],
                                description = (string)rdr["Description"],
                                subDateTime = (DateTime)rdr["subDate"],
                                oralMark = (decimal)rdr["OralMark"],
                                totalMark = (decimal)rdr["TotalMark"],
                            });

                        }
                    }
                }
            }
            return assignments;
        }
        public List<Assignment>GetAssignmentsperStudent(int studentid)
        {
            List<Assignment> as1 = new List<Assignment>();
            using(SqlConnection conn=new SqlConnection(conn_string))
            {
                using(SqlCommand cmd = new SqlCommand($"select * from Assignments join AssignmentsperStudent on Assignments.AssignmentID=AssignmentsperStudent.AssignmentID where AssignmentsperStudent.StudentID={studentid}", conn))
                {
                    conn.Open();
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["AssignmentID"];
                            string Title = (string)rdr["Title"];
                            string Description = (string)rdr["Description"];
                            DateTime subdate = (DateTime)rdr["subDate"];
                            decimal oralmark = (decimal)rdr["OralMark"];
                            decimal totalmark = (decimal)rdr["TotalMark"];
                            Assignment A1 = new Assignment()
                            {
                                AssignmentID = ID,
                                title = Title,
                                description = Description,
                                subDateTime = subdate,
                                oralMark = oralmark,
                                totalMark = totalmark,

                            };
                            as1.Add(new Assignment()
                            {
                                AssignmentID = (int)rdr["AssignmentID"],
                                title = (string)rdr["Title"],
                                description = (string)rdr["Description"],
                                subDateTime = (DateTime)rdr["subDate"],
                                oralMark = (decimal)rdr["OralMark"],
                                totalMark = (decimal)rdr["TotalMark"],
                            });

                        }
                    }
                }
            }
            return as1;
        }
        public List<Assignment> GetAssperStudentperCourse()
        {
            List<Assignment> as3 = new List<Assignment>();
            using(SqlConnection conn =new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Assignments join AssignmentsperStudent as a on Assignments.AssignmentID=a.AssignmentID join AssignmentsperCourse ac on a.AssignmentID=ac.AssignmentID join Courses on ac.CourseID = Courses.CourseID",conn))
                {
                    conn.Open();
                    using(SqlDataReader rdr= cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int ID = (int)rdr["AssignmentID"];
                            string Title = (string)rdr["Title"];
                            string Description = (string)rdr["Description"];
                            DateTime subdate = (DateTime)rdr["subDate"];
                            decimal oralmark = (decimal)rdr["OralMark"];
                            decimal totalmark = (decimal)rdr["TotalMark"];
                            Assignment A1 = new Assignment()
                            {
                                AssignmentID = ID,
                                title = Title,
                                description = Description,
                                subDateTime = subdate,
                                oralMark = oralmark,
                                totalMark = totalmark,

                            };
                            as3.Add(new Assignment()
                            {
                                AssignmentID = (int)rdr["AssignmentID"],
                                title = (string)rdr["Title"],
                                description = (string)rdr["Description"],
                                subDateTime = (DateTime)rdr["subDate"],
                                oralMark = (decimal)rdr["OralMark"],
                                totalMark = (decimal)rdr["TotalMark"],
                            });

                        }
                    }
                }
            }
            return as3;
        }
        public List<Student> GetStudentsinmultipleCourses()
        {
            List<Student> sl4 = new List<Student>();
            using(SqlConnection conn = new SqlConnection(conn_string))
            {
                using(SqlCommand cmd = new SqlCommand("select * from Students, (SELECT COUNT(CourseID) AS p, StudentID FROM StudentsperCourse GROUP BY StudentID) AS g WHERE g.p > 1 AND g.StudentID = Students.StudentID", conn))
                {
                    conn.Open();
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            sl4.Add(new Student()
                            {
                                firstname = (string)rdr["FirstName"],
                                lastname = (string)rdr["FirstName"],
                                dateofbirth = (DateTime)rdr["DateOfBirth"],
                                tuitionfee = (int)rdr["TuitionFees"]
                            });
                        }
                    }
                }
                
                    
            }
            return sl4;
        }
        #endregion
        #region FillMiddleTables
        public void AddStudenttoCourse(int CourseId,int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("insert into StudentsperCourse (CourseID,StudentID)values(@CourseId,@StudentID", conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("CourseID", CourseId));
                        cmd.Parameters.Add(new SqlParameter("StudentID", StudentID));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void AddTrainertoCourse(int courseid,int trainerid)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("insert into TrainersperCourse (CourseID,TrainerID)values(@courseid,@trainerid", conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("CourseID", courseid));
                        cmd.Parameters.Add(new SqlParameter("TrainerID", trainerid));

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        public void AddAssignmenttoStudent(int assid, int studentid)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("insert into AssignmentsperStudent (AssignmentID,StudentID)values(@assid,@studentid", conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("AssignmentID", assid));
                        cmd.Parameters.Add(new SqlParameter("StudentID", studentid));

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        public void AddAssignmenttoCourse(int assid, int courseid)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("insert into AssignmentsperCourse (AssignmentID,CourseID)values(@assid,@courseid", conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("AssignmentID", assid));
                        cmd.Parameters.Add(new SqlParameter("CourseID", courseid));

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        #endregion
        #region GetIDs
        public int GetId(string firstname,string lastname)
        {
            int ID=0;
            using(SqlConnection conn=new SqlConnection(conn_string))
            {
                using(SqlCommand cmd = new SqlCommand($"select StudentId from Students where FirstName = '{firstname}' and LastName = '{lastname}'",conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {


                            ID = (int)rdr["StudentID"];
                        }
                             
                    }
                }
            }
            return ID;
        }
        public int GetCId(string title)
        {
            int ID = 0;
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand($"select * from Courses where Title ='{title}'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            
                            {
                                ID = (int)rdr["CourseID"];
                                
                            }
                        }
                    }
                }
            }
            return ID;
        }
        public int GetTId(string firstname,string lastname)
        {
            int ID = 0;
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand($"select * from Trainers where FirstName ='{firstname}' and LastName='{lastname}'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            
                            {
                                ID = (int)rdr["TrainerID"];
                                
                            }
                        }
                    }
                }
            }
            return ID;
        }
        public int GetAId(string title)
        {
            int ID = 0;
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand($"select * from Assignments where Title ='{title}'", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                           
                            {
                                ID = (int)rdr["AssignmentID"];
                               
                            }
                        }
                    }
                }
            }
            return ID;
        }

        #endregion


    }

}
        
        
        

