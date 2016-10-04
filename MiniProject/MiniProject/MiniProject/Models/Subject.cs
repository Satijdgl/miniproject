using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MiniProject.Models
{


    public class Subject
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int CreditHours { get; set; }


        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}