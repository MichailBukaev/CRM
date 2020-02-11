using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderCourse : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, Read crudCommand)
        {
            List<Course> primariCourses = (List<Course>)crudCommand.Execute<Course>();
            List<Course> courses;
            if (Course.Fields.Id.ToString() == TKey) { courses = primariCourses.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (Course.Fields.Name.ToString() == TKey) { courses = primariCourses.Where(p => p.Name == TValue).ToList(); }
            else if (Course.Fields.CourseInfo.ToString() == TKey) { courses = primariCourses.Where(p => p.CourseInfo == TValue).ToList(); }
            else { courses = primariCourses; }
            return courses;
        }
    }
}
