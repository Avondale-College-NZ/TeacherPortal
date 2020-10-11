using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment webHostEnviroment;

        public EditModel(ITeacherRepository teacherRepository,
                         IWebHostEnvironment webHostEnviroment)
        {
            this.teacherRepository = teacherRepository;
            this.webHostEnviroment = webHostEnviroment;
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
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (teacher.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnviroment.WebRootPath,
                            "images", teacher.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    teacher.PhotoPath = ProcessUploadedFile();
                }

                Teacher = teacherRepository.Update(teacher);
                return RedirectToPage("Index");
            }

            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnviroment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}