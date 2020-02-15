using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class GroupBusinessModel : IModelsBusiness
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public List<LeadsInGroupBusinessModel> Leads { get; set; }
        public string StartDate { get; set; }
        public int[] LeadId { get; set; }
        public LogBusinessModel LogOfGroup { get; set; }
    }
}
