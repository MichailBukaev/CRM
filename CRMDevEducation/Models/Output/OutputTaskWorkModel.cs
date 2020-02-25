using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputTaskWorkModel : IModelOutput
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string LoginAuthor { get; set; }
        public string LoginExecuter { get; set; }
        public string Text { get; set; }
        public OutputTaskStatusModel TasksStatus { get; set; }
    }
}
