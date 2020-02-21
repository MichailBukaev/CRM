using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputDayInLogModel : IModelInput
    {
        public DateTime Date { get; set; } 
        public int GroupId { set; get; }
        public Dictionary<int, bool> LeadsVisit { get; set; }
    }
}
