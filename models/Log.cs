using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Log: IEntity
    {
        public DateTime Date { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}
