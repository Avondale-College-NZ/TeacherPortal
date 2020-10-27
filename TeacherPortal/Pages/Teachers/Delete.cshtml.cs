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
    public class DeleteModel : PageModel
    {
        private readonly ITeacherRepository teacherRepository;
        public DeleteModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }
        public IActionResult OnGet(int ID)
        {
            Teacher = teacherRepository.GetTeacher(ID);
            //Uses the get teache method, if the teacher is null, you will be ridirected to the notfound razor page
            if(Teacher == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Teacher deletedTeacher = teacherRepository.Delete(Teacher.ID);

            if (deletedTeacher == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Index");
        }
    }
}