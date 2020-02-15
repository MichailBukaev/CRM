using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class LinkTeacherCourse : IEntity
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public enum Fields
        {
            Id,
            TeacherId,
            CourseId
        }
        

    }
}
