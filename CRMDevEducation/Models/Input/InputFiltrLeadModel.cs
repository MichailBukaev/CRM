using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputFiltrLeadModel
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public int Numder { get; set; }
        public string DateBirthday { get; set; }
        public InputStatusModel Status { get; set; }
        public string EMail { get; set; }
        public List<InputSkillModel> Skills { get; set; }
    }
}
