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
        [BindProperty]
        public Teacher Teacher { get; set; } 
        //Bind Property reduces the need for the developer to manually extract values.
        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int? ID)
        {
            // if id parameter has value, retrieve the existing
            // teacher details, else create a new Teacher
            if (ID.HasValue)
            {
                Teacher = teacherRepository.GetTeacher(ID.Value);
            }
            else
            {
                Teacher = new Teacher();
            }

            if (Teacher == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Teacher.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnviroment.WebRootPath,
                            "images", Teacher.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    Teacher.PhotoPath = ProcessUploadedFile();
                }
                // If Teacher ID > 0, call Update() to update existing
                // teacher details else call Add() to add a new staff member
                if (Teacher.ID > 0)
                {
                    Teacher = teacherRepository.Update(Teacher);
                }
                else
                {
                    Teacher = teacherRepository.Add(Teacher);
                }
                return RedirectToPage("Index");
            }

            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            //If the Photo property on the incoming model is not empty or null, then the user selected an image to upload//
            if (Photo != null)
            {
                // The image must be uploaded to the images file
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