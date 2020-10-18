using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeacherDirectory.Models;

namespace TeacherDirectory.Services
{
    public class SQLTeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext context;

        public SQLTeacherRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Teacher Add(Teacher newTeacher)
        {
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            return newTeacher;
        }

        public Teacher Delete(int ID)
        {
            Teacher teacher = context.Teachers.Find(ID);
            if(teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return context.Teachers;
        }

        public Teacher GetTeacher(int ID)
        {
            return context.Teachers.Find(ID);
        }

        public IEnumerable<Teacher> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Teachers;
            }

            return context.Teachers.Where(e => e.FirstName.Contains(searchTerm) ||
            e.Email.Contains(searchTerm));
        }

        public IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept)
        {
            IEnumerable<Teacher> query = context.Teachers;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department)
                            .Select(g => new DeptHeadCount()
                            {
                                Department = g.Key.Value,
                                Count = g.Count()
                            }).ToList();
        }

        public Teacher Update(Teacher updatedTeacher)
        {
            var teacher = context.Teachers.Attach(updatedTeacher);
            teacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedTeacher;
        }
    }
}
