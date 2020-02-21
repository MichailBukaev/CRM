using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputCourseModel: IModelOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseInfo { get; set; }
        public List<CutTeacherOutputModel> Teachers { get; set; }
    }
}
