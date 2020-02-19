using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class GroupBusinessModel : IModelsBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }        
        public int TeacherId { get; set; }
        public List<int> LeadsId { get; set; }
        public string StartDate { get; set; }
        public LogBusinessModel LogOfGroup { get; set; }
        public List<string> HistoryGroup { get; set; }
    }
}
