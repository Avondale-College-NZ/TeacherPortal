using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherDirectory.Models
{
   public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherCode { get; set; }
        public Dept? Department { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
    }
}
