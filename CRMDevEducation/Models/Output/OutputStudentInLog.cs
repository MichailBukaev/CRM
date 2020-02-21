using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputStudentInLog: IModelOutput
    {
        public CutLeadOutputModel Lead { get; set; }
        public bool Visit { get; set; }
    }
}
