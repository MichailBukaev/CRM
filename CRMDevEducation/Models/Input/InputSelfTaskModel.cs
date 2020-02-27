using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputSelfTaskModel:IModelInput
    {
        public string Task { get; set; }
        public DateTime DeadLine { get; set; }
        public int TasksStatusId { get; set; }

    }
}
