using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputLeadModel : IModelInput
    {
<<<<<<< HEAD
        public string Id { get; set; }
        public string FName { get; set; }
=======
        public string FName { get; set; } 
>>>>>>> ed357a4489e0b6013123a643d01f4714f83e266d
        public string SName { get; set; }
        public int Numder { get; set; }
        public string DateBirthday { get; set; }
        public InputStatusModel Status { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public List<InputSkillModel> Skills { get; set; }
        public string Password { get; set; }
        public string History { get; set; }

    }
}
