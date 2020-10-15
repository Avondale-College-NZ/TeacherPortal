using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherDirectory.Models
{
   public class Teacher
    {
        public int ID { get; set; }
        [Required, MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherCode { get; set; }
        [Required]
        public Dept? Department { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
    }
}
