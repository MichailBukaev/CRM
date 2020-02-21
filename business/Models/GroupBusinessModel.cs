using business.Models.CutModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class GroupBusinessModel : IModelsBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CutCourseBusinessModel Course { get; set; }        
        public CutTeacherBusinessModel Teacher { get; set; }
        public List<CutLeadBusinessModel> Leads { get; set; }
        public string StartDate { get; set; }
        public LogBusinessModel LogOfGroup { get; set; }
        public List<string> HistoryGroup { get; set; }
    }
}
