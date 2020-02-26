using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Log: IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public bool Visit { get; set; }

        public enum Fields
        {
            Id,
            Date, 
            LeadId,
            Visit
        }
    }
}
