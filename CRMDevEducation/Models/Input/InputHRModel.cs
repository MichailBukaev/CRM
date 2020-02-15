using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputHRModel : IModelInput
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Head { get;  set; }
    }
}
