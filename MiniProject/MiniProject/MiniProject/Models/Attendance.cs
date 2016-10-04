using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MiniProject.Models
{


    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
           "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        public string Status { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}