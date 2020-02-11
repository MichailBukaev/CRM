using System;

namespace models
{
    public class Course: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseInfo { get; set; }

        public enum Fields 
        { 
            Id, 
            Name, 
            CourseInfo 
        }
    }
}
