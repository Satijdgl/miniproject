using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Data.Entity;
	using MiniProject.Models;
	
	namespace MiniProject.DAL
	{ 
    public class AttendanceInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<AttendanceContext>
	{         
		protected override void Seed(AttendanceContext context)
		{
			var students = new List<Student>
			{
				new Student{Name="Asmit Ghimire",Address="Hattiban",Contact="9840070978"},
				new Student{Name="Karma Chand",Address="Sitapaila",Contact="9841930789"},
				new Student{Name="Prabhat Subedi",Address="Balkhu",Contact="9860125478"}
			};
			
			 students.ForEach(d => context.Students.Add(d));
             context.SaveChanges(); 
			 
			 
			var subject = new List<Subject>
			{
				new Subject{SubjectID=1001,Name="Calculus",Teacher="Toya Narayan Poudel",CreditHours=3},
				new Subject{SubjectID=1002,Name="Statistics",Teacher="Bobby Pradhan",CreditHours=3},
				new Subject{SubjectID=1003,Name="Computer Graphics",Teacher="Rohit Maharjan",CreditHours=3}
				};
			
			 subject.ForEach(d => context.Subjects.Add(d));
             context.SaveChanges();
			 
			 
			var attendance = new List<Attendance>
			{
				new Attendance{AttendanceID=1,StudentID=1,SubjectID=1001,Date=DateTime.Parse("2073-01-24"),Status="Present"},
				new Attendance{AttendanceID=2,StudentID=2,SubjectID=1002,Date=DateTime.Parse("2073-01-24"),Status="Absent"},
				new Attendance{AttendanceID=3,StudentID=3,SubjectID=1003,Date=DateTime.Parse("2073-01-24"),Status="Present"}
				};
			
			 attendance.ForEach(d => context.Attendances.Add(d));
             context.SaveChanges();
			  
		 }
	}
}