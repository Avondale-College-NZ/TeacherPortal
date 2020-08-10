using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherPortal.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;

        public DetailsModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public Teacher Teacher { get; private set; }

        public void OnGet(int ID)
        {
            Teacher = teacherRepository.GetTeacher(ID);
        }
    }
}