using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputLogModel : IModelOutput
    {
        public DateTime Date { get; set; }
        public Dictionary<int, bool> LeadsVisit { get; set; }
    }
}
