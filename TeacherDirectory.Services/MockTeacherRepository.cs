using System.Collections.Generic;
using TeacherDirectory.Models;
using System.Linq;

namespace TeacherDirectory.Services
{
    public class MockTeacherRepository : ITeacherRepository
    {
        private List<Teacher> _teacherList;
        
        public MockTeacherRepository()
        {
            _teacherList = new List<Teacher>()
            {
                new Teacher() { ID = 1, FirstName = "Cooper", LastName = "Hiebendaal", TeacherCode = "HIE", Department = Dept.Sports,
                    Email = "porkhunt@gmail.com", PhotoPath = "John.png" },
                new Teacher() { ID = 2, FirstName = "Malhar", LastName = "Gohel", TeacherCode = "GHL", Department = Dept.Science,
                    Email = "john@pragimtech.com", PhotoPath = "User.jpg" },
                new Teacher() { ID = 3, FirstName = "Aziz", LastName = "Patel", TeacherCode = "PAT", Department = Dept.Mathematics,
                    Email = "sara@pragimtech.com", PhotoPath = "User.jpg" },
                new Teacher() { ID = 4, FirstName = "Shayen", LastName = "Kesha", TeacherCode = "KES", Department = Dept.Technology,
                    Email = "david@pragimtech.com", PhotoPath = "User.jpg" },
            };
        }

        public Teacher Add(Teacher newTeacher)
        {
            newTeacher.ID = _teacherList.Max(e => e.ID) + 1;
            _teacherList.Add(newTeacher);
            return newTeacher;
        }

        public Teacher Delete(int ID)
        {
            var teacherToDelete = _teacherList.FirstOrDefault(e => e.ID == ID);

            if(teacherToDelete != null)
            {
                _teacherList.Remove(teacherToDelete);
            }

            return teacherToDelete;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherList;
        }

        public Teacher GetTeacher(int ID)
        {
            return _teacherList.FirstOrDefault(e => e.ID == ID);
        }

        public IEnumerable<Teacher> Search(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return _teacherList;
            }

            return _teacherList.Where(e => e.FirstName.Contains(searchTerm) ||
            e.Email.Contains(searchTerm));
        }

        public IEnumerable<DeptHeadCount> TeacherCountByDept(Dept? dept)
        {
            IEnumerable<Teacher> query = _teacherList;
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
            Teacher teacher = _teacherList.FirstOrDefault(e => e.ID == updatedTeacher.ID);

            if(teacher != null)
            {
                teacher.FirstName = updatedTeacher.FirstName;
                teacher.Email = updatedTeacher.Email;
                teacher.Department = updatedTeacher.Department;
                teacher.PhotoPath = updatedTeacher.PhotoPath;
            }

            return teacher;
        }
    }
}
