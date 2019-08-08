Drop Database if exists School
Create Database School

Use School
go

create table Students(
StudentID int identity(1,1) Primary key,
FirstName varchar(50) not null,
LastName varchar(50) not null,
[Date_Of_Birth] datetime not null,
[Tuition_Fees] numeric(18,0) not null
); 

create table Trainers(
TrainerID int identity(1,1) primary key ,
FirstName varchar(50) not null,
LastName varchar (50) not null,
[Subject] varchar(50) not null,
);

create table Assignments(
AssignmentID int identity (1,1) primary key,
Title varchar(30) not null,
[Description] varchar(50) not null,
[subDate] datetime not null,
[OralMark] numeric(18,0) default 0 not null,
[TotalMark] numeric(18,0) default 0 not null,
);
Create Table Courses(
CourseID int Identity(1,1)  primary key not null,
Title varchar(30) not null,
Stream varchar(30) not null,
[Type] varchar(30) not null,
[Start_Date] datetime not null,
[End_Date] datetime not null,

);




create table StudentsperCourse(
CourseID int    references Courses,
StudentID int    references Students,
Primary key(CourseID,StudentID)
);

create table AssignmentsperCourse(
AssignmentID int  references Assignments,
CourseID int  references Courses,
[OralMark] numeric(18,0)not null,
[TotalMark] numeric(18,0) not null,
primary key(AssignmentID,CourseID)
);


create table TrainersperCourse(
CourseID int   references Courses,
TrainerID int  references Trainers,
FirstName varchar(50) null,
[Subject] varchar(50) null,
primary key(CourseID,TrainerID)
);


create table AssignmentsperStudent(
AssignmentID int  references Assignments,
StudentID int references Students,
primary key (AssignmentID,StudentID)
);


/*Inserting Data*/

insert into Students(FirstName,LastName,[Date_Of_Birth],[Tuition_Fees]) values('Fotini','Pipi','1990/03/14',2500)
insert into Courses(Title,Stream,[Type],[Start_Date],[End_Date])values('Chemistry','Organic','Fulltime','2019/09/11','2019/06/15')
insert into Assignments(Title,[Description],[subDate],[OralMark],[TotalMark])values('Project1','describe 2 atoms','2019/10/02',80,85)
insert into Trainers(FirstName,LastName,Subject)values('Dimos','Mpouzalas','Soft SKills')
insert into Students(FirstName,LastName,[Date_Of_Birth],[Tuition_Fees]) values('Thalia','Kiousi','1989/05/18',2400)
insert into Courses(Title,Stream,[Type],[Start_Date],[End_Date])values('SoftSkills','Positioning','Fulltime','2019/09/14','2019/06/01')
insert into Assignments(Title,[Description],[subDate],[OralMark],[TotalMark])values('ProjectX','Create a dialogue','2019/09/25',65,90)
insert into Trainers(FirstName,LastName,Subject)values('Anna','Karamaltidi','Chemistry')

insert into Courses(Title,Stream,[Type],[Start_Date],[End_Date])values('Gymnastics','Loops','Partime','2019/09/08','2019/05/30')
insert into Assignments(Title,[Description],[subDate],[OralMark],[TotalMark])values('Fenia','do loops','2019/11/02',85,90)
declare @assignmentsID int=scope_identity()
declare @coursesID int=scope_identity()
insert into [AssignmentsperCourse] values(@assignmentsID,@coursesID,80,85)

insert into Assignments(Title,[Description],[subDate],[OralMark],[TotalMark])values('Project10','False analysis','2019/9/30',70,85)
insert into Students(FirstName,LastName,[Date_Of_Birth],[Tuition_Fees]) values('Vagia','Kiri','1985/08/26',2150)
declare @assignment_ID int=scope_identity()
declare @student_ID int=scope_identity()
insert into [AssignmentsperStudent] values(@assignment_ID,@student_ID)



insert into Courses(Title,Stream,[Type],[Start_Date],[End_Date])values('Database','Economics','Fulltime','2019/09/09','2019/06/20')
insert into Trainers(FirstName,LastName,Subject)values('Eleni','Lappa','Business Statistics')
declare @trainerid int=scope_identity()
declare @course_id int=scope_identity()
insert into [TrainersperCourse] values(@course_id,@trainerid,'Maria','Business Statistics')




insert into Courses(Title,Stream,[Type],[Start_Date],[End_Date])values('Bootcamp','Java','Parttime','2019/05/15','2019/08/16')
insert into Students(FirstName,LastName,[Date_Of_Birth],[Tuition_Fees]) values('Kimon','Rouselatos','1989/01/26',2250)
declare @CourseID int=scope_identity()
declare @Studentid int=scope_identity()
insert into [StudentsperCourse] values(@CourseID,@Studentid)
/*view data*/
go
create view [view students] as
select * from Students
go

create view [view courses] as
select* from Courses
go
create view[view assignments]as
select * from Assignments
go
create view[view all trainers]as
select * from Trainers
go

select* from Students
join StudentsperCourse 
on Students.StudentID=StudentsperCourse.StudentID
join Courses 
on StudentsperCourse.CourseID=Courses.CourseID

select * from Trainers
join TrainersperCourse
on Trainers.TrainerID=TrainersperCourse.TrainerID
join Courses
on TrainersperCourse.CourseID=Courses.CourseID

select * from Assignments
join AssignmentsperCourse
on Assignments.AssignmentID=AssignmentsperCourse.AssignmentID
join Courses
on AssignmentsperCourse.CourseID=Courses.CourseID

select * from Assignments
join AssignmentsperCourse
on Assignments.AssignmentID=AssignmentsperCourse.AssignmentID
join Courses
on AssignmentsperCourse.CourseID=Courses.CourseID
join StudentsperCourse
on Courses.CourseID=StudentsperCourse.CourseID
join Students
on StudentsperCourse.StudentID=Students.StudentID





   




