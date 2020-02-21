using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputGroupModel : IModelInput
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string NameGroup { get; set; }
=======
        public string NameGroup { get; set; } 
>>>>>>> ed357a4489e0b6013123a643d01f4714f83e266d
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public List<CutLeadInputModel> Leads { get; set; }
        public string StartDate { get; set; }
        public string History { get; set; }
    }
}
