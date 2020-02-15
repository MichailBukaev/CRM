using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputLogModel : IModelOutput
    {
        public int GroupId { set; get; }
        public string GroupName { set; get; }
        public List<OutputDayInLogModel> Days { get; set; }
    }
}
