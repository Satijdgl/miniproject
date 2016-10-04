﻿using System;
using System.Collections.Generic;
namespace MiniProject.Models
{


    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }


        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}