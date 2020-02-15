using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputGroupModel : IModelOutput
    {
        public string NameGroup { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public List<OutputLeadModel> LeadsInGroup { get; set; }
    }
}
