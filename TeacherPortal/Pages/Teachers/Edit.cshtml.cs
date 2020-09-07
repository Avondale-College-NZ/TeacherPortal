using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeacherDirectory.Models;
using TeacherDirectory.Services;

namespace TeacherPortal.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;

        public EditModel(ITeacherRepository teacherRepository,
            IWebHostEnvironment webHostEnviroment)
        {
            this.teacherRepository = teacherRepository;
        }

        public Teacher Teacher { get; set; } 

        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int ID)
        {
          Teacher = teacherRepository.GetTeacher(ID);

          if (Teacher == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Teacher teacher)
        {
            if (Photo != null)
            {
                teacher.PhotoPath = "";
            }

            Teacher = teacherRepository.Update(teacher);
            return RedirectToPage("Index");
        }
    }
}