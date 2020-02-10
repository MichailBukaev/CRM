using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models
{
    public class Lead: IEntity
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateBirthday { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateRegistration { get; set; }

        public int Numder { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        public bool AccessStatus { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public enum Fields
        {
            Id,
            FName, 
            SName, 
            DateBirthday, 
            DateRegistration, 
            Numder, 
            EMail, 
            AccessStatus, 
            GroupId, 
            StatusId, 
            CourseId
        }
       
    }
}
