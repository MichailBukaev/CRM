using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputHRModel : IModelOutput
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public bool Head { get; set; }
    }
}
