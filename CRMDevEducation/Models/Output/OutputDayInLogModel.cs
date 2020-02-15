using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputDayInLogModel: IModelOutput
    {
        public DateTime Date { get; set; }
        public List<OutputStudentInLog> StudentsInLog { get; set; }
    }
}
