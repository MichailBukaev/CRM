using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputStatusModel:IModelOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
