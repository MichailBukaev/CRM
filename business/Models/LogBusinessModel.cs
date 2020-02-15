using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class LogBusinessModel : IModelsBusiness
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<DayInLogBusinessModel> Days { get; set; }
    }
}
