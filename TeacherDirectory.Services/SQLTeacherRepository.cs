using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        //Mock Employee repository details again, but linking the functions to the SQL server
        public Teacher Add(Teacher newTeacher)
        {
            context.Database.ExecuteSqlRaw("spInsertTeacher {0}, {1}, {2}, {3}",
                newTeacher.FirstName,
                newTeacher.Email,
                newTeacher.PhotoPath,
                newTeacher.Department);
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
        //Auto Generated code with the connection.
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return context.Teachers
                     .FromSqlRaw("SELECT * FROM Teachers")
                     .ToList();
        }

        public Teacher GetTeacher(int ID)
        {
            SqlParameter parameter = new SqlParameter("@ID", ID);

            return context.Teachers
                .FromSqlRaw<Teacher>("spGetTeacherByID @ID", parameter)
                .ToList()
                .FirstOrDefault();
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
