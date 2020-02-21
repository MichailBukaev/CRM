using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputTeacherModel : IModelInput
    {
        public int Id { get; set; } 
        public string FName { get; set; }
        public string SName { get; set; }
        public int PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Head { get; set; }
        public List<CutGroupInputModel> Groups { get; set; }
        public List<CutCourseInputModel> Courses { get; set; }
    }
}
