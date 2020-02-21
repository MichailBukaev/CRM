using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputUpdateGroupeTecherModel: IModelInput
    {
        public int TeaherId { get; set; }
        public int GroupId { get; set; }
    }
}
