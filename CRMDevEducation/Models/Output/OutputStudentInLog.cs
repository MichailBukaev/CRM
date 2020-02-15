using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputStudentInLog: IModelOutput
    {
        public int LeadId { get; set; }
        public string LeadFName { get; set; }
        public string LeadSName { get; set; }
        public bool Vist { get; set; }
    }
}
