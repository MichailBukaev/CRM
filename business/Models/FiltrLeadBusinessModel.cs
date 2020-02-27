using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class FiltrLeadBusinessModel
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public int Numder { get; set; }
        public string DateBirthday { get; set; }
        public StatusBusinessModel Status { get; set; }
        public List<SkillBusinessModel> Skills { get; set; }
        public string EMail { get; set; }
    }
}
