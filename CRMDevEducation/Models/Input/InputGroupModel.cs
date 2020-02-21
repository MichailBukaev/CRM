using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputGroupModel : IModelInput
    {

        public int Id { get; set; }
        public string NameGroup { get; set; }

        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public List<CutLeadInputModel> Leads { get; set; }
        public string StartDate { get; set; }
        public string History { get; set; }
    }
}
