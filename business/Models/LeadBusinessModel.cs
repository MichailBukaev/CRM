using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class LeadBusinessModel : IModelsBusiness
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public int Numder { get; set; }
        public string DateBirthday { get; set; }
        public string Status { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
