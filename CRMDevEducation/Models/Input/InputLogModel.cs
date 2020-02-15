using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputLogModel : IModelInput
    {
        public DateTime Date { get; set; }
        public Dictionary<int, bool> LeadsVisit { get; set; }
    }
}
