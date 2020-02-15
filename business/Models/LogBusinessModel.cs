using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class LogBusinessModel : IModelsBusiness
    {
        public DateTime Date { get; set; }
        public Dictionary<int, bool> LeadsVisit { get; set; }
    }
}
