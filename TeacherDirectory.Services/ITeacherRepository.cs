using System;
using System.Collections.Generic;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public interface ITeacherRepository
    {
        //I used a temporary repository before migrating to the SQL server. These display all the functions of my application.
        IEnumerable<Teacher> Search(string searchTerm);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int ID);
        Teacher Update(Teacher updatedTeacher);
        Teacher Add(Teacher newTeacher);
        Teacher Delete(int ID);
        IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept);
    }
}
