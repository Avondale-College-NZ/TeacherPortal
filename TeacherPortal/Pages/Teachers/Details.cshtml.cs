﻿using System;
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

        public IActionResult OnGet(int ID)
        {
            //Gets the teacher information from the repository
            Teacher = teacherRepository.GetTeacher(ID);

            if(Teacher == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}