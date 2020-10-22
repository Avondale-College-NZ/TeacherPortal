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
        //Sets the parameters for each of the fields, Required makes it so you can not leave it blank
        //Parameter comes from System.ComponentModel.DataAnnotations, First name can't = null
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
