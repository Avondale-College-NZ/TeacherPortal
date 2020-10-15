using System;
using System.Collections.Generic;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int ID);
        Teacher Update(Teacher updatedTeacher);
        Teacher Add(Teacher newTeacher);
        Teacher Delete(int ID);
    }
}
