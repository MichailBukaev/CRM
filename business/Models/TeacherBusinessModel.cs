using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class TeacherBusinessModel : IModelsBusiness
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public int PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Head { get; internal set; }
    }
}
