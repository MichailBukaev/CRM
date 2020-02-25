using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputGroupModel : IModelOutput
    {
        public int Id { get; set; }
        public string NameGroup { get; set; }
        public CutCourseOutputModel Course { get; set; }
        public CutTeacherOutputModel Teacher { get; set; }
        public string StartData { get; set; }
        public List<CutLeadOutputModel> Leads { get; set; }
        public OutputLogModel Log { get; set; }
    }
}
