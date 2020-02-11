using System;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Group: IEntity
    {
        
        public int Id { get; set; }
        public string NameGroup { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string StartDate { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Log { get; set; }

        public enum Fields
        { 
          Id, 
          NameGroup, 
          CourseId,
          StartDate, 
          TeacherId, 
          Log 
        }
    }
}
